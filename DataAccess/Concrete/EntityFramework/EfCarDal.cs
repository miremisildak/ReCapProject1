using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from b in context.Brands
                             join c in context.Cars
                             on b.BrandId equals c.BrandId
                             join r in context.Colors
                             on c.ColorId equals r.ColorId
                             select new CarDetailDto
                             {
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = r.ColorName,
                                 CarName = c.CarName
                             };
                return result.ToList();



            }
        }
    }
}
