using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet()]
        [Route("WorkLocationList")]
        public ActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetList();
            return Ok(values);
        }

        [HttpPost("AddWorkLocationList")]
        public ActionResult AddWorkLocationList(WorkLocation workLocation)
        {

            if (workLocation is null)
            {
                return BadRequest(new {Message= ":D"});
            }
            _workLocationService.TAdd(workLocation);
            return NoContent();
        }

        [HttpPost("UpdateWorkLocationList")]
        public ActionResult UpdateWorkLocationList(WorkLocation workLocation)
        {

            if (workLocation is null)
            {
                return BadRequest(new { Message = ":D" });
            }
            _workLocationService.TUpdate(workLocation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation(int id)
        {
            var value = _workLocationService.TGetByID(id);
            _workLocationService.TDelete(value);
            return Ok(value);
        }

        [HttpGet("GetWorkLocation{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var value = _workLocationService.TGetByID(id);
            if (value is null)
            {
                return NotFound();
            }
            return Ok(value);
        }
    }
}
