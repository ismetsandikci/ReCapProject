using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("---GetAll Car List");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("CarId:"+car.CarId+ " BrandId:"+car.BrandId+ " ColorId:"+car.ColorId+ " ModelName:"+ car.ModelName+ " ModelYear:"+car.ModelYear+ " DailyPrice:"+car.DailyPrice+" Description:"+car.Description);
            }
            Console.WriteLine("\n\n");

            Console.WriteLine("---GetById:1");
            foreach (var car in carManager.GetById(1))
            {
                Console.WriteLine("CarId:" + car.CarId + " BrandId:" + car.BrandId + " ColorId:" + car.ColorId + " ModelName:" + car.ModelName + " ModelYear:" + car.ModelYear + " DailyPrice:" + car.DailyPrice + " Description:" + car.Description);
            }
            Console.WriteLine("\n");
            Console.WriteLine("---GetById:2");
            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine("CarId:" + car.CarId + " BrandId:" + car.BrandId + " ColorId:" + car.ColorId + " ModelName:" + car.ModelName + " ModelYear:" + car.ModelYear + " DailyPrice:" + car.DailyPrice + " Description:" + car.Description);
            }

            Console.WriteLine("\n\n");

            Console.WriteLine("---GetByBrandId:1");
            foreach (var car in carManager.GetByBrandId(1))
            {
                Console.WriteLine("CarId:" + car.CarId + " BrandId:" + car.BrandId + " ColorId:" + car.ColorId + " ModelName:" + car.ModelName + " ModelYear:" + car.ModelYear + " DailyPrice:" + car.DailyPrice + " Description:" + car.Description);
            }
            Console.WriteLine("\n");
            Console.WriteLine("---GetByBrandId:2");
            foreach (var car in carManager.GetByBrandId(2))
            {
                Console.WriteLine("CarId:" + car.CarId + " BrandId:" + car.BrandId + " ColorId:" + car.ColorId + " ModelName:" + car.ModelName + " ModelYear:" + car.ModelYear + " DailyPrice:" + car.DailyPrice + " Description:" + car.Description);
            }
            Console.WriteLine("\n");
            Console.WriteLine("---GetByBrandId:3");
            foreach (var car in carManager.GetByBrandId(3))
            {
                Console.WriteLine("CarId:" + car.CarId + " BrandId:" + car.BrandId + " ColorId:" + car.ColorId + " ModelName:" + car.ModelName + " ModelYear:" + car.ModelYear + " DailyPrice:" + car.DailyPrice + " Description:" + car.Description);
            }

            Console.WriteLine("\n\n");

            Console.WriteLine("---GetByColorId:1");
            foreach (var car in carManager.GetByColorId(1))
            {
                Console.WriteLine("CarId:" + car.CarId + " BrandId:" + car.BrandId + " ColorId:" + car.ColorId + " ModelName:" + car.ModelName + " ModelYear:" + car.ModelYear + " DailyPrice:" + car.DailyPrice + " Description:" + car.Description);
            }
            Console.WriteLine("\n");
            Console.WriteLine("---GetByColorId:2");
            foreach (var car in carManager.GetByColorId(2))
            {
                Console.WriteLine("CarId:" + car.CarId + " BrandId:" + car.BrandId + " ColorId:" + car.ColorId + " ModelName:" + car.ModelName + " ModelYear:" + car.ModelYear + " DailyPrice:" + car.DailyPrice + " Description:" + car.Description);
            }
            Console.WriteLine("\n");
            Console.WriteLine("---GetByColorId:3");
            foreach (var car in carManager.GetByColorId(3))
            {
                Console.WriteLine("CarId:" + car.CarId + " BrandId:" + car.BrandId + " ColorId:" + car.ColorId + " ModelName:" + car.ModelName + " ModelYear:" + car.ModelYear + " DailyPrice:" + car.DailyPrice + " Description:" + car.Description);
            }
        }
    }
}
