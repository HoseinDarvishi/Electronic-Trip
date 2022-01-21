using ET.Constracts.CarConstracts;
using System.Collections.Generic;

namespace ET.Domain.CarAgg
{
   public interface ICarRepository
   {
      List<CarVM> GetAll(SearchCar search);
      CarVM GetById(int carId);
      List<CarVM> GetByName(string carName);
      void AddCar(CreateCar car);
      bool IsExsist(int id);
      bool IsExsist(string carName);
   }
}
