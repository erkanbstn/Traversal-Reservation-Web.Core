using AutoMapper;
using DtoLayer.Dtos.AnnouncementDto;
using DtoLayer.Dtos.AppUserDto;
using EntityLayer.Concrete;

namespace TraversalSite.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();

            CreateMap<AnnouncementListDto, Announcement>();
            CreateMap<Announcement, AnnouncementListDto>();

            CreateMap<UserLoginDto, AppUser>();
            CreateMap<AppUser, UserLoginDto>();

            CreateMap<UserRegisterDto, AppUser>();
            CreateMap<AppUser, UserRegisterDto>();
        }
    }
}
