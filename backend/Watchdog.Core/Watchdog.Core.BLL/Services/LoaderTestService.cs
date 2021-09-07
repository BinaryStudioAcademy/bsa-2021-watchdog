﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.LoaderTest;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;
using Watchdog.Models.Shared.Loader;
using static System.Net.Mime.MediaTypeNames;

namespace Watchdog.Core.BLL.Services
{
    public class LoaderTestService : BaseService, ILoaderTestService
    {
        private readonly INotifyLoaderQueueProducerService _notifyLoader;

        public LoaderTestService(WatchdogCoreContext context, IMapper mapper, INotifyLoaderQueueProducerService notifyLoader) : base(context, mapper)
        {
            _notifyLoader = notifyLoader;
        }

        public async Task<LoaderTestDto> AddNewLoaderTestAsync(NewLoaderTestDto dto, bool start)
        {
            if (dto.ApplicationId.HasValue && await _context.Applications.AllAsync(a => a.Id != dto.ApplicationId))
            {
                throw new KeyNotFoundException("No application with this id!");
            }
            if (await _context.Organizations.AllAsync(o => o.Id != dto.OrganizationId))
            {
                throw new KeyNotFoundException("No organiation with this id!");
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
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new KeyNotFoundException("No test with this id!");

            return _mapper.Map<LoaderTestDto>(test);
        }

        public async Task<ICollection<LoaderTestDto>> GetLoaderTestsByOrganizationIdAsync(int organizationId)
        {
            if (await _context.Organizations.AllAsync(o => o.Id != organizationId))
            {
                throw new KeyNotFoundException("No organiation with this id!");
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
                .FirstOrDefaultAsync(t => t.Id == dto.Id) ?? throw new KeyNotFoundException("No test with this id!");

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
                    var request = test.Requests.FirstOrDefault(r => r.Id == requestDto.Id) ?? throw new KeyNotFoundException("No request with this id!");
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
        
        private void SendToLoader(LoaderTest test)
        {
            _notifyLoader.SendMessage(_mapper.Map<LoaderMessage>(test));
        }
    }
}
