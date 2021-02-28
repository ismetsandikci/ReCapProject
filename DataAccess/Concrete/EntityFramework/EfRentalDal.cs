using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
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
    }
}
