﻿using HotelProject.EntityLayer.Concreate;
using HotelProject.WebUI.DTOs.RegisterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateAppUserDto model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var appUser = new AppUser()
			{
				Name = model.Name,
				Email = model.Mail,
				Surname = model.Surname,
				UserName = model.Username
			};
			var result = await _userManager.CreateAsync(appUser, model.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			return View(model);
		}

	}
}
