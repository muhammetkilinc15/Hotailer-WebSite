using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApi.Consume.Models;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace RapidApi.Consume.Controllers
{
    public class ImdbController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ImdbViewModel> list = new List<ImdbViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "X-RapidAPI-Key", "6ffbbe5578msha590042432168efp1a339cjsnf5f49a7f8759" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                list = JsonConvert.DeserializeObject<List<ImdbViewModel>>(body);
                return View(list);
            }
        }
    }
}
