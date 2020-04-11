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
    public class CarCategoryController : DefaultController
    {
        private CarCategoryService carCategoryService = new CarCategoryService();

        [Route("/api/carCategory/search")]
        [HttpGet]
        public PageResponse<CarCategory> GetAllSearch([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            return carCategoryService.GetPage(new PageModel(page, perPage, search));
        }

        [Route("/api/carCategory/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(carCategoryService.GetAll());
        }

        [Authorize]
        [Route("/api/carCategory")]
        [HttpPost]
        public async Task<IActionResult> Post(CarCategory carCategoryModel)
        {
            if (carCategoryModel.Name == null)
            {
                return BadRequest();
            }

            CarCategory carCategory = carCategoryService.Add(carCategoryModel);

            return Ok(carCategory);
        }

        [Authorize]
        [Route("/api/carCategory")]
        [HttpPut]
        public async Task<IActionResult> Edit(CarCategory carCategoryModel)
        {
            if (carCategoryModel.Name == null)
            {
                return BadRequest();
            }

            CarCategory carCategory = carCategoryService.Edit(carCategoryModel);

            return Ok(carCategory);
        }

        [Authorize]
        [Route("/api/carCategory/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(carCategoryService.Delete(id));
        }
    }
}