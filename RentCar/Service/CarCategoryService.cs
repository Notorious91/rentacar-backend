using RentCar.Model;
using RentCar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Service
{
    public class CarCategoryService
    {
        public CarCategory Add(CarCategory carCategory)
        {
            if (carCategory == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    carCategory.DateCreated = DateTime.Now;
                    carCategory.DateUpdated = DateTime.Now;
                    carCategory.Deleted = false;
                    unitOfWork.CarCategories.Add(carCategory);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return carCategory;
        }
        
        public PageResponse<CarCategory> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.CarCategories.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<CarCategory> GetAll()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.CarCategories.GetAll();
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
                    CarCategory carCategory = unitOfWork.CarCategories.Get(id);
                    unitOfWork.CarCategories.Update(carCategory);

                    carCategory.DateUpdated = DateTime.Now;
                    carCategory.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public CarCategory Edit(CarCategory carCategory)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    CarCategory carCategoryDb = unitOfWork.CarCategories.Get(carCategory.Id);
                    unitOfWork.CarCategories.Update(carCategoryDb);

                    carCategoryDb.DateUpdated = DateTime.Now;
                    carCategoryDb.Name = carCategory.Name;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return carCategory;
            }

            return carCategory;
        }
    }
}
