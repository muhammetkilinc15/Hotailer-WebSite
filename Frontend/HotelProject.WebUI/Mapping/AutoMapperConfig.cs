using AutoMapper;
using HotelProject.EntityLayer.Concreate;
using HotelProject.WebUI.DTOs.AboutDto;
using HotelProject.WebUI.DTOs.BookingDto;
using HotelProject.WebUI.DTOs.GuestDto;
using HotelProject.WebUI.DTOs.LoginDto;
using HotelProject.WebUI.DTOs.RegisterDto;
using HotelProject.WebUI.DTOs.RoomDto;
using HotelProject.WebUI.DTOs.ServiceDto;
using HotelProject.WebUI.DTOs.StafDto;
using HotelProject.WebUI.DTOs.SubscribeDto;

namespace HotelProject.WebUI.Mapping
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		{

			// Service 
			CreateMap<CreateServiceDto, Service>().ReverseMap();
			CreateMap<UpdateServiceDto, Service>().ReverseMap();
			CreateMap<ResultServiceDto, Service>();

			// AppUser

			CreateMap<CreateAppUserDto, AppUser>().ReverseMap();
			CreateMap<LoginUserDto, AppUser>().ReverseMap();


			// About
			CreateMap<ResultAboutDto, About>().ReverseMap();
			CreateMap<UpdateAboutDto, About>().ReverseMap();

			// Room
			CreateMap<ResultRoomDto, Room>();
			CreateMap<CreateRoomDto, Room>().ReverseMap();
			CreateMap<UpdateRoomDto, Room>().ReverseMap();


			// Staf
			CreateMap<ResultStafDto, Staff>();

			//Subscribe
			CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();


			//Booking
			CreateMap<CreateBookingDto, Booking>().ReverseMap();
			CreateMap<ApprovedReservationDto, Booking>().ReverseMap();


			// Guest
			CreateMap<UpdateGuestDto, Guest>().ReverseMap();
			CreateMap<CreateGuestDto, Guest>().ReverseMap();
		}
	}
}
