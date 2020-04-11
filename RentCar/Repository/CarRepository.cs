using RentCar.Core;
using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RentCar.Repository
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(RentCarContext context) : base(context)
        {

        }

        public override PageResponse<Car> GetPage(PageModel model)
        {
            var query = RentCarContext.Cars.Include(x => x.Category).Include(x => x.Model).Where(x => (x.Deleted == false && (x.LicencePlate.Contains(model.Search) || x.Model.Name.Contains(model.Search)
            || x.Category.Name.Contains(model.Search))));


            return new PageResponse<Car>(query.Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
