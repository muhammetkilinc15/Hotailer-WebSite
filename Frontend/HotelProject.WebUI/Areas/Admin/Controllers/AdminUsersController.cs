using HotelProject.EntityLayer.Concreate;
using HotelProject.WebUI.DTOs.AppUserDto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("/Admin/[controller]/[action]/{id?}")]
	public class AdminUsersController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public AdminUsersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAppUserDto>>(jsonData);
				return View(values);
			}

			return View();
		}
	}
}
