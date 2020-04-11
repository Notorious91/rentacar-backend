using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Model
{
    public class RentCarContext : DbContext
    {
        public RentCarContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer("Server=DESKTOP-QT3N234\\SQLEXPRESS;Database=RentCar;Trusted_Connection=True;");
        }
    }
}
