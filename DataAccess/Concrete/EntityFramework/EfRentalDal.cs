using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarsId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 CarId = c.Id,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 CustomerId = cu.CustomerId,
                                 DailyPrice = c.DailyPrice,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
