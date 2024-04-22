using HotelProject.DataAccessLayer.Concreate;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// -------->>> API den veri çekmek için bunu ekledik
builder.Services.AddHttpClient();
// <<<------------

builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
	{
		options.Password.RequireDigit = true;
		options.Password.RequireLowercase = true;
		options.Password.RequireUppercase = true;
		options.Password.RequireNonAlphanumeric = true;
		options.Password.RequiredLength = 8;
	})
	.AddEntityFrameworkStores<Context>()
	.AddDefaultTokenProviders();


// Automapper added
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
