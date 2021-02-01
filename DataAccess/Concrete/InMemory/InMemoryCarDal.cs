using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Color> _color = new List<Color>
        {
            new Color{ColorId=1,ColorName="Mavi"},
            new Color{ColorId=2,ColorName="Beyaz"}
        };
        List<Brand> _brand = new List<Brand>
        {
            new Brand{BrandId=1,BrandName="Mercedes"},
            new Brand{BrandId=2,BrandName="Audi"}
        };
        List<Car> _car = new List<Car>
        {
            new Car{Id=1,ColorId=1,BrandId=1,DailyPrice=100,ModelYear=2019,Description="kirli"},
            new Car{Id=2,ColorId=2,BrandId=1,DailyPrice=200,ModelYear=2020,Description="yarıtemiz"},
            new Car{Id=3,ColorId=2,BrandId=2,DailyPrice=300,ModelYear=2021,Description="Temiz"}
        };

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(p => p.Id==car.Id);
            _car.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetById(int carId)
        {
            return _car.Where(p => p.Id==carId).ToList();
            
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(p => p.Id==car.Id);
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;

        }
    }
}
