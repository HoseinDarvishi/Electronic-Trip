using ET.Constracts.CarConstracts;
using ET.Data.Context;
using ET.Domain.CarAgg;
using ET.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ET.Data.Repositories
{
   public class CarRepository : ICarRepository
   {
      private ETContext _context;

      #region Ctor
      public CarRepository(ETContext context)
      {
         _context = context;
      }
      #endregion

      public void AddCar(CreateCar car)
      {
         var newCar = new Car(car.CarName, car.Model, car.Speed, car.Color, car.DriverId);
         _context.Cars.Add(newCar);
         Save();
      }

      public List<CarVM> GetAll(SearchCar search, bool showAll)
      {
         var query = _context.Cars
            .Include(x => x.Driver)
            .Where(x=>x.Driver.IsActive)
            .Select(x => new CarVM
            {
               CarId = x.CarId,
               CarName = x.CarName,
               Model = x.Model,
               Speed = x.Speed,
               Color = x.Color,
               IsRemoved = x.IsRemoved,
               RegisterDateEN = x.RegisterDate,
               DriverId = x.DriverId,
               DriverName = x.Driver.FullName
            }).AsNoTracking(); 

         if (!showAll)
            query = query.Where(x => !x.IsRemoved);

         if (!string.IsNullOrWhiteSpace(search.CarName))
            query = query.Where(x => x.CarName.Contains(search.CarName));

         if (search.DriverId > 0)
            query = query.Where(x => x.DriverId == search.DriverId);

         if (search.MinModel > 0)
            query = query.Where(x => x.Model > search.MinModel);

         return query.OrderByDescending(x=>x.CarId).ToList();
      }

      public CarVM GetDetailsById(int carId)
      {
         return _context.Cars.Select(x => new CarVM
         {
            CarId = x.CarId,
            CarName = x.CarName,
            Model = x.Model,
            Speed = x.Speed,
            IsRemoved = x.IsRemoved,
            RegisterDate = x.RegisterDate.ToShamsi(),
            DriverId = x.DriverId,
            DriverName = x.Driver.FullName
         })
         .AsNoTracking()
         .FirstOrDefault(x => x.CarId == carId);
      }

      public List<CarVM> GetByName(string carName)
      {
         return _context.Cars
            .Where(x => x.CarName == carName)
            .Select(x => new CarVM
            {
               CarId = x.CarId,
               CarName = x.CarName,
               Model = x.Model,
               Speed = x.Speed,
               IsRemoved = x.IsRemoved,
               RegisterDate = x.RegisterDate.ToShamsi(),
               Color = x.Color,
               DriverId = x.DriverId,
               DriverName = x.Driver.FullName
            })
            .AsNoTracking()
            .ToList();
      }

      public bool IsExsist(int id)
      {
         return _context.Cars.Any(x => x.CarId == id);
      }

      public bool IsExsist(string carName)
      {
         return _context.Cars.Any(x => x.CarName == carName);
      }

      public void Save() => _context.SaveChanges();

      public Car GetById(int carId)
      {
         return _context.Cars.Find(carId);
      }

      public bool IsExsist(Expression<Func<Car, bool>> expression)
      {
         return _context.Cars.Any(expression);
      }

      public EditCar GetForEdit(int carId)
      {
         return _context.Cars
            .Select(x => new EditCar
            {
               CarId = x.CarId,
               CarName = x.CarName,
               Color = x.Color,
               Speed = x.Speed,
               Model = x.Model,
               DriverId = x.DriverId
            })
            .AsNoTracking()
            .FirstOrDefault(x => x.CarId == carId);
      }
   }
}
