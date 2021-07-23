﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Watchdog.Core.Common.DTO.Sample;

namespace Watchdog.Core.BLL.Services.Abstract
{
    public interface ISampleService
    {
        Task<ICollection<SampleDto>> GetAllSamplesAsync();

        Task<SampleDto> GetSampleAsync(int sampleId);

        Task<ICollection<SampleDto>> GetUserSamplesAsync(int userId);

        Task<SampleDto> CreateSampleAsync(NewSampleDto sampleDto);

        Task<SampleDto> UpdateSampleAsync(int sampleId, NewSampleDto sampleDto);

        Task DeleteSampleAsync(int sampleId);
    }
}
