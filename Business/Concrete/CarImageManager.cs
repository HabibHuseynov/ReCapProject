using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file,CarImage entity)
        {
            var result=BusinessRules.Run(CheckIfLimitOfCarImage(entity.CarId));
            if (result!=null)
            {
                return result;
            }
            entity.ImagePath = FileHelper.Add(file);
            entity.Date=DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(CarImage entity)
        {
            var imagePath = GetById(entity.Id).Data.ImagePath;
            var path = Directory.GetCurrentDirectory() + "\\wwwroot\\images\\default.jpg";
            if (imagePath != path)
            {
                FileHelper.Delete(imagePath);
                _carImageDal.Delete(entity);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.GetById(c=>c.Id==id));
        }
        

        public IResult Update(IFormFile file,CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.GetById(p => p.Id == carImage.Id).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
            
        }
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        private IResult CheckIfLimitOfCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
