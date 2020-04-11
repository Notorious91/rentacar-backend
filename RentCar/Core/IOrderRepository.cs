using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Core
{
    public interface IOrderRepository : IRepository<Order>
    {
        PageResponse<Order> GetPage(PageModel model, User user);
    }
}
