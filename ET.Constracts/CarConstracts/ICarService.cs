using System.Collections.Generic;

namespace ET.Constracts.CarConstracts
{
   public interface ICarService
   {
      List<CarVM> GetAll(SearchCar search);
      OperationResult RegisterCar(CreateCar createCar);
      OperationResult EditCar(EditCar editCar);
      OperationResult Remove(int carId);
      OperationResult Restore(int carId);
   }
}