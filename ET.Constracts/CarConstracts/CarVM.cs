namespace ET.Constracts.CarConstracts
{
   public class CarVM
   {
      public int CarId { get; set; }
      public string CarName { get; set; }
      public string RegisterCar { get; set; }
      public int Model { get; set; }
      public int Speed { get; set; }
      public string Color { get; set; }
      public int DriverId { get; set; }
      public string DriverName { get; set; }
      public bool IsRemoved { get; set; }
   }
}