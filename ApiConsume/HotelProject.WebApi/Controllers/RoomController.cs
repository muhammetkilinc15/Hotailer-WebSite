using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly IRoomService _roomService;


        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        
        }

        [HttpGet]
		public IActionResult Index()
		{
			var values = _roomService.TGetList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult AddRoom(Room room)
		{
		
			_roomService.TAdd(room);
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteRoom(int id)
		{
			_roomService.TDelete(_roomService.TGetByID(id));
			return Ok();
		}



		[HttpGet("{id}")]
		public IActionResult GetRoom(int id)
		{
			var value = _roomService.TGetByID(id);
			return Ok(value);
		}
	}
}
