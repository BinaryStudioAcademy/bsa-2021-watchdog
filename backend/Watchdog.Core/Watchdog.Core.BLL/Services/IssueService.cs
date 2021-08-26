﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Issue;
using Watchdog.Core.Common.Models.Issue;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class IssueService : BaseService, IIssueService
    {
        private readonly IElasticClient _client;

        public IssueService(WatchdogCoreContext context, IMapper mapper, IElasticClient client)
            : base(context, mapper)
        {
            _client = client;
        }

        public async Task<int> AddIssueEventAsync(IssueMessage issueMessage)
        {
            var issue = await _context.Issues.FirstOrDefaultAsync(i =>
                i.ErrorMessage == issueMessage.IssueDetails.ErrorMessage &&
                i.ErrorClass == issueMessage.IssueDetails.ClassName &&
                i.Application.ApiKey == issueMessage.ApiKey);

            var newEventMessage = _mapper.Map<EventMessage>(issueMessage);

            if (issue is null)
            {
                var createdIssue = await CreateNewIssue(issueMessage);

                createdIssue.EventMessages.Add(newEventMessage);

                await _context.SaveChangesAsync();

                return createdIssue.Id;
            }

            newEventMessage.IssueId = issue.Id;

            _context.EventMessages.Add(newEventMessage);

            await _context.SaveChangesAsync();

            return issue.Id;
        }

        public async Task<ICollection<IssueInfoDto>> GetIssuesInfoAsync(int memberId)
        {
            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == memberId) ?? throw new KeyNotFoundException("There is no member with such ID.");

            var issuesInfo = await _context.Applications
                .Include(a => a.ApplicationTeams)
                .ThenInclude(at => at.Team)
                .ThenInclude(t => t.TeamMembers)
                .Where(a => a.ApplicationTeams.Any(at => at.Team.TeamMembers.Any(tm => tm.MemberId == memberId)))
                .SelectMany(a => a.Issues)
                .Select(i => new IssueInfoDto()
                {
                    IssueId = i.Id,
                    ErrorClass = i.ErrorClass,
                    ErrorMessage = i.ErrorMessage,
                    EventsCount = _context.EventMessages.Count(em => em.IssueId == i.Id),
                    Newest = new IssueMessageDto()
                    {
                        Id = _context.EventMessages
                            .Where(em => em.IssueId == i.Id)
                            .OrderByDescending(em => em.OccurredOn)
                            .FirstOrDefault(em => em.IssueId == i.Id).EventId,
                        OccurredOn = _context.EventMessages
                            .Where(em => em.IssueId == i.Id)
                            .OrderByDescending(em => em.OccurredOn)
                            .FirstOrDefault().OccurredOn
                    },
                    Assignee = new AssigneeDto
                    {
                        MemberIds = _context.AssigneeMembers
                            .Where(a => a.IssueId == i.Id)
                            .Select(a => a.MemberId)
                            .ToList(),
                        TeamIds = _context.AssigneeTeams
                            .Where(a => a.IssueId == i.Id)
                            .Select(a => a.TeamId)
                            .ToList()
                    }
                })
                .OrderByDescending(i => i.Newest.OccurredOn)
                .ToListAsync();

            return issuesInfo;
        }

        public async Task<IssueMessage> GetEventMessageByIdAsync(int issueId, string eventId)
        {
            if (!_context.EventMessages.Any(em => em.IssueId == issueId && em.EventId == eventId))
            {
                throw new KeyNotFoundException("There is no event ID with such issue ID.");
            }

            var response = await _client.GetAsync<IssueMessage>(eventId);

            if (!response.IsValid)
            {
                throw new KeyNotFoundException("Event message not found");
            }

            response.Source.IssueId = issueId;

            return response.Source;
        }

        public async Task<ICollection<IssueMessage>> GetEventMessagesByIssueIdAsync(int issueId)
        {
            var issue = await _context.Issues
                .Include(i => i.EventMessages)
                .FirstOrDefaultAsync(i => i.Id == issueId);

            var response = await _client.SearchAsync<IssueMessage>(s => s
                .Size(issue.EventMessages.Count)
                .Query(q => q
                    .Ids(c => c
                        .Values(issue.EventMessages.Select(i => i.EventId)))));

            if (!response.IsValid)
            {
                throw new KeyNotFoundException("Issue Message not found");
            }

            return response.Documents.OrderByDescending(em => em.OccurredOn).ToList();
        }

        public Task UpdateAssigneeAsync(UpdateAssigneeDto assigneeDto)
        {
            if (assigneeDto is null)
            {
                throw new System.ArgumentNullException(nameof(assigneeDto));
            }

            return UpdateAssigneeInternalAsync(assigneeDto);
        }

        public async Task<ICollection<IssueMessageDto>> GetAllIssueMessages()
        {
            var messages = await _context.EventMessages
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<ICollection<IssueMessageDto>>(messages);
        }


        public async Task<ICollection<IssueMessageDto>> GetAllIssueMessagesByApplicationId(int applicationId)
        {
            if (!await _context.Applications.AnyAsync(application => application.Id == applicationId))
            {
                throw new KeyNotFoundException("Application not found");
            }

            var messages = await _context.EventMessages
                .AsNoTracking()
                .Include(message => message.Issue)
                .Where(message => message.Issue.ApplicationId == applicationId)
                .ToListAsync();

            return _mapper.Map<ICollection<IssueMessageDto>>(messages);
        }

        private async Task<Issue> CreateNewIssue(IssueMessage issueMessage)
        {
            var newIssue = _mapper.Map<Issue>(issueMessage);
            var application = await _context.Applications.FirstOrDefaultAsync(a => a.ApiKey == issueMessage.ApiKey)
                ?? throw new KeyNotFoundException("No project with this id!");

            newIssue.Application = application;
            var createdIssue = _context.Issues.Add(newIssue);

            return createdIssue.Entity;
        }

        private async Task UpdateAssigneeInternalAsync(UpdateAssigneeDto assigneeDto)
        {
            if (!await _context.Issues.AnyAsync(i => i.Id == assigneeDto.IssueId))
            {
                throw new KeyNotFoundException("Issue doesn't exist");
            }

            var oldMembers = await _context.AssigneeMembers
                .Where(a => a.IssueId == assigneeDto.IssueId)
                .ToListAsync(); // assignee members in db
            var membersToAdd = assigneeDto.Assignee.MemberIds
                .Except(oldMembers.Select(a => a.MemberId)); // members in db - members in dto
            var membersToDelete = oldMembers
                .Where(m => assigneeDto.Assignee.MemberIds.All(id => m.MemberId != id)); // members in dto - members in db

            await _context.AssigneeMembers.AddRangeAsync(
                membersToAdd.Select(id => new AssigneeMember
                {
                    IssueId = assigneeDto.IssueId,
                    MemberId = id
                }));

            _context.AssigneeMembers.RemoveRange(membersToDelete);

            var oldTeams = await _context.AssigneeTeams
                .Where(a => a.IssueId == assigneeDto.IssueId)
                .ToListAsync(); // assignee teams in db
            var teamsToAdd = assigneeDto.Assignee.TeamIds
                .Except(oldTeams.Select(a => a.TeamId)); // teams in db - teams in dto
            var teamsToDelete = oldTeams
                .Where(t => assigneeDto.Assignee.TeamIds.All(id => t.TeamId != id)); // teams in db - teams in dto

            await _context.AssigneeTeams.AddRangeAsync(
                teamsToAdd.Select(id => new AssigneeTeam
                {
                    IssueId = assigneeDto.IssueId,
                    TeamId = id
                }));

            _context.AssigneeTeams.RemoveRange(teamsToDelete);

            await _context.SaveChangesAsync();
        }
    }
}