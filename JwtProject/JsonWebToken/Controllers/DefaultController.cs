using JsonWebToken.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet("[action]")]
        public IActionResult CreateAnyToken()
        {

            return  Ok(new CreateToken().TokenCreate());
        }

        [HttpGet("[action]")]
        public IActionResult CraateAdminToken()
        {

            return Ok(new CreateToken().TokenCreateAdmin());
        }


        [Authorize]
        [HttpGet("[action]")]
        public IActionResult TestingAnyToken()
        {
            return Ok("Hoşgeldiniz");
        }

        [Authorize(Roles ="Admin,Visitor")]
        [HttpGet("[action]")]
        public IActionResult TestingAdminToken()
        {
            return Ok("Token başarılı şekilde giriş yaptı");
        }


    }
}
