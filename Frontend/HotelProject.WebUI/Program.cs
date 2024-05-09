using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concreate;
using HotelProject.EntityLayer.Concreate;
using HotelProject.WebUI.DTOs.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// -------->>> API den veri çekmek için bunu ekledik
builder.Services.AddHttpClient();
// <<<------------

builder.Services.AddTransient<IValidator<CreateGuestDto>,CreateGuestValidator>();
builder.Services.AddTransient<IValidator<UpdateGuestDto>,UpdateGuestValidator>();

builder.Services.AddControllersWithViews().AddFluentValidation();





builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(options =>
	{
		options.Password.RequireDigit = true;
		options.Password.RequireLowercase = true;
		options.Password.RequireUppercase = true;
		options.Password.RequireNonAlphanumeric = true;
		options.User.RequireUniqueEmail = true;
		options.Password.RequiredLength = 8;
	})
	.AddEntityFrameworkStores<Context>()
	.AddDefaultTokenProviders();


// Automapper added
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    options.LoginPath = "/Login/Index/";
});



var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Area için gerekli alan *****
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
	);
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Default}/{action=Index}/{id?}");





app.Run();
