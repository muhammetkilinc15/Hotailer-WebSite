using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendService;

        public SendMessageController(ISendMessageService sendService)
        {
            _sendService = sendService;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _sendService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddSendMessage(SendMessage sendMessage)
        {
            _sendService.TAdd(sendMessage);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSendMessage(int id)
        {
            _sendService.TDelete(_sendService.TGetByID(id));
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var value = _sendService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateSendMessage(SendMessage sendMessage)
        {
            _sendService.TUpdate(sendMessage);
            return Ok("Room Updated successfully!!!");
        }
		[HttpGet("GetSendMessageCount")]
		public IActionResult GetSendMessageCount()
		{
		
			return Ok(_sendService.TGetSendMessageCount());
		}


	}
}
