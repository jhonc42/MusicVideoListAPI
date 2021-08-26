using AutoMapper;
using JAC.MusicVideoList.Application.Main.DTOs;
using JAC.MusicVideoList.Domain.Core.Entities;

namespace JAC.MusicVideoList.Infrastructure.Main.Mapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<UserTokenDTO, User>().ReverseMap();
            CreateMap<UserDTO, UserTokenDTO>().ReverseMap();
        }
    }
}
