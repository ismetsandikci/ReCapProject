using Business.Concrete;
using Core.Entities.Concrete;
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

            //Car, Color, Brand -> CRUD, GetAll, GetCarDetails, GetById, GetCarsByBrandId, GetCarsByColorId examples
            //CarColorBrandExamples();

            /*
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { FirstName = "User1FN", LastName = "User1LN", Email = "user1@user.com", Password = "1234" });
            userManager.Add(new User { FirstName = "User2FN", LastName = "User2LN", Email = "user2@user.com", Password = "4321" });
            userManager.Add(new User { FirstName = "User3FN", LastName = "User3LN", Email = "user3@user.com", Password = "2143" });
            Console.WriteLine("---User List");
            var resultUsersList = userManager.GetAll();
            if (resultUsersList.Success)
            {
                foreach (var user in resultUsersList.Data)
                {
                    Console.WriteLine("FirstName={0}, LastName={1}, Email={2}, Password={3}", user.FirstName, user.LastName, user.Email, user.Password);
                }
            }
            */

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "Company1" });
            customerManager.Add(new Customer { UserId = 2, CompanyName = "Company2" });
            customerManager.Add(new Customer { UserId = 3, CompanyName = "Company3" });
            Console.WriteLine("\n---Customer List");
            var resultCustomersList = customerManager.GetCustomerDetails();
            if (resultCustomersList.Success)
            {
                foreach (var customer in resultCustomersList.Data)
                {
                    Console.WriteLine("FirstName={0}, LastName={1}, Email={2}, Password={3}, CompanyName={4}", customer.FirstName, customer.LastName, customer.Email, customer.CompanyName);
                }
            }

            /*
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("isRented1: " + rentalManager.Add(new Rental { CarId = 1, CustomerId = 1, RentDate = new DateTime(2021, 2, 20), ReturnDate = new DateTime(2021, 2, 25) }).Message);
            Console.WriteLine("isRented2: " + rentalManager.Add(new Rental { CarId = 2, CustomerId = 2, RentDate = new DateTime(2021, 2, 21) }).Message);
            Console.WriteLine("isRented3: " + rentalManager.Add(new Rental { CarId = 2, CustomerId = 3, RentDate = new DateTime(2021, 2, 22) }).Message);
            */
        }

        private static void CarColorBrandExamples()
        {
            CarManager carManager1 = new CarManager(new EfCarDal());
            ColorManager colorManager1 = new ColorManager(new EfColorDal());
            BrandManager brandManager1 = new BrandManager(new EfBrandDal());

            Console.WriteLine("---Color GetAll");
            foreach (var color in colorManager1.GetAll().Data)
            {
                Console.WriteLine("ColorId:{0}, ColorName:{1}", color.ColorId, color.ColorName);
            }

            Console.WriteLine("\n---Brand GetAll");
            foreach (var brand in brandManager1.GetAll().Data)
            {
                Console.WriteLine("BrandId:{0}, BrandName:{1}", brand.BrandId, brand.BrandName);
            }

            Console.WriteLine("\n---Car GetAll");
            foreach (var car in carManager1.GetAll().Data)
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandId, car.ColorId, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("\n---GetCarDetails");
            foreach (var car in carManager1.GetCarDetails().Data)
            {
                Console.WriteLine("CarId:{0}, BrandName:{1}, ColorName:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandName, car.ColorName, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            Console.WriteLine("\n---GetById(6)");
            var resultCarGetById = carManager1.GetById(6).Data;
            Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    resultCarGetById.CarId, resultCarGetById.BrandId, resultCarGetById.ColorId, resultCarGetById.ModelName, resultCarGetById.ModelYear, resultCarGetById.DailyPrice, resultCarGetById.Description);

            Console.WriteLine("\n---GetCarsByBrandId(2)");
            var resultGetCarsByBrandId = carManager1.GetCarsByBrandId(2).Data;
            foreach (var car in resultGetCarsByBrandId)
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandName, car.ColorName, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }
            Console.WriteLine("\n---GetCarsByColorId(3)");
            var resultGetCarsByColorId = carManager1.GetCarsByColorId(3).Data;
            foreach (var car in resultGetCarsByColorId)
            {
                Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    car.CarId, car.BrandName, car.ColorName, car.ModelName, car.ModelYear, car.DailyPrice, car.Description);
            }

            Car car1 = new Car()
            {
                BrandId = 2,
                ColorId = 3,
                ModelName = "Test Model",
                ModelYear = 2021,
                DailyPrice = 1850,
                Description = "Test Description"
            };
            string isCarAdded = carManager1.Add(car1).Message;
            Console.WriteLine("\nisCarAdded:" + isCarAdded);

            Console.WriteLine("\n---Car GetById(7)");
            var resultGetCarById = carManager1.GetById(7).Data;
            Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    resultGetCarById.CarId, resultGetCarById.BrandId, resultGetCarById.ColorId, resultGetCarById.ModelName, resultGetCarById.ModelYear, resultGetCarById.DailyPrice, resultGetCarById.Description);

            Color color1 = new Color() { ColorName = "Blue" };
            string isColorAdded = colorManager1.Add(color1).Message;
            Console.WriteLine("\nisColorAdded:" + isColorAdded);

            Console.WriteLine("\n---Color GetById(4)");
            var resultGetColorById = colorManager1.GetById(4).Data;
            Console.WriteLine("ColorId:{0}, ColorName:{1}", resultGetColorById.ColorId, resultGetColorById.ColorName);

            Brand brand1 = new Brand() { BrandName = "Audi" };
            string isBrandAdded = brandManager1.Add(brand1).Message;
            Console.WriteLine("\nisBrandAdded:" + isBrandAdded);

            Console.WriteLine("\n---Brand GetById(4)");
            var resultGetBrandById = brandManager1.GetById(4).Data;
            Console.WriteLine("BrandId:{0}, BrandName:{1}", resultGetBrandById.BrandId, resultGetBrandById.BrandName);

            car1.BrandId = 4;
            car1.ColorId = 4;
            car1.ModelName = "Test Model Update";
            car1.Description = "Test Description Update";
            string isCarUpdated = carManager1.Update(car1).Message;
            Console.WriteLine("\nisCarUpdated:" + isCarUpdated);

            Console.WriteLine("\n---Color GetById(7)");
            var resultGetCarById2 = carManager1.GetById(7).Data;
            Console.WriteLine("CarId:{0}, BrandId:{1}, ColorId:{2}, ModelName:{3}, ModelYear:{4}, DailyPrice:{5}, Description:{6}",
                    resultGetCarById2.CarId, resultGetCarById2.BrandId, resultGetCarById2.ColorId, resultGetCarById2.ModelName, resultGetCarById2.ModelYear, resultGetCarById2.DailyPrice, resultGetCarById2.Description);

            color1.ColorName = "Gray";
            string isColorUpdated = colorManager1.Update(color1).Message;
            Console.WriteLine("\nisColorUpdated:" + isColorUpdated);

            Console.WriteLine("\n---Color GetById(4)");
            var resultGetColorById2 = colorManager1.GetById(4).Data;
            Console.WriteLine("ColorId:{0}, ColorName:{1}", resultGetColorById2.ColorId, resultGetColorById2.ColorName);

            brand1.BrandName = "Toyota";
            string isBrandUpdated = brandManager1.Update(brand1).Message;
            Console.WriteLine("\nisBrandUpdated:" + isBrandUpdated);

            Console.WriteLine("\n---Brand GetById(4)");
            var resultGetbBrandById2 = brandManager1.GetById(4).Data;
            Console.WriteLine("BrandId:{0}, BrandName:{1}", resultGetbBrandById2.BrandId, resultGetbBrandById2.BrandName);

            string isCarDeleted = carManager1.Delete(car1).Message;
            Console.WriteLine("\nisCarDeleted:" + isCarDeleted);

            string isColorDeleted = colorManager1.Delete(color1).Message;
            Console.WriteLine("\nisColorDeleted:" + isColorDeleted);

            string isBrandDeleted = brandManager1.Delete(brand1).Message;
            Console.WriteLine("\nisBrandDeleted:" + isBrandDeleted);


            Console.WriteLine("\n---Car Not Valid Adding Error Message");
            Console.WriteLine(carManager1.Add(new Car() { CarId = 8, BrandId = 1, ColorId = 3, ModelName = "Test Model 2", ModelYear = 2018, DailyPrice = 800, Description = "T" }).Message);
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
