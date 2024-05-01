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
		private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
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
        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto roomUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = _mapper.Map<Room>(roomUpdateDto);
            _roomService.TUpdate(values);
            return Ok("Room Updated successfully!!!");
        }
    }
}
