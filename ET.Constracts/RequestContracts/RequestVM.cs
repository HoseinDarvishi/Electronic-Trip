namespace ET.Constracts.RequestContracts
{
   public class RequestVM
   {
      public int RequestId { get; set; }
      public int UserId { get; set; }
      public string UserName { get; set; }
      public int CarId { get; set; }
      public string CarName { get; set; }
      public int CarModel { get; set; }
      public string CarColor { get; set; }
      public int StatusId { get; set; }
      public string Address { get; set; }
      public string DetachCode { get; set; }
      public string RequestDate { get; set; }
   }
}
