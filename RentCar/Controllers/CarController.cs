using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentCar.Model;
using RentCar.Service;

namespace RentCar.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : DefaultController
    {
        private CarService carService = new CarService();

        [Route("/api/car/search")]
        [HttpGet]
        public PageResponse<Car> GetAllSearch([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            return carService.GetPage(new PageModel(page, perPage, search));
        }

        [Route("/api/car/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(carService.GetAll());
        }

        [Authorize]
        [Route("/api/car")]
        [HttpPost]
        public async Task<IActionResult> Post(Car carModel)
        {
            if (carModel.LicencePlate == null)
            {
                return BadRequest();
            }

            Car car = carService.Add(carModel);

            return Ok(car);
        }

        [Authorize]
        [Route("/api/car")]
        [HttpPut]
        public async Task<IActionResult> Edit(Car carModel)
        {
            if (carModel.LicencePlate == null)
            {
                return BadRequest();
            }

            Car car = carService.Edit(carModel);

            return Ok(car);
        }

        [Authorize]
        [Route("/api/car/image/{id}")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(int id, [FromForm] IFormFile image)
        {

            return Ok(carService.UploadImage(id, image));
        }

        [Authorize]
        [Route("/api/car/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(carService.Delete(id));
        }
    }
}