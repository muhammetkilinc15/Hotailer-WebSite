using HotelProject.EntityLayer.Concreate;
using HotelProject.WebUI.DTOs.LoginDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;


		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginUserDto model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var result = await _signInManager.PasswordSignInAsync(model.UserName,model.Password,false,true);
			if(result.Succeeded)
			{
				return RedirectToAction("Index","Default");
			}
			return View();
		}
	}
}
