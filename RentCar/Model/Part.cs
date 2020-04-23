using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Model
{
    public class Part : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
    }
}
