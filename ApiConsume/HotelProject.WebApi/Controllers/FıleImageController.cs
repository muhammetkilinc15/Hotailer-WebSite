﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FıleImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName); // Dosya Adı Benzersiz olucak
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/" + fileName);
            var stream = new FileStream(path,FileMode.Create);
            await file.CopyToAsync(stream);
            return Created("",file);
        }
    }
}
