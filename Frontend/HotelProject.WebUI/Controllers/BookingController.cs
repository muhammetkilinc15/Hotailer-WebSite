using HotelProject.WebUI.DTOs.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HotelProject.WebUI.Controllers
{
    public class BookingController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public BookingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult AddBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(CreateBookingDto model)
        {
            model.Status = "Onay Bekliyor";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            await client.PostAsync("http://localhost:39280/api/Booking", content);
            return Json(jsonData); // Başarılı bir yanıt döndür
        }


    }
}
