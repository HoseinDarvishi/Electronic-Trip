using ET.Domain.DriverAgg;
using System;

namespace ET.Domain.CarAgg
{
   public class Car
   {
      #region Ctor
      private Car() { }

      public Car(string carName, int model, int speed,int driverId)
      {
         CarName = carName;
         Model = model;
         Speed = speed;
         DriverId = driverId;
         IsRemoved = false;
         RegisterDate = DateTime.Now;
      }
      #endregion

      public int CarId { get; private set; }
      public string CarName { get; private set; }
      public int Model { get; private set; }
      public int Speed { get; private set; }
      public int DriverId { get; private set; }
      public DateTime RegisterDate { get; private set; }
      public bool IsRemoved { get; private set; }

      #region Relations
      public virtual Driver Driver { get; private set; }
      #endregion

      #region Edit
      public void Remove() => IsRemoved = true;

      public void Restor() => IsRemoved = false;

      public void Edit(string carName, int model, int speed, int driverId)
      {
         CarName = carName;
         Model = model;
         Speed = speed;
         DriverId = driverId;
      }
      #endregion
   }
}
