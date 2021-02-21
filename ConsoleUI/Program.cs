using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryCarDalTest();

            Console.WriteLine("---GetAll");
            CarManager carManager1 = new CarManager(new EfCarDal());
            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }
            Console.WriteLine("\n---GetById(6)");
            foreach (var car in carManager1.GetById(6))
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }
            Console.WriteLine("\n---GetCarsByBrandId(2)");
            foreach (var car in carManager1.GetCarsByBrandId(2))
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }
            Console.WriteLine("\n---GetCarsByColorId(3)");
            foreach (var car in carManager1.GetCarsByColorId(3))
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            Car car1 = new Car()
            {
                CarId = 7,
                BrandId = 2,
                ColorId = 3,
                ModelName = "Test Model",
                ModelYear = 2021,
                DailyPrice = 850,
                Description = "Test Description"
            };
            carManager1.Add(car1);
            Console.WriteLine("---GetById(7)");
            foreach (var car in carManager1.GetById(7))
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            car1.ModelName = "Test Model Update";
            car1.Description = "Test Description Update";
            carManager1.Update(car1);
            Console.WriteLine("---GetById(7)");
            foreach (var car in carManager1.GetById(7))
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("\n----Car Adding Error Message");
            carManager1.Add(new Car() { CarId=8,BrandId=1,ColorId=3,ModelName="Test Model 2",ModelYear=2018,DailyPrice=800,Description="T" });
        }

        private static void InMemoryCarDalTest()
        {
            //InMemoryCarDal ile çalışırken kullanılan kodlar

            //CarManager carManager = new CarManager(new InMemoryCarDal());
            //Console.WriteLine("---GetAll Car List");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
            //        car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            //}
            //Console.WriteLine("\n");

            //Console.WriteLine("---GetById:1");
            //foreach (var car in carManager.GetById(1))
            //{
            //   Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
            //        car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            //}
            //Console.WriteLine("\n");
            //Console.WriteLine("---GetById:2");
            //foreach (var car in carManager.GetById(2))
            //{
            //   Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
            //       car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            //}
        }
    }
}
