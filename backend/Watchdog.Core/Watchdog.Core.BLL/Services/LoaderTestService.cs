using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nest;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.LoaderTest.Analytics;
using Watchdog.Core.Common.DTO.LoaderTest.Test;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;
using Watchdog.Models.Shared.Analytics.LoaderTestAnalytics;
using Watchdog.Models.Shared.Loader;

namespace Watchdog.Core.BLL.Services
{
    public class LoaderTestService : BaseService, ILoaderTestService
    {
        private readonly INotifyLoaderQueueProducerService _notifyLoader;
        private readonly IElasticClient _client;

        public LoaderTestService(
            WatchdogCoreContext context,
            IMapper mapper,
            INotifyLoaderQueueProducerService notifyLoader,
            IElasticClient client)
            : base(context, mapper)
        {
            _notifyLoader = notifyLoader;
            _client = client;
        }

        public async Task<LoaderTestDto> AddNewLoaderTestAsync(NewLoaderTestDto dto, bool start)
        {
            if (dto.ApplicationId.HasValue && await _context.Applications.AllAsync(a => a.Id != dto.ApplicationId))
            {
                throw new KeyNotFoundException("No application with this id!");
            }

            if (await _context.Organizations.AllAsync(o => o.Id != dto.OrganizationId))
            {
                throw new KeyNotFoundException("No organization with this id!");
            }

            var test = _mapper.Map<LoaderTest>(dto);
            await _context.LoaderTests.AddAsync(test);
            await _context.SaveChangesAsync();
            if (start)
            {
                SendToLoader(test);
            }

            return _mapper.Map<LoaderTestDto>(test);
        }

        public async Task<LoaderTestDto> GetLoaderTestById(int id)
        {
            var test = await _context.LoaderTests
                           .Include(t => t.Requests)
                           .FirstOrDefaultAsync(t => t.Id == id)
                       ?? throw new KeyNotFoundException("No test with this id!");

            return _mapper.Map<LoaderTestDto>(test);
        }

        public async Task<ICollection<LoaderTestDto>> GetLoaderTestsByOrganizationIdAsync(int organizationId)
        {
            if (await _context.Organizations.AllAsync(o => o.Id != organizationId))
            {
                throw new KeyNotFoundException("No organization with this id!");
            }

            var tests = await _context.LoaderTests
                .Include(t => t.Requests)
                .Include(t => t.Application)
                .ThenInclude(a => a.Platform)
                .Where(t => t.OrganizationId == organizationId)
                .ToListAsync();

            return _mapper.Map<ICollection<LoaderTestDto>>(tests);
        }

        public async Task<LoaderTestDto> UpdateLoaderTestAsync(UpdateLoaderTestDto dto, bool start)
        {
            var test = await _context.LoaderTests
                           .Include(t => t.Requests)
                           .FirstOrDefaultAsync(t => t.Id == dto.Id)
                       ?? throw new KeyNotFoundException("No test with this id!");

            _context.Entry(test).CurrentValues.SetValues(dto);
            test.Requests = test.Requests
                .Where(r =>
                    dto.Requests
                        .Where(x => x.Id.HasValue)
                        .Select(x => x.Id.Value)
                        .Contains(r.Id))
                .ToList();
            foreach (var requestDto in dto.Requests)
            {
                if (requestDto.Id.HasValue)
                {
                    var request = test.Requests.FirstOrDefault(r => r.Id == requestDto.Id) ??
                                  throw new KeyNotFoundException("No request with this id!");
                    _context.Entry(request).CurrentValues.SetValues(requestDto);
                }
                else
                {
                    test.Requests.Add(_mapper.Map<LoaderRequest>(requestDto));
                }
            }

            await _context.SaveChangesAsync();
            if (start)
            {
                SendToLoader(test);
            }

            return _mapper.Map<LoaderTestDto>(test);
        }

        public async Task StartTestAsync(int testId)
        {
            var test = await _context.LoaderTests
                           .Include(t => t.Requests)
                           .FirstOrDefaultAsync(t => t.Id == testId)
                       ?? throw new KeyNotFoundException("No test with this id!");
            SendToLoader(test);
        }

        public async Task<ICollection<LoaderTestAnalyticsDto>> GetLoaderTestResultsAnalyticsByTestIdAsync(int testId)
        {
            var test = await _context.LoaderTests
                           .AsNoTracking()
                           .Include(loaderTest => loaderTest.Requests)
                           .FirstOrDefaultAsync(loaderTest => loaderTest.Id == testId)
                       ?? throw new KeyNotFoundException("No test with this id!");

            var analytics =
                await Task.WhenAll(test.Requests.Select(async request =>
                    await GetLoaderTestAnalyticsByRequestIdAsync(request.Id, request.TestId)));

            return _mapper.Map<ICollection<LoaderTestAnalyticsDto>>(analytics);
        }

        public async Task<LoaderTestAnalyticsDto> GetLoaderTestResultsAnalyticsByRequestIdAsync(int requestId)
        {
            var request = await _context.LoaderRequests
                              .AsNoTracking()
                              .FirstOrDefaultAsync(loaderTest => loaderTest.Id == requestId)
                          ?? throw new KeyNotFoundException("No request with this id!");

            var analytics = await GetLoaderTestAnalyticsByRequestIdAsync(request.Id, request.TestId);

            return _mapper.Map<LoaderTestAnalyticsDto>(analytics);
        }

