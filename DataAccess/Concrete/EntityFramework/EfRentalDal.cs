using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (var context = new ReCapDbContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.UserId
                             join u in context.Users
                             on cu.UserId equals u.Id
                             select new RentalDetailDto {  
                                 CustomerFullName= $"{u.FirstName} {u.LastName}",
                                 RentDate=r.RentDate,ReturnDate=r.ReturnDate};
                return result.ToList();
                           
            }
        }
    }
}
