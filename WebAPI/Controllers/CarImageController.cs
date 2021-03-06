using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService,IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name=("image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            

                var result = _carImageService.Add(file,carImage);
                if (result.Success)
                {
                    return Ok(result.Success);
                }
                return BadRequest(result.Success);
            
            

        }
        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            _carImageService.Delete(carImage);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file ,CarImage carImage)
        {
            
            _carImageService.Update(file, carImage);
            return Ok();
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result=_carImageService.GetAll();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Success);
        }
    }
}
