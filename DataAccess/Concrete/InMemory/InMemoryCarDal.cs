using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal//ICarDal
    {
        List<Car> _car;
        public InMemoryCarDal()
        {
            _car = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=2,ModelYear=1995,DailyPrice=20000,Description="Best of the model"},
                new Car{Id=2,BrandId=1,ColorId=1,ModelYear=1985,DailyPrice=60000,Description="Best of the model"},
                new Car{Id=3,BrandId=2,ColorId=3,ModelYear=1975,DailyPrice=80000,Description="Best of the model"},
                new Car{Id=4,BrandId=3,ColorId=1,ModelYear=1965,DailyPrice=100000,Description="Best of the model"},
                new Car{Id=5,BrandId=3,ColorId=2,ModelYear=2005,DailyPrice=25000,Description="Best of the model"},
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);

        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);

        }

        public List<Car> GetAll()
        {
            return _car;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            Car carById = null;
            carById = _car.SingleOrDefault(c => c.Id == id);
            return carById;

        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColorAndBrandId(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);

            carToUpdate.BrandId = car.Id;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;


        }
    }
}
