using AutoMapper;
using Watchdog.Core.Common.DTO.LoaderTest;
using Watchdog.Core.Common.DTO.LoaderTest.Analytics;
using Watchdog.Core.Common.DTO.LoaderTest.Request;
using Watchdog.Core.Common.DTO.LoaderTest.Result;
using Watchdog.Core.Common.DTO.LoaderTest.Test;
using Watchdog.Core.DAL.Entities;
using Watchdog.Models.Shared.Analytics.LoaderTestAnalytics;
using Watchdog.Models.Shared.Loader;

namespace Watchdog.Core.BLL.MappingProfiles
{
    public class LoaderTestProfile : Profile
    {
        public LoaderTestProfile()
        {
            CreateMap<NewLoaderTestDto, LoaderTest>();
            CreateMap<NewLoaderRequestDto, LoaderRequest>();

            CreateMap<LoaderTest, LoaderTestDto>();
            CreateMap<LoaderRequest, LoaderRequestDto>();

            CreateMap<UpdateLoaderRequestDto, LoaderRequest>();

            CreateMap<LoaderTest, LoaderMessage>();
            CreateMap<LoaderRequest, Request>();

            CreateMap<TestResult, LoaderTestResultDto>();

            CreateMap<LoaderTestAnalytics, LoaderTestAnalyticsDto>();
        }
    }
}
