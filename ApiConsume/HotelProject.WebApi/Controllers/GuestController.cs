using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.GuestDto;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : Controller
    {
        private readonly IGuestService _guestService;
        private readonly IMapper _mapper;

        public GuestController(IGuestService guestService, IMapper mapper)
        {
            _guestService = guestService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetGuest()
        {
            var values = _guestService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public ActionResult GetGuest(int id)
        {
            var value = _guestService.TGetByID(id);
            if (value == null)
            {
                return NotFound();
            }
            return Ok(value);
        }

        [HttpPost]
 
        public ActionResult AddGuest(GuestAddDto dto)
        {
            var entity = _mapper.Map<Guest>(dto);
            _guestService.TAdd(entity);
            return Ok();
        }

        [HttpPut]

		public ActionResult UpdateGuest(GuestUpdateDto dto)
        {
            var entity = _mapper.Map<Guest>(dto);
            _guestService.TUpdate(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var entity = _guestService.TGetByID(id);
            if (entity == null)
            {
                return NotFound();
            }
            _guestService.TDelete(entity);
            return Ok();
        }


    }
}
