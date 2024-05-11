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

// Api için gerekli Eklemeler
ConfigExtension.ConfigureServices(builder.Services);

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

// ------------->>> API baþka katman için
app.UseCors("HotelAPI");
// <<<-----------

app.UseAuthorization();

app.MapControllers();

app.Run();
