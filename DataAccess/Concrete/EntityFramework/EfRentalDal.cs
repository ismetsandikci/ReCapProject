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
        public bool CheckCarStatus(int carId, DateTime rentDate, DateTime? returnDate)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                bool checkReturnDateIsNull = context.Set<Rental>().Any(p => p.CarId == carId && p.ReturnDate == null);
                bool isValidRentDate = context.Set<Rental>()
                    .Any(r => r.CarId == carId && (
                            (rentDate >= r.RentDate && rentDate <= r.ReturnDate) ||
                            (returnDate >= r.RentDate && returnDate <= r.ReturnDate) ||
                            (r.RentDate >= rentDate && r.RentDate <= returnDate)
                            )
                    );

                if ( (!checkReturnDateIsNull) && (!isValidRentDate))
                {
                    return true;
                }
                
                return false;
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
                             join p in context.Payments
                             on ra.PaymentId equals p.PaymentId
                             select new RentalDetailDto
                             {
                                 RentalId = ra.RentalId,
                                 BrandName = b.BrandName,
                                 ModelName = c.ModelName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CustomerName = co.CompanyName,
                                 RentDate = ra.RentDate,
                                 ReturnDate = ra.ReturnDate,
                                 CardNameSurname = p.CardNameSurname,
                                 CardNumber = p.CardNumber,
                                 CardExpiryDate = p.CardExpiryDate,
                                 CardCvv = p.CardCvv,
                                 AmountPaye = p.AmountPaye
                                 
                             };
                return result.ToList();
            }
        }
    }
}
