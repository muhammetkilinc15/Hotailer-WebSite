var builder = WebApplication.CreateBuilder(args);

// -------->>> API den veri �ekmek i�in bunu ekledik
builder.Services.AddHttpClient();
// <<<------------

builder.Services.AddControllersWithViews();

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
