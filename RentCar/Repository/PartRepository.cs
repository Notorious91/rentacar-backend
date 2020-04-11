using RentCar.Core;
using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Repository
{
    public class PartRepository : Repository<Part>, IPartRepository
    {
        public PartRepository(RentCarContext context) : base(context)
        {

        }
        public override PageResponse<Part> GetPage(PageModel model)
        {
            var query = RentCarContext.Parts.Where(x => (x.Deleted == false && (x.Name.Contains(model.Search))));

            return new PageResponse<Part>(query.Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
