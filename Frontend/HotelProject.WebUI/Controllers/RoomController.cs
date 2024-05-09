﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RoomController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RoomController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public IActionResult Index()
		{
			
			return View();
		}
	}
}
