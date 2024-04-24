using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]

        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values) ;
        }
        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            if (booking == null)
            {
                return BadRequest();
            }
            _bookingService.TAdd(booking);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var booking = _bookingService.TGetByID(id);
            _bookingService.TDelete(booking);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
    }
}
