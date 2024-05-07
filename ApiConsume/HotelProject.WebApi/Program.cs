using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concreate;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concreate;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concreate;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Api i�in gerekli Eklemeler
builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<IStaffDal,EfStaffDal>(); // IStaffDal g�r�nce  efStaff dal kullan
builder.Services.AddScoped<IStaffService,StaffManager>(); // IStaffService g�r�nce de StaffManager Kullan demek

builder.Services.AddScoped<IServiceDal, EfServiceDal>(); // IServiceDal g�r�nce  EfServiceDal dal kullan
builder.Services.AddScoped<IServiceService, ServiceManager>(); // ITestimonialService g�r�nce de TestimonialManager Kullan demek

builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>(); // ITestimonialDal g�r�nce  EfTestimonialDal dal kullan
builder.Services.AddScoped<ITestimonialService, TestimonialManager>(); // ITestimonialService g�r�nce de TestimonialManager Kullan demek

builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>(); // ISubscribeDal g�r�nce  EfSubscribeDal dal kullan
builder.Services.AddScoped<ISubscribeService, SubscribeManager>(); // ISubscribeService g�r�nce de SubscribeManager Kullan demek


builder.Services.AddScoped<IRoomDal, EfRoomDal>(); // IRoomDal g�r�nce  EfRoomDal dal kullan
builder.Services.AddScoped<IRoomService, RoomManager>(); // IRoomService g�r�nce de RoomManager Kullan demek

builder.Services.AddScoped<IAboutDal, EfAboutDal>(); // IRoomDal g�r�nce  EfRoomDal dal kullan
builder.Services.AddScoped<IAboutService, AboutManager>(); // IRoomService g�r�nce de RoomManager Kullan demek

builder.Services.AddScoped<IBookingDal, EfBookingDal>(); // IRoomDal g�r�nce  EfRoomDal dal kullan
builder.Services.AddScoped<IBookingService, BookingManager>(); // IRoomService g�r�nce de RoomManager Kullan demek

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IGuestDal, EfGuestDal>();
builder.Services.AddScoped<IGuestService, GuestManager>();

builder.Services.AddScoped<ISendMessageDal, EfSendMessageDal>();
builder.Services.AddScoped<ISendMessageService, SendMessageManager>();


builder.Services.AddAutoMapper(typeof(Program)); // AutoMapper i�in ekledik

// -----> APIYI ba�ka katmanlar da kullanmak i�in gerekli 
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

// ------------->>> API ba�ka katman i�in
app.UseCors("HotelAPI");
// <<<-----------

app.UseAuthorization();

app.MapControllers();

app.Run();
