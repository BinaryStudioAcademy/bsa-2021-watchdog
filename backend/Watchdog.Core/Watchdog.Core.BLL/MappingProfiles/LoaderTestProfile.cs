using AutoMapper;
using Watchdog.Core.Common.DTO.Application;
using Watchdog.Core.Common.DTO.Application.AlertSettings;
using Watchdog.Core.DAL.Entities;
using Watchdog.Core.DAL.Entities.AlertSettings;
using Watchdog.Core.Common.DTO.ApplicationTeam;
using Watchdog.Core.Common.DTO.LoaderTest;

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
        }
    }
}
