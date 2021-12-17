using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from  c in filter == null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailDto {
                                 Id=c.Id,
                                 BrandName = b.Name,
                                 
                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear, 
                                 DailyPrice = c.DailyPrice ,
                                 Description=c.Description,
                                 
                             };
                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByColorAndBrandId(int brandId, int colorId)
        {
            using (ReCapDbContext context=new ReCapDbContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             where b.Id==brandId &&
                             co.Id==colorId

                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.Name,

                                 ColorName = co.Name,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 
                             };
                return result.ToList();
            }
        }
    }
}
