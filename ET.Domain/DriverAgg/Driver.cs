using ET.Domain.CarAgg;
using System;
using System.Collections.Generic;

namespace ET.Domain.DriverAgg
{
   public class Driver
   {
      private Driver() { }

      public Driver(string fullName, string age, int exprienceYears)
      {
         FullName = fullName;
         Age = age;
         ExprienceYears = exprienceYears;
         IsRemoved = false;
         RegisterDate = DateTime.Now;
      }

      public int DriverId { get; private set; }
      public string FullName { get; private set; }
      public string Age { get; private set; }
      public int ExprienceYears { get; private set; }
      public bool IsRemoved { get; private set; }
      public DateTime RegisterDate { get; private set; }

      #region Relations
      public virtual List<Car> Car { get; private set; }
      #endregion

      #region Edit
      public void Remove() => IsRemoved = true;

      public void Restore() => IsRemoved = false;

      public void Edit(string fullName, string age, int exprienceYears)
      {
         FullName = fullName;
         Age = age;
         ExprienceYears = exprienceYears;
      }
      #endregion
   }
}
