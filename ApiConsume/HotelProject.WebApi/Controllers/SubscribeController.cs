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
		public IActionResult AddSubscribe(Subscribe p)
		{
			_subscribeService.TAdd(p);
			return Ok();
		}

		[HttpDelete]
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
