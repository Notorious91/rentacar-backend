using RentCar.Model;
using RentCar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Service
{
    public class CarService
    {
        public Car Add(Car car)
        {
            if (car == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    car.Model = unitOfWork.CarModels.Get(car.Model.Id);
                    car.Category = unitOfWork.CarCategories.Get(car.Category.Id);
                    car.DateCreated = DateTime.Now;
                    car.DateUpdated = DateTime.Now;
                    car.Deleted = false;
                    unitOfWork.Cars.Add(car);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return car;
        }

        public PageResponse<Car> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.Cars.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Car> GetAll()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.Cars.GetAll();
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    Car car = unitOfWork.Cars.Get(id);
                    unitOfWork.Cars.Update(car);

                    car.DateUpdated = DateTime.Now;
                    car.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Car Edit(Car car)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    car.Model = unitOfWork.CarModels.Get(car.Model.Id);
                    car.Category = unitOfWork.CarCategories.Get(car.Category.Id);
                    Car carDb = unitOfWork.Cars.Get(car.Id);
                    unitOfWork.Cars.Update(carDb);

                    carDb.DateUpdated = DateTime.Now;
                    carDb.LicencePlate = car.LicencePlate;
                    carDb.Price = car.Price;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return car;
            }

            return car;
        }
    }
}
