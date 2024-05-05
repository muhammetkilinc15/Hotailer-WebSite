using HotelProject.WebUI.DTOs.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("/Admin/[controller]/[action]/{id?}")]
	public class AdminContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("http://localhost:39280/api/Contact");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}
			

		public PartialViewResult SideBarAdminContactPartial()
		{ 
			return PartialView();
		}
        public PartialViewResult SideBarAdminCategoryPartial()
        {
            return PartialView();
        }
    }
}
