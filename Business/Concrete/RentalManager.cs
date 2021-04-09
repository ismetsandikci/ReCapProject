using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;
        IFindeksService _findeksService;

        public RentalManager(IRentalDal rentalDal, ICarService carService, IFindeksService findeksService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
            _findeksService = findeksService;
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckCarStatus(rental), CheckFindeksScoreSufficiency(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            if (_rentalDal.CheckCarStatus(rental.CarId,rental.RentDate,rental.ReturnDate))
            {
                return new ErrorResult(Messages.RentalReturnDateError);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalGetAll);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId), Messages.GetRentalByRentalId);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }
        public IDataResult<List<RentalDetailDto>> GetRentalDetailsById(int rentalId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.RentalId == rentalId));
        }

        public IResult CheckCarStatus(Rental rental)
        {
            if (_rentalDal.CheckCarStatus(rental.CarId, rental.RentDate, rental.ReturnDate))
            {
                return new SuccessResult(Messages.RentalDateOk);
            }
            return new ErrorResult(Messages.RentalReturnDateError);
        }

        public IResult CheckFindeksScoreSufficiency(Rental rental)
        {
            var car = _carService.GetById(rental.CarId).Data;
            var findeks = _findeksService.GetByCustomerId(rental.CustomerId).Data;

            if (findeks == null)
            {
                return new ErrorResult(Messages.FindeksNotFound);
            }
            if (findeks.Score < car.MinFindeksScore)
            {
                return new ErrorResult(Messages.FindeksNotEnoughForCar);
            }
            return new SuccessResult(Messages.FindeksIsSufficientForCar) ; 
        }

    }
}
