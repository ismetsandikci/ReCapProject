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

            CarManager carManager1 = new CarManager(new EfCarDal());
            ColorManager colorManager1 = new ColorManager(new EfColorDal());
            BrandManager brandManager1 = new BrandManager(new EfBrandDal());

            Console.WriteLine("---Color GetAll");
            foreach (var color in colorManager1.GetAll())
            {
                Console.WriteLine("ColorId:{0}, ColorName:{1}", color.ColorId, color.ColorName);
            }

            Console.WriteLine("\n---Brand GetAll");
            foreach (var brand in brandManager1.GetAll())
            {
                Console.WriteLine("BrandId:{0}, BrandName:{1}", brand.BrandId, brand.BrandName);
            }

            Console.WriteLine("\n---Car GetAll");
            foreach (var car in carManager1.GetAll())
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("\n---GetCarDetails");
            foreach (var car in carManager1.GetCarDetails())
            {
                Console.WriteLine("CarId:{0}, BrandName:{1}, ColorName:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandName, car.ColorName, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
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
                DailyPrice = 1850,
                Description = "Test Description"
            };
            carManager1.Add(car1);

            Console.WriteLine("---Car GetById(7)");
            foreach (var car in carManager1.GetById(7))
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            Color color1 = new Color() { ColorId = 4, ColorName = "Blue" };
            colorManager1.Add(color1);
            Console.WriteLine("---Color GetById(4)");
            foreach (var color in colorManager1.GetById(4))
            {
                Console.WriteLine("ColorId:{0}, ColorName:{1}", color1.ColorId,color1.ColorName);
            }

            Brand brand1 = new Brand() { BrandId = 4, BrandName = "Audi" };
            brandManager1.Add(brand1);
            Console.WriteLine("---Brand GetById(4)");
            foreach (var brand in brandManager1.GetById(4))
            {
                Console.WriteLine("BrandId:{0}, BrandName:{1}", brand.BrandId, brand.BrandName);
            }

            car1.BrandId = 4;
            car1.ColorId = 4;
            car1.ModelName = "Test Model Update";
            car1.Description = "Test Description Update";
            carManager1.Update(car1);
            Console.WriteLine("---Color GetById(7)");
            foreach (var car in carManager1.GetById(7))
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            color1.ColorName = "Gray";
            colorManager1.Update(color1);
            Console.WriteLine("---Color GetById(4)");
            foreach (var color in colorManager1.GetById(4))
            {
                Console.WriteLine("ColorId:{0}, ColorName:{1}", color1.ColorId, color1.ColorName);
            }

            brand1.BrandName = "Toyota";
            brandManager1.Update(brand1);
            Console.WriteLine("---Brand GetById(4)");
            foreach (var brand in brandManager1.GetById(4))
            {
                Console.WriteLine("BrandId:{0}, BrandName:{1}", brand.BrandId, brand.BrandName);
            }
            
            colorManager1.Delete(color1);
            brandManager1.Delete(brand1);
            carManager1.Delete(car1);

            //Console.WriteLine("\n----Car Adding Error Message");
            //carManager1.Add(new Car() { CarId=8,BrandId=1,ColorId=3,ModelName="Test Model 2",ModelYear=2018,DailyPrice=800,Description="T" });

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
