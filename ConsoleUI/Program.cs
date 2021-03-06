using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;
using Entities.Concrete;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //RentalTest();
            string filePath = @"C:\Users\hbbhs\Desktop\WWW";
            string[] dirs = Directory.GetDirectories(filePath);
            Console.WriteLine(Directory.GetCurrentDirectory());
            foreach (var dir in dirs)
            {
                Console.WriteLine(dir);
            }
            Console.WriteLine("--------------------------------------------------");
            var files = Directory.GetFiles(filePath, "*.*",SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if (Regex.IsMatch(file, @"(.*?)\.(png)$"))
                {
                    Console.WriteLine(Path.GetFileName(file));
                    var info = new FileInfo(file);
                    Console.WriteLine("KB---->"+(double)info.Length/(1024));
                }
                
            }
        }

        //private static void RentalTest()
        //{
        //    RentalManager rentalManager = new RentalManager(new EfRentalDal());
        //    //Console.WriteLine(rentalManager.Add(new Rental { Id = 6, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now }).Message);
        //    foreach (var item in rentalManager.GetAll().Data)
        //    {
        //        Console.WriteLine(item.ReturnDate);
        //    }
        //}

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    brandManager.Add(new Brand { Id = 6, Name = "New Brand" });
        //    Console.WriteLine("Brand Name-------->" + " " + brandManager.GetById(6).Data.Name);
        //    brandManager.Update(new Brand { Id = 6, Name = "New New Brand" });
        //    Console.WriteLine("Brand Name-------->" + " " + brandManager.GetById(6).Data.Name);
        //    brandManager.Delete(new Brand { Id = 6, Name = "New New Brand" });
        //    foreach (var item in brandManager.GetAll().Data)
        //    {
        //        Console.WriteLine("Brand ALL ITEMS ID-------->" + " " + item.Id);
        //    }
        //}

        //private static void ColorTest()
        //{
        //    ColorManager colorManager = new ColorManager(new EfColorDal());
        //    colorManager.Add(new Color { Id = 6, Name = "Black and White" });
        //    Console.WriteLine("Color Name-------->" + " " + colorManager.GetById(6).Data.Name);
        //    colorManager.Update(new Color { Id = 6, Name = "Just Black" });
        //    Console.WriteLine("Color Name-------->" + " " + colorManager.GetById(6).Data.Name);
        //    colorManager.Delete(new Color { Id = 6, Name = "I Dont Know" });
        //    foreach (var item in colorManager.GetAll().Data)
        //    {
        //        Console.WriteLine("Color ALL ITEMS ID-------->" + " " + item.Id);
        //    }
        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(new Car { Id = 7, BrandId = 3, ColorId = 3, Description = "The Best", DailyPrice = 200001.99M, Name = "I Dont Know" });
        //    Console.WriteLine("Car Name-------->" + " " + carManager.GetById(6).Data.Name);
        //    carManager.Update(new Car { Id = 7, BrandId = 4, ColorId = 3, Description = "The Best", DailyPrice = 200001.99M, Name = "I Dont Know" });
        //    Console.WriteLine("Car BRANDID-------->" + " " + carManager.GetById(6).Data.BrandId);
        //    carManager.Delete(new Car { Id = 7, BrandId = 4, ColorId = 3, Description = "The Best", DailyPrice = 200001.99M, Name = "I Dont Know" });
        //    foreach (var item in carManager.GetAll().Data)
        //    {
        //        Console.WriteLine("Car ALL ITEMS ID-------->" + " " + item.Id);
        //    }
        //}
    }
}
