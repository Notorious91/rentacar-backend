using RentCar.Model;
using RentCar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Service
{
    public class OrderService
    {
        public Order Add(Order order)
        {
            if (order == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    order.User = unitOfWork.Users.Get(order.User.Id);
                    order.DateCreated = DateTime.Now;
                    order.DateUpdated = DateTime.Now;
                    order.Deleted = false;
                    unitOfWork.Orders.Add(order);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return order;
        }

        public PageResponse<Order> GetPage(PageModel model, User user)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.Orders.GetPage(model, user);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Order> GetAll()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.Orders.GetAll();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    Order order = unitOfWork.Orders.Get(id);
                    unitOfWork.Orders.Update(order);

                    order.DateUpdated = DateTime.Now;
                    order.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Order Edit(Order order)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    order.User = unitOfWork.Users.Get(order.User.Id);
                    Order orderDb = unitOfWork.Orders.Get(order.Id);
                    unitOfWork.Orders.Update(orderDb);

                    orderDb.DateUpdated = DateTime.Now;
                    orderDb.Description = order.Description;
                    orderDb.Price = order.Price;
                    orderDb.Status = order.Status;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return order;
            }

            return order;
        }
    }
}
