using System;

namespace ET.Domain.CarAgg
{
   public class Car
   {
      #region Ctor
      private Car() { }

      public Car(string carName, int model, int speed)
      {
         CarName = carName;
         Model = model;
         Speed = speed;
         IsRemoved = false;
         RegisterDate = DateTime.Now;
      }
      #endregion

      public int CarId { get; private set; }
      public string CarName { get; private set; }
      public int Model { get; private set; }
      public int Speed { get; private set; }
      public DateTime RegisterDate { get; private set; }
      public bool IsRemoved { get; private set; }

      #region Relations

      #endregion

      #region Edit
      public void Remove() => IsRemoved = true;
      public void Restor() => IsRemoved = false;
      #endregion
   }
}
