﻿using ET.Constracts.CarConstracts;
using ET.Data.Context;
using ET.Domain.CarAgg;
using ET.Tools;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ET.Data.Repositories
{
   public class CarRepository : ICarRepository
   {
      private ETContext _context = new ETContext();

      public void AddCar(CreateCar car)
      {
         var newCar = new Car(car.CarName, car.Model, car.Speed, car.DriverId);
         _context.Cars.Add(newCar);
         Save();
      }

      public List<CarVM> GetAll(SearchCar search)
      {
         var query = _context.Cars
            .Where(x => !x.IsRemoved)
            .Include(x => x.Driver)
            .Select(x => new CarVM
            {
               CarId = x.CarId,
               CarName = x.CarName,
               Model = x.Model,
               Speed = x.Speed,
               IsRemoved = x.IsRemoved,
               RegisterCar = x.RegisterDate.ToShamsi(),
               DriverId = x.DriverId,
               DriverName = x.Driver.FullName
            })
            .AsNoTracking();

         if (!search.ShowWithRemoved)
            query = query.Where(x => !x.IsRemoved);

         if (!string.IsNullOrWhiteSpace(search.CarName))
            query = query.Where(x => x.CarName.Contains(search.CarName));

         if (search.DriverId > 0)
            query = query.Where(x => x.DriverId == search.DriverId);

         if (search.MinModel > 0)
            query = query.Where(x => x.Model > search.MinModel);

         return query.OrderByDescending(x => x.CarId).ToList();
      }

      public CarVM GetById(int carId)
      {
         return _context.Cars.Select(x => new CarVM
         {
            CarId = x.CarId,
            CarName = x.CarName,
            Model = x.Model,
            Speed = x.Speed,
            IsRemoved = x.IsRemoved,
            RegisterCar = x.RegisterDate.ToShamsi(),
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
               RegisterCar = x.RegisterDate.ToShamsi(),
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
   }
}