using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public IActionResult GetContactList()
		{
			return Ok(_contactService.TGetList());
		}

		[HttpPost]
		public IActionResult AddContact([FromBody] Contact contact,CancellationToken token)
		{
			if (contact is null)
			{
				return BadRequest();
			}
			contact.Date = DateTime.Now;
			_contactService.TAdd(contact);
			return Ok();
		}
		[HttpGet("{id}")]
		public ActionResult GetContact(int id)
		{
			var values = _contactService.TGetByID(id);
			return Ok(values);
		}

	}
}
