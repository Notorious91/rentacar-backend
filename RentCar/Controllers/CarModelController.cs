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
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelController : DefaultController
    {
        private CarModelService carModelService = new CarModelService();

        [Authorize]
        [Route("/api/carModel/search")]
        [HttpGet]
        public PageResponse<CarModel> GetAllSearch([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            return carModelService.GetPage(new PageModel(page, perPage, search));
        }

        [Route("/api/carModel/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(carModelService.GetAll());
        }

        [Authorize]
        [Route("/api/carModel")]
        [HttpPost]
        public async Task<IActionResult> Post(CarModel carModelModel)
        {
            if (carModelModel.Name == null)
            {
                return BadRequest();
            }

            CarModel carModel = carModelService.Add(carModelModel);

            return Ok(carModel);
        }

        [Authorize]
        [Route("/api/carModel")]
        [HttpPut]
        public async Task<IActionResult> Edit(CarModel carModelModel)
        {
            if (carModelModel.Name == null)
            {
                return BadRequest();
            }

            CarModel carModel = carModelService.Edit(carModelModel);

            return Ok(carModel);
        }

        [Authorize]
        [Route("/api/carModel/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(carModelService.Delete(id));
        }
    }
}