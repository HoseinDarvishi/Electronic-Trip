using ET.Constracts;
using ET.Constracts.CarConstracts;
using ET.Data.Repositories;
using ET.Domain.CarAgg;
using ET.Tools;
using System.Collections.Generic;

namespace ET.Service.Services
{
   public class CarService : ICarService
   {
      private ICarRepository _carRepo = new CarRepository();

      public OperationResult EditCar(EditCar editCar)
      {
         var car = _carRepo.GetById(editCar.CarId);

         if (car == null) return new OperationResult().Failed(Messages.NotFound);

         if (_carRepo.IsExsist(c => c.CarName == editCar.CarName && c.Color == editCar.Color &&
            c.DriverId == editCar.DriverId && c.Model == editCar.Model && c.CarId != editCar.CarId))
         {
            return new OperationResult().Failed(Messages.ExsistCar);
         }

         car.Edit(editCar.CarName, editCar.Model, editCar.Speed, editCar.Color, editCar.DriverId);
         _carRepo.Save();
         return new OperationResult().Success(Messages.SuccessEditCar);
      }

      public List<CarVM> GetAll(SearchCar search)
      {
         return _carRepo.GetAll(search);
      }

      public OperationResult RegisterCar(CreateCar createCar)
      {
         if (_carRepo.IsExsist(c => c.CarName == createCar.CarName && c.Color == createCar.Color &&
            c.DriverId == createCar.DriverId && c.Model == createCar.Model))
         {
            return new OperationResult().Failed(Messages.ExsistCar);
         }
         _carRepo.AddCar(createCar);
         return new OperationResult().Success(Messages.SuccessRegisterCar);
      }

      public OperationResult Remove(int carId)
      {
         var car = _carRepo.GetById(carId);
         if (car == null) return new OperationResult().Failed(Messages.NotFound);
         car.Remove();
         _carRepo.Save();
         return new OperationResult().Success(Messages.Success);
      }

      public OperationResult Restore(int carId)
      {
         var car = _carRepo.GetById(carId);
         if (car == null) return new OperationResult().Failed(Messages.NotFound);
         car.Restore();
         _carRepo.Save();
         return new OperationResult().Success(Messages.Success);
      }
   }
}
