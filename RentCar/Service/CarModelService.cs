using RentCar.Model;
using RentCar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Service
{
    public class CarModelService
    {
        public CarModel Add(CarModel carModel)
        {
            if (carModel == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    carModel.DateCreated = DateTime.Now;
                    carModel.DateUpdated = DateTime.Now;
                    carModel.Deleted = false;
                    unitOfWork.CarModels.Add(carModel);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return carModel;
        }

        public PageResponse<CarModel> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.CarModels.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<CarModel> GetAll()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.CarModels.GetAll();
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
                    CarModel carModel = unitOfWork.CarModels.Get(id);
                    unitOfWork.CarModels.Update(carModel);

                    carModel.DateUpdated = DateTime.Now;
                    carModel.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public CarModel Edit(CarModel carModel)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    CarModel carModelDb = unitOfWork.CarModels.Get(carModel.Id);
                    unitOfWork.CarModels.Update(carModelDb);

                    carModelDb.DateUpdated = DateTime.Now;
                    carModelDb.Name = carModel.Name;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return carModel;
            }

            return carModel;
        }
    }
}
