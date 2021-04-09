using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from ra in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars on ra.CarId equals c.CarId
                             join co in context.Customers on ra.CustomerId equals co.CustomerId
                             join u in context.Users on co.UserId equals u.UserId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join cc in context.CreditCards on ra.CreditCardId equals cc.CreditCardId
                             into CreditCardId from cc in CreditCardId.DefaultIfEmpty()
                             select new RentalDetailDto
                             {
                                 RentalId = ra.RentalId,
                                 BrandName = b.BrandName,
                                 ModelName = c.ModelName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 UserName = u.FirstName + " " + u.LastName,
                                 CompanyName = co.CompanyName,
                                 RentDate = ra.RentDate,
                                 ReturnDate = ra.ReturnDate,
                                 AmountPaye = ra.AmountPaye,
                                 CardNameSurname = cc.CardNameSurname,
                                 CardNumber = cc.CardNumber,
                                 CardExpiryDateMonth = cc.CardExpiryDateMonth,
                                 CardExpiryDateYear = cc.CardExpiryDateYear,
                                 CardCvv = cc.CardCvv
                             };
                return result.ToList();
            }
        }
    }
}
