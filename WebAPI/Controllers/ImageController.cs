using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        IImageService _ımageService;
        //private string _env;

        [Obsolete]
        public ImageController(IImageService carImages/*IHostingEnvironment env*/)
        {
            _ımageService = carImages;
            //_env = env.ContentRootPath;
        }

        [HttpPost("add")]
        public IActionResult PostAdd([FromForm] CarImages carImages,[FromForm] IFormFile file)
        {

            var result = _ımageService.Add(carImages,file);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);

        }
        [HttpPost("delete")]
        public IActionResult  PostDelete(CarImages carImages)
        {
            var result = _ımageService.Delete(carImages);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult PostUpdate(CarImages carImages)
        {
            var result = _ımageService.Update(carImages);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpPost("get")]
        public IActionResult Get(CarImages carImages)
        {
            var result = _ımageService.Get(carImages.Id);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }

       
       
    }
}
