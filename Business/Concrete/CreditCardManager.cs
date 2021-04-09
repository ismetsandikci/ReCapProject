using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }
       
        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), Messages.CreditCardGetAll);
        }

        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c=> c.CreditCardId == creditCardId), Messages.GetCreditCardById);
        }

        public IDataResult<List<CreditCard>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == customerId), Messages.GetCreditCardById);
        }

        public IResult CreditCardExists(string cardNumber)
        {
            var resultData = _creditCardDal.Get(c => c.CardNumber == cardNumber);
            if(resultData != null)
            {
                //kredi kartı var
                return new SuccessDataResult<CreditCard>(resultData,Messages.CreditCardAlreadyExists);
            }
            //kredi kartı yok
            return new ErrorResult();
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded + "-" + creditCard.CreditCardId.ToString());
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

    }
}
