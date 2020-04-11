using RentCar.Core;
using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RentCar.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(RentCarContext context) : base(context)
        {

        }

        public override PageResponse<Order> GetPage(PageModel model)
        {
            var query = RentCarContext.Orders.Include(x => x.User).Where(x => (x.Deleted == false && (x.Description.Contains(model.Search))));

            return new PageResponse<Order>(query.Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }

        public PageResponse<Order> GetPage(PageModel model, User user)
        {

            if(user.Admin)
            {
                var queryAdmin = RentCarContext.Orders.Include(x => x.User).Where(x => (x.Deleted == false && (x.Description.Contains(model.Search))));
                return new PageResponse<Order>(queryAdmin.Skip(model.Page).Take(model.PerPage).ToList(), queryAdmin.Count());
            }
            
            var query = RentCarContext.Orders.Include(x => x.User).Where(x => (x.Deleted == false && x.User.Id == user.Id && (x.Description.Contains(model.Search))));
            
            return new PageResponse<Order>(query.Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
