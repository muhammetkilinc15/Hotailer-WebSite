using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JsonWebToken.Controllers
{
    public class JwtTesting : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public JwtTesting(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44325/api/Default/CraateAdminToken");
            var content = await responseMessage.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<string>(content);
            ViewBag.Token = token;  
            return View(token);
        }
    }
}