        private async Task<LoaderTestAnalytics> GetLoaderTestAnalyticsByRequestIdAsync(int requestId, int testId)
        {
            var searchResponse = await _client.SearchAsync<TestResult>(descriptor =>
                descriptor.Size(0)
                    .Query(rq => rq
                        .Match(m => m
                            .Field(f => f.RequestId)
                            .Query(requestId.ToString())
                        )
                    )
                    .Aggregations(ag =>
                    {
                        ag.Average("ResponseTimes.Average", ad => ad
                            .Field(result => result.ResponseTime));
                        ag.Max("ResponseTimes.Max", ad => ad
                            .Field(result => result.ResponseTime));
                        ag.Min("ResponseTimes.Min", ad => ad
                            .Field(result => result.ResponseTime));

                        ag.Sum("Bandwidth.Received", ad => ad
                            .Field(result => result.ReceivedSize));
                        ag.Sum("Bandwidth.Sent", ad => ad
                            .Field(result => result.SentSize));

                        ag.Filter("ResponseCounts.RequestFailed", f => f
                            .Filter(q => q
                                .Term(p => p.IsFailed, "true"))
                            .Aggregations(cd => cd
                                .ValueCount("Count", ad => ad
                                    .Field(result => result.IsFailed))));

                        ag.Filter("ResponseCounts.Information", f => f
                            .Filter(q => q
                                .Range(qd => qd
                                    .Field(result => result.StatusCode)
                                    .GreaterThanOrEquals(100)
                                    .LessThan(200)))
                            .Aggregations(cd => cd
                                .ValueCount("Count", ad => ad
                                    .Field(result => result.StatusCode))));

                        ag.Filter("ResponseCounts.Success", f => f
                            .Filter(q => q
                                .Range(qd => qd
                                    .Field(result => result.StatusCode)
                                    .GreaterThanOrEquals(200)
                                    .LessThan(300)))
                            .Aggregations(cd => cd
                                .ValueCount("Count", ad => ad
                                    .Field(result => result.StatusCode))));

                        ag.Filter("ResponseCounts.Redirection", f => f
                            .Filter(q => q
                                .Range(qd => qd
                                    .Field(result => result.StatusCode)
                                    .GreaterThanOrEquals(300)
                                    .LessThan(400)))
                            .Aggregations(cd => cd
                                .ValueCount("Count", ad => ad
                                    .Field(result => result.StatusCode))));

                        ag.Filter("ResponseCounts.ClientError", f => f
                            .Filter(q => q
                                .Range(qd => qd
                                    .Field(result => result.StatusCode)
                                    .GreaterThanOrEquals(400)
                                    .LessThan(500)))
                            .Aggregations(cd => cd
                                .ValueCount("Count", ad => ad
                                    .Field(result => result.StatusCode))));

                        ag.Filter("ResponseCounts.ServerError", f => f
                            .Filter(q => q
                                .Range(qd => qd
                                    .Field(result => result.StatusCode)
                                    .GreaterThanOrEquals(500)
                                    .LessThan(600)))
                            .Aggregations(cd => cd
                                .ValueCount("Count", ad => ad
                                    .Field(result => result.StatusCode))));
                        return ag;
                    })
            );


            if (!searchResponse.IsValid)
            {
                throw new KeyNotFoundException("Test results not found!");
            }

            return new LoaderTestAnalytics
            {
                Bandwidth = new Bandwidth
                {
                    Received = (ulong) (searchResponse.Aggregations.ValueCount("Bandwidth.Received").Value ?? 0),
                    Sent = (ulong) (searchResponse.Aggregations.ValueCount("Bandwidth.Sent").Value ?? 0)
                },
                ResponseTimes = new ResponseTimes
                {
                    Average = TimeSpan.FromTicks((long) (searchResponse.Aggregations.ValueCount("ResponseTimes.Average")
                        .Value ?? 0)),
                    Max = TimeSpan.FromTicks((long) (searchResponse.Aggregations.ValueCount("ResponseTimes.Max")
                        .Value ?? 0)),
                    Min = TimeSpan.FromTicks((long) (searchResponse.Aggregations.ValueCount("ResponseTimes.Min")
                        .Value ?? 0))
                },
                ResponseCounts = new ResponseCounts
                {
                    Information = (int) (searchResponse.Aggregations
                        .Filter("ResponseCounts.Information")
                        .ValueCount("Count").Value ?? 0),
                    Success = (int) (searchResponse.Aggregations
                        .Filter("ResponseCounts.Success")
                        .ValueCount("Count").Value ?? 0),
                    Redirection = (int) (searchResponse.Aggregations
                        .Filter("ResponseCounts.Redirection")
                        .ValueCount("Count").Value ?? 0),
                    ClientError = (int) (searchResponse.Aggregations
                        .Filter("ResponseCounts.ClientError")
                        .ValueCount("Count").Value ?? 0),
                    ServerError = (int) (searchResponse.Aggregations
                        .Filter("ResponseCounts.ServerError")
                        .ValueCount("Count").Value ?? 0),
                    RequestFailed = (int) (searchResponse.Aggregations
                        .Filter("ResponseCounts.RequestFailed")
                        .ValueCount("Count").Value ?? 0)
                },
                RequestId = requestId,
                TestId = testId
            };
        }

        public async Task DeleteLoaderTestByIdAsync(int id)
        {
            var test = await _context.LoaderTests
                           .FirstOrDefaultAsync(t => t.Id == id)
                       ?? throw new KeyNotFoundException("No test with this id!");

            await _client.DeleteByQueryAsync<TestResult>(q => q
                .Query(rq => rq
                    .Match(m => m
                        .Field(f => f.TestId)
                        .Query(test.Id.ToString()))));
            _context.LoaderTests.Remove(test);
            await _context.SaveChangesAsync();
        }

        private void SendToLoader(LoaderTest test)
        {
            _notifyLoader.SendMessage(_mapper.Map<LoaderMessage>(test));
        }
    }
}