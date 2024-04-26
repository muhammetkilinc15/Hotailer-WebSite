using AutoMapper;
using HotelProject.EntityLayer.Concreate;
using HotelProject.WebUI.DTOs.AboutDto;
using HotelProject.WebUI.DTOs.BookingDto;
using HotelProject.WebUI.DTOs.LoginDto;
using HotelProject.WebUI.DTOs.RegisterDto;
using HotelProject.WebUI.DTOs.ServiceDto;
using HotelProject.WebUI.DTOs.StafDto;
using HotelProject.WebUI.DTOs.SubscribeDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CreateServiceDto,Service>().ReverseMap();
            CreateMap<UpdateServiceDto,Service>().ReverseMap();
            CreateMap<ResultServiceDto,Service>().ReverseMap();

            CreateMap<CreateAppUserDto,AppUser>().ReverseMap();
            CreateMap<LoginUserDto,AppUser>().ReverseMap();

            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<ResultStafDto, Staff>().ReverseMap();

            CreateMap<CreateSubscribeDto,Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto,Booking>().ReverseMap();
            CreateMap<ApprovedReservationDto, Booking>().ReverseMap();
        }
    }
}
