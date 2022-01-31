namespace ET.Constracts.RequestContracts
{
   public class AddRequest
   {
      public int UserId { get; set; }
      public int CarId { get; set; }
      public string CarName { get; set; }
      public string DriverName { get; set; }
      public string FullName { get; set; }
      public string DetachCode { get; set; }
      public string Address { get; set; }
   }
}
