using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;

		public ServiceController(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}

		[HttpGet]
		public IActionResult ServiceList()
		{
			var values = _serviceService.TGetList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult AddService(Service p)
		{
			_serviceService.TAdd(p);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteService(int id)
		{

			_serviceService.TDelete(_serviceService.TGetByID(id));
			return Ok();
		}

		[HttpPut]
		public IActionResult UpdateService(Service Service)
		{
			_serviceService.TUpdate(Service);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult GetService(int id)
		{
			var value = _serviceService.TGetByID(id);
			return Ok(value);
		}
	}
}
