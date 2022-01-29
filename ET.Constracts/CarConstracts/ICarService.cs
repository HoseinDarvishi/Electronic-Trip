using System.Collections.Generic;

namespace ET.Constracts.CarConstracts
{
   public interface ICarService
   {
      List<CarVM> GetAll(SearchCar search);
      EditCar GetForEdit(int carId);
      OperationResult RegisterCar(CreateCar createCar);
      OperationResult EditCar(EditCar editCar);
      OperationResult Remove(int carId);
      OperationResult Restore(int carId);
   }
}