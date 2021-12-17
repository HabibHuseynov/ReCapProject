using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            var result = _rentalDal.GetAll().Where(r => r.CarId == entity.CarId);
            var checkReslt=BusinessRules.Run(CheckIfRentDate(entity));
            if(result.Any(r=>r.ReturnDate==null))
            {
                return new ErrorResult(Messages.ReturnDateIsNull);
            }
            if (checkReslt != null)
            {
                return checkReslt;
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.ReturnDateIsNotNull);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r => r.CarId == id));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetById(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }

        public IResult CheckIfRentDate(Rental entity)
        {
            var result = _rentalDal.GetById(r => r.CarId == entity.CarId);
            if (result != null)
            {
                if (result.RentDate >= entity.RentDate || result.ReturnDate <= entity.ReturnDate)
                {
                    return new ErrorResult("This item can not be rent at this time please change time");
                }
            }
            return new SuccessResult("Canguratilations");
        }
    }
}
