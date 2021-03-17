using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Color> _colors;
        List<Brand> _brands;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,ModelName="G63",ModelYear=2019,DailyPrice=3900,Description="AMG" },
                new Car{CarId=2,BrandId=1,ColorId=2,ModelName="E53",ModelYear=2020,DailyPrice=3000,Description="AMG" },
                new Car{CarId=3,BrandId=2,ColorId=1,ModelName="540i",ModelYear=2018,DailyPrice=3000,Description="xDrive M Sport" },
                new Car{CarId=4,BrandId=2,ColorId=3,ModelName="740d",ModelYear=2021,DailyPrice=3400,Description="xDrive Long M Excellence" },
                new Car{CarId=5,BrandId=3,ColorId=2,ModelName="S90",ModelYear=2019,DailyPrice=4000,Description="2.0 D D5 R-Design" },
                new Car{CarId=6,BrandId=3,ColorId=3,ModelName="XC90",ModelYear=2020,DailyPrice=5000,Description="2.0 B5 Inscription" }
            };

            _colors = new List<Color>
            {
                new Color{ColorId=1,ColorName="Black" },
                new Color{ColorId=2,ColorName="Red" },
                new Color{ColorId=3,ColorName="White" }
            };


            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Mercedes" },
                new Brand{BrandId=2,BrandName="BMW" },
                new Brand{BrandId=3,BrandName="Volvo" }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
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
    }
}
