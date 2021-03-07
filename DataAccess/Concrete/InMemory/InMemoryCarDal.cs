using DataAccess.Abstract;
using Entities.Concrete;
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
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,CarDailyPrice=150000,CarModelYear=1932,CarDescription="Classic Car" },
                new Car{CarId=2,BrandId=2,ColorId=2,CarDailyPrice=100000,CarModelYear=2016,CarDescription="Sports Car" },
                new Car{CarId=3,BrandId=3,ColorId=3,CarDailyPrice=650000,CarModelYear=2021,CarDescription="Jeep Car" }
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {

            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.CarDailyPrice = car.CarDailyPrice;
            carToUpdate.CarModelYear = car.CarModelYear;
            carToUpdate.CarDescription = car.CarDescription;

        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }



       

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }

}
