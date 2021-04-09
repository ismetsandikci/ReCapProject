using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        IFindeksDal _findeksDal;

        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            return new SuccessDataResult<List<Findeks>>(_findeksDal.GetAll());
        }

        public IDataResult<Findeks> GetById(int id)
        {
            return new SuccessDataResult<Findeks>(_findeksDal.Get(f => f.Id == id));
        }

        public IDataResult<Findeks> GetByCustomerId(int customerId)
        {
            var findeks = _findeksDal.Get(f => f.CustomerId == customerId);
            if (findeks == null)
            {
                return new ErrorDataResult<Findeks>(Messages.FindeksNotFound);
            }
            return new SuccessDataResult<Findeks>(findeks, Messages.FindeksGetByCustomerId);
        }

        public IResult Add(Findeks findeks)
        {
            var newFindeks = CalculateFindeksScore(findeks).Data;
            _findeksDal.Add(newFindeks);
            return new SuccessResult(Messages.FindeksAdded);
        }
        public IResult Update(Findeks findeks)
        {
            var newFindeks = CalculateFindeksScore(findeks).Data;
            _findeksDal.Update(newFindeks);
            return new SuccessResult(Messages.FindeksUpdated);
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult(Messages.FindeksDeleted);
        }

        public IDataResult<Findeks> CalculateFindeksScore(Findeks findeks)
        {
            findeks.Score = (short)new Random().Next(0, 1901);
            return new SuccessDataResult<Findeks>(findeks);
        }
    }
}
