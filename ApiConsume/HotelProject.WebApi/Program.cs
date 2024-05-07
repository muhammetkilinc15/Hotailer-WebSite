using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concreate;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concreate;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concreate;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Api için gerekli Eklemeler
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal,EfStaffDal>(); // IStaffDal görünce  efStaff dal kullan
builder.Services.AddScoped<IStaffService,StaffManager>(); // IStaffService görünce de StaffManager Kullan demek

builder.Services.AddScoped<IServiceDal, EfServiceDal>(); // IServiceDal görünce  EfServiceDal dal kullan
builder.Services.AddScoped<IServiceService, ServiceManager>(); // ITestimonialService görünce de TestimonialManager Kullan demek

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>(); // ITestimonialDal görünce  EfTestimonialDal dal kullan
builder.Services.AddScoped<ITestimonialService, TestimonialManager>(); // ITestimonialService görünce de TestimonialManager Kullan demek

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>(); // ISubscribeDal görünce  EfSubscribeDal dal kullan
builder.Services.AddScoped<ISubscribeService, SubscribeManager>(); // ISubscribeService görünce de SubscribeManager Kullan demek


builder.Services.AddScoped<IRoomDal, EfRoomDal>(); // IRoomDal görünce  EfRoomDal dal kullan
builder.Services.AddScoped<IRoomService, RoomManager>(); // IRoomService görünce de RoomManager Kullan demek

builder.Services.AddScoped<IAboutDal, EfAboutDal>(); // IRoomDal görünce  EfRoomDal dal kullan
builder.Services.AddScoped<IAboutService, AboutManager>(); // IRoomService görünce de RoomManager Kullan demek

builder.Services.AddScoped<IBookingDal, EfBookingDal>(); // IRoomDal görünce  EfRoomDal dal kullan
builder.Services.AddScoped<IBookingService, BookingManager>(); // IRoomService görünce de RoomManager Kullan demek

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IGuestDal, EfGuestDal>();
builder.Services.AddScoped<IGuestService, GuestManager>();

builder.Services.AddScoped<ISendMessageDal, EfSendMessageDal>();
builder.Services.AddScoped<ISendMessageService, SendMessageManager>();


builder.Services.AddAutoMapper(typeof(Program)); // AutoMapper için ekledik

// -----> APIYI baþka katmanlar da kullanmak için gerekli 
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("HotelAPI", opt =>
	{
		opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});

// <<<---------------

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

// ------------->>> API baþka katman için
app.UseCors("HotelAPI");
// <<<-----------

app.UseAuthorization();

app.MapControllers();

app.Run();
