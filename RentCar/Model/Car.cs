using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Model
{
    public class Car : Entity
    {
        public string LicencePlate { get; set; }
        public double Price { get; set; }
        public CarModel Model { get; set; }
        public CarCategory Category { get; set; }
        public byte[] Image { get; set; }
    }
}
