using ET.Constracts.UserContracts;
using System.Collections.Generic;

namespace ET.Constracts.CarConstracts
{
   public class EditCar
   {
      public int CarId { get; set; }
      public string CarName { get; set; }
      public string DriverName { get; set; }
      public int Model { get; set; }
      public int Speed { get; set; }
      public string Color { get; set; }
      public int DriverId { get; set; }

      public List<UserVM> Drivers { get; set; } = new List<UserVM>();
   }
}