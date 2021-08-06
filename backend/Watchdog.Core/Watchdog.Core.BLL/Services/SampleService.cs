using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watchdog.Core.BLL.Services.Abstract;
using Watchdog.Core.Common.DTO.Sample;
using Watchdog.Core.DAL.Context;
using Watchdog.Core.DAL.Entities;

namespace Watchdog.Core.BLL.Services
{
    public class SampleService : BaseService, ISampleService
    {
        public SampleService(WatchdogCoreContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<ICollection<SampleDto>> GetAllSamplesAsync()
        {
            var samples = await _context.Samples.ToListAsync();
            return _mapper.Map<ICollection<SampleDto>>(samples);
        }

        public async Task<SampleDto> GetSampleAsync(int sampleId)
        {
            var sample = await _context.Samples.FirstAsync(s => s.Id == sampleId);
            return _mapper.Map<SampleDto>(sample);
        }

        public async Task<ICollection<SampleDto>> GetUserSamplesAsync(int userId)
        {
            var userSamples = await _context.Samples.Where(s => s.CreatedBy == userId).ToListAsync();
            return _mapper.Map<ICollection<SampleDto>>(userSamples);
        }

        public async Task<SampleDto> CreateSampleAsync(NewSampleDto sampleDto)
        {
            var sample = _mapper.Map<Sample>(sampleDto, opts => opts.AfterMap((src, dst) =>
            {
                dst.CreatedAt = DateTime.Now;
            }));

            var createdSample = _context.Add(sample);
            await _context.SaveChangesAsync();

            return _mapper.Map<SampleDto>(createdSample);
        }

        public async Task<SampleDto> UpdateSampleAsync(int sampleId, NewSampleDto sampleDto)
        {
            var existedSample = await _context.Samples.FirstAsync(s => s.Id == sampleId);

            var mergedSample = _mapper.Map(sampleDto, existedSample);

            var updatedSample = _context.Update(mergedSample);
            await _context.SaveChangesAsync();

            return _mapper.Map<SampleDto>(updatedSample);
        }

        public async Task DeleteSampleAsync(int sampleId)
        {
            var sample = await _context.Samples.FirstAsync(s => s.Id == sampleId);
            _context.Remove(sample);

            await _context.SaveChangesAsync();
        }
    }
}
