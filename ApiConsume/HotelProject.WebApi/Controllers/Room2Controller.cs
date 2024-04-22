using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;
        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = roomService.TGetList();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult AddRoom(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var values = mapper.Map<Room>(roomAddDto);
            roomService.TAdd(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRoom(RoomUpdateDto roomUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var values = mapper.Map<Room>(roomUpdateDto);
            roomService.TUpdate(values);
            return Ok("Room Updated successfully!!!");
        }
    }
}
