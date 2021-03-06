using ET.Constracts.CarConstracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ET.Domain.CarAgg
{
   public interface ICarRepository
   {
      List<CarVM> GetAll(SearchCar search , bool showAll);
      CarVM GetDetailsById(int carId);
      Car GetById(int carId);
      EditCar GetForEdit(int carId);
      List<CarVM> GetByName(string carName);
      void AddCar(CreateCar car);
      bool IsExsist(int id);
      bool IsExsist(string carName);
      bool IsExsist(Expression<Func<Car,bool>> expression);
      int CarCount();
      void Save();
   }
}
