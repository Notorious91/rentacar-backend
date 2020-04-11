using RentCar.Core;
using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RentCarContext context;

        public UnitOfWork(RentCarContext context)
        {
            this.context = context;
            Users = new UserRepository(this.context);
            CarCategories = new CarCategoryRepository(this.context);
            CarModels = new CarModelRepository(this.context);
            Cars = new CarRepository(this.context);
            Parts = new PartRepository(this.context);
            Orders = new OrderRepository(this.context);
        }

        public IUserRepository Users { get; private set; }
        public ICarCategoryRepository CarCategories { get; private set; }
        public ICarModelRepository CarModels { get; private set; }
        public ICarRepository Cars { get; private set; }
        public IPartRepository Parts { get; private set; }
        public IOrderRepository Orders { get; private set; }

        public RentCarContext Context
        {
            get { return context; }
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
