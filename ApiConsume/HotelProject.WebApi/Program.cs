using HotelProject.BusinessLayer.Abstract;
using HotelProject.BusinessLayer.Concreate;
using HotelProject.BusinessLayer.Extensions;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concreate;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concreate;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Api i�in gerekli Eklemeler
ConfigExtension.ConfigureServices(builder.Services);

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

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
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
