using AutoMapper;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concreate;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        // Amaç dto katmanındaki sınıflar ile entity katmanındaki sınıflar eşlenmiş oluyor
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>().ReverseMap();
   
            CreateMap<RoomUpdateDto,Room>().ReverseMap();

        }
    }
}
