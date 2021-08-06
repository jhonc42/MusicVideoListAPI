using AutoMapper;
using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Domain.Core.Entities;

namespace JAC.MusicVideoList.Transversal.Common.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SecurityUserDTO, SecurityUser>().ReverseMap();
        }
    }
}
