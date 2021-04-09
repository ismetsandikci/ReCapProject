using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {

        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             into CompanyName from c in CompanyName.DefaultIfEmpty()
                             select new CustomerDetailDto { 
                                 CustomerId = c.CustomerId, 
                                 FirstName = u.FirstName, 
                                 LastName = u.LastName, 
                                 Email = u.Email, 
                                 PasswordSalt = u.PasswordSalt, 
                                 PasswordHash = u.PasswordHash, 
                                 CompanyName = c.CompanyName,
                                 Status = u.Status
                             };
                return result.ToList();
            }
        }
    }
}
