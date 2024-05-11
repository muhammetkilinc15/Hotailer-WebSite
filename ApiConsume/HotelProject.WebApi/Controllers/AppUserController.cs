using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.AppUserDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper mapper;

        public AppUserController(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult UserListWithWorkLocation()
        {
            var values = mapper.Map<AppUserDto>(_appUserService.TUserListWithWorkLocation());
            return Ok(_appUserService.TUserListWithWorkLocation());
        }
    }
}
