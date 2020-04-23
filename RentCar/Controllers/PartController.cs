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
    public class PartController : DefaultController
    {
        private PartService partService = new PartService();

        [Route("/api/part/search")]
        [HttpGet]
        public PageResponse<Part> GetAllSearch([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            return partService.GetPage(new PageModel(page, perPage, search));
        }

        [Route("/api/part/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(partService.GetAll());
        }

        [Authorize]
        [Route("/api/part")]
        [HttpPost]
        public async Task<IActionResult> Post(Part partModel)
        {
            if (partModel.Name == null)
            {
                return BadRequest();
            }

            Part part = partService.Add(partModel);

            return Ok(part);
        }

        [Authorize]
        [Route("/api/part")]
        [HttpPut]
        public async Task<IActionResult> Edit(Part partModel)
        {
            if (partModel.Name == null)
            {
                return BadRequest();
            }

            Part part = partService.Edit(partModel);

            return Ok(part);
        }

        [Authorize]
        [Route("/api/part/image/{id}")]
        [HttpPost]
        public async Task<IActionResult> UploadImage(int id, [FromForm] IFormFile image)
        {

            return Ok(partService.UploadImage(id, image));
        }

        [Authorize]
        [Route("/api/part/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(partService.Delete(id));
        }
    }
}