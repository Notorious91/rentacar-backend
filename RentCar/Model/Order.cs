using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Model
{
    public class Order : Entity
    {
        public string Description { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public User User { get; set; }
    }
}
