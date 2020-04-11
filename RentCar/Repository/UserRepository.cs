using RentCar.Core;
using RentCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RentCarContext context) : base(context)
        {

        }
        public User GetUserWithEmail(string email)
        {
            return RentCarContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserWithEmailAndPassword(string email, string password)
        {
            return RentCarContext.Users.Where(x => (x.Email == email && x.Password == password)).FirstOrDefault();
        }

        public override PageResponse<User> GetPage(PageModel model)
        {
            var query = RentCarContext.Users.Where(x => (x.Deleted == false && (x.FirstName.Contains(model.Search) || x.LastName.Contains(model.Search))));



            return new PageResponse<User>(query.Skip(model.Page).Take(model.PerPage).ToList(), query.Count());
        }
    }
}
