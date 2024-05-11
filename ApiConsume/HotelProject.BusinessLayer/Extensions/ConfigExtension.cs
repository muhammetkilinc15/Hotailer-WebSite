using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concreate;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concreate;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Extensions
{
    public  class ConfigExtension
    {
        public  static void ConfigureServices(IServiceCollection Services)
        {
            // Api için gerekli Eklemeler
            Services.AddDbContext<Context>();
            Services.AddScoped<IStaffDal, EfStaffDal>(); // IStaffDal görünce  efStaff dal kullan
            Services.AddScoped<IStaffService, StaffManager>(); // IStaffService görünce de StaffManager Kullan demek

            Services.AddScoped<IServiceDal, EfServiceDal>(); // IServiceDal görünce  EfServiceDal dal kullan
            Services.AddScoped<IServiceService, ServiceManager>(); // ITestimonialService görünce de TestimonialManager Kullan demek

            Services.AddScoped<ITestimonialDal, EfTestimonialDal>(); // ITestimonialDal görünce  EfTestimonialDal dal kullan
            Services.AddScoped<ITestimonialService, TestimonialManager>(); // ITestimonialService görünce de TestimonialManager Kullan demek

            Services.AddScoped<ISubscribeDal, EfSubscribeDal>(); // ISubscribeDal görünce  EfSubscribeDal dal kullan
            Services.AddScoped<ISubscribeService, SubscribeManager>(); // ISubscribeService görünce de SubscribeManager Kullan demek


            Services.AddScoped<IRoomDal, EfRoomDal>(); // IRoomDal görünce  EfRoomDal dal kullan
            Services.AddScoped<IRoomService, RoomManager>(); // IRoomService görünce de RoomManager Kullan demek

            Services.AddScoped<IAboutDal, EfAboutDal>(); // IRoomDal görünce  EfRoomDal dal kullan
            Services.AddScoped<IAboutService, AboutManager>(); // IRoomService görünce de RoomManager Kullan demek

            Services.AddScoped<IBookingDal, EfBookingDal>(); // IRoomDal görünce  EfRoomDal dal kullan
            Services.AddScoped<IBookingService, BookingManager>(); // IRoomService görünce de RoomManager Kullan demek

            Services.AddScoped<IContactDal, EfContactDal>();
            Services.AddScoped<IContactService, ContactManager>();

            Services.AddScoped<IGuestDal, EfGuestDal>();
            Services.AddScoped<IGuestService, GuestManager>();

            Services.AddScoped<ISendMessageDal, EfSendMessageDal>();
            Services.AddScoped<ISendMessageService, SendMessageManager>();

            Services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
            Services.AddScoped<IWorkLocationService, WorkLocationManager>();


            Services.AddScoped<IAppUserDAl, EfAppUserDal>();
            Services.AddScoped<IAppUserService, AppUserManager>();
            // Diğer hizmet kayıtları buraya eklenecek
        }

    }
}
