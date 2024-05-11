using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubscribeController : Controller
	{
		private readonly ISubscribeService _subscribeService;

		public SubscribeController(ISubscribeService subscribeService)
		{
			_subscribeService = subscribeService;
		}

		[HttpGet]
		public IActionResult SubscribeList()
		{
			var values = _subscribeService.TGetList();
			return Ok(values);
		}

        [HttpPost]
        public async Task<IActionResult> AddSubscribe(Subscribe p)
        {
            try
            {
                _subscribeService.TAdd(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
		public IActionResult DeleteSubscribe(int id)
		{

			_subscribeService.TDelete(_subscribeService.TGetByID(id));
			return Ok();
		}

		[HttpPut]
		public IActionResult UpdateSubscribe(Subscribe Subscribe)
		{
			_subscribeService.TUpdate(Subscribe);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult GetSubscribe(int id)
		{
			var value = _subscribeService.TGetByID(id);
			return Ok(value);
		}
	}
}
