﻿using RentCar.Model;
using RentCar.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentCar.Service
{
    public class PartService
    {
        public Part Add(Part part)
        {
            if (part == null)
            {
                return null;
            }

            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    part.DateCreated = DateTime.Now;
                    part.DateUpdated = DateTime.Now;
                    part.Deleted = false;
                    unitOfWork.Parts.Add(part);
                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return part;
        }

        public PageResponse<Part> GetPage(PageModel model)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.Parts.GetPage(model);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Part> GetAll()
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    return unitOfWork.Parts.GetAll();
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
                    Part part = unitOfWork.Parts.Get(id);
                    unitOfWork.Parts.Update(part);

                    part.DateUpdated = DateTime.Now;
                    part.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public Part Edit(Part part)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork(new RentCarContext()))
                {
                    Part partDb = unitOfWork.Parts.Get(part.Id);
                    unitOfWork.Parts.Update(partDb);

                    partDb.DateUpdated = DateTime.Now;
                    partDb.Name = part.Name;
                    partDb.Price = part.Price;

                    unitOfWork.Complete();
                }
            }
            catch (Exception e)
            {
                return part;
            }

            return part;
        }
    }
}
