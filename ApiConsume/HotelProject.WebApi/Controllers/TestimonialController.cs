using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : Controller
	{
		private readonly ITestimonialService _testimonialService;

		public TestimonialController(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}

		[HttpGet]
		public IActionResult TestimoniallList()
		{
			var values = _testimonialService.TGetList();
			return View(values);
		}

		[HttpPost]
		public IActionResult AddTestimonial(Testimonial p)
		{
			_testimonialService.TUpdate(p);
			return Ok();
		}
		[HttpDelete]
		public IActionResult DeleteTestimonial(int id)
		{
			_testimonialService.TDelete(_testimonialService.TGetByID(id));
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult Testimonial(int id)
		{
			var value = _testimonialService.TGetByID(id);
			return Ok(value);
		}
		[HttpPut]
		public IActionResult UpdateTestimonial(Testimonial p)
		{
			_testimonialService.TUpdate(p);
			return Ok();
		}

	}
}
