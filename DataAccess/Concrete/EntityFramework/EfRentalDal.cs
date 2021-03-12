using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal
    {
        public bool CheckCarStatus(int carId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                bool checkRentable = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);
                return checkRentable;
            }
        }

        public List<RentalDetailDto> GetRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from ra in context.Rentals
                             join c in context.Cars
                             on ra.CarId equals c.CarId
                             join co in context.Customers
                             on ra.CustomerId equals co.CustomerId
                             join u in context.Users
                             on co.UserId equals u.UserId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = ra.RentalId,
                                 BrandName = b.BrandName,
                                 ModelName = c.ModelName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CustomerName = u.FirstName + " " + u.LastName + "/" + co.CompanyName,
                                 RentDate = ra.RentDate,
                                 ReturnDate = ra.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
