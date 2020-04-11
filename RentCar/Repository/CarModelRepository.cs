using RentCar.Core;
using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Repository
{
    public class CarModelRepository : Repository<CarModel>, ICarModelRepository
    {
        public CarModelRepository(RentCarContext context) : base(context)
        {

        }

        public override PageResponse<CarModel> GetPage(PageModel model)
        {
            var query = RentCarContext.CarModels.Where(x => (x.Deleted == false && (x.Name.Contains(model.Search))));

            return new PageResponse<CarModel>(query.Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
