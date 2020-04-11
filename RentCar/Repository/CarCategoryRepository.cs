using RentCar.Core;
using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Repository
{
    public class CarCategoryRepository : Repository<CarCategory>, ICarCategoryRepository
    {
        public CarCategoryRepository(RentCarContext context) : base(context)
        {

        }

        public override PageResponse<CarCategory> GetPage(PageModel model)
        {
            var query = RentCarContext.CarCategories.Where(x => (x.Deleted == false && (x.Name.Contains(model.Search))));

            return new PageResponse<CarCategory>(query.Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
