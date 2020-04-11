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
    public class OrderController : DefaultController
    {
        private OrderService orderService = new OrderService();

        [Route("/api/order/search")]
        [HttpGet]
        public PageResponse<Order> GetAllSearch([FromQuery(Name = "page")] int page, [FromQuery(Name = "perPage")] int perPage, [FromQuery(Name = "search")] string search)
        {
            return orderService.GetPage(new PageModel(page, perPage, search), GetCurrentUser());
        }

        [Route("/api/order/all")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(orderService.GetAll());
        }

        [Authorize]
        [Route("/api/order")]
        [HttpPost]
        public async Task<IActionResult> Post(Order orderModel)
        {
            if (orderModel.Description == null)
            {
                return BadRequest();
            }

            orderModel.User = GetCurrentUser();

            Order order = orderService.Add(orderModel);

            return Ok(order);
        }

        [Authorize]
        [Route("/api/order")]
        [HttpPut]
        public async Task<IActionResult> Edit(Order orederModel)
        {
            if (orederModel.Description == null)
            {
                return BadRequest();
            }

            Order order = orderService.Edit(orederModel);

            return Ok(order);
        }

        [Authorize]
        [Route("/api/order/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(orderService.Delete(id));
        }
    }
}