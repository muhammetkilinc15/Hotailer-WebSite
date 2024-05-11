using AutoMapper;
using HotelProject.DtoLayer.Dtos.AppUserDto;
using HotelProject.DtoLayer.Dtos.GuestDto;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.DtoLayer.Dtos.WorkLocationDto;
using HotelProject.EntityLayer.Concreate;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        // Amaç dto katmanındaki sınıflar ile entity katmanındaki sınıflar eşlenmiş oluyor
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>().ReverseMap();

            CreateMap<RoomUpdateDto, Room>().ReverseMap();

            CreateMap<GuestAddDto, Guest>().ReverseMap();
            CreateMap<GuestUpdateDto, Guest>().ReverseMap();


            CreateMap<AppUser, AppUserDto>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                 .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                 .ForMember(dest => dest.WorkLocationId, opt => opt.MapFrom(src => src.WorkLocationId))
                 .ForMember(dest => dest.WorkLocation, opt => opt.MapFrom(src => src.WorkLocation)).ReverseMap();

        }
    }
}
