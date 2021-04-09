using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetById(int creditCardId); 
        IDataResult<List<CreditCard>> GetByCustomerId(int customerId);
        IResult CreditCardExists(string cardNumber);

        IResult Add(CreditCard creditCard);
        IResult Update(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
    }
}
