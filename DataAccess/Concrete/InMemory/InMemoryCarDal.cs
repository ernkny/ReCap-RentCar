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
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 100, ModelYear = "2010",Description="Sahibinden Temiz 2010 model Araba" },
                new Car { CarId = 2, BrandId = 2, ColorId = 4, DailyPrice = 200, ModelYear = "2012",Description="Sahibinden Temiz 2012 model Araba" },
                new Car { CarId = 3, BrandId = 2, ColorId = 3, DailyPrice = 150, ModelYear = "1998",Description="Sahibinden Temiz 1998 model Araba" },
                new Car { CarId = 4, BrandId = 3, ColorId = 2, DailyPrice = 100, ModelYear = "2019",Description="Sahibinden Temiz 2019 model Araba" },
                new Car { CarId = 5, BrandId = 1, ColorId = 1, DailyPrice = 3000, ModelYear = "2018",Description="Sahibinden Temiz 2018 model Araba"} 
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           
           Car CarToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAllByBrandId(int categoryId)
        {
            
            return _cars.Where(c => c.BrandId == categoryId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
