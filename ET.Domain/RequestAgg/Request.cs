using ET.Domain.CarAgg;
using ET.Domain.UserAgg;
using System;

namespace ET.Domain.RequestAgg
{
   public class Request
   {
      #region Ctor
      private Request() { }

      public Request(int userId, int carId, string address, string detachCode)
      {
         UserId = userId;
         CarId = carId;
         StatusId = (int)RequestStatuses.Waiting;
         Address = address;
         DetachCode = detachCode;
         RequestDate = DateTime.Now;
      } 
      #endregion

      public int RequestId { get; private set; }
      public int UserId { get; private set; }
      public int CarId { get; private set; }
      public int StatusId { get; private set; }
      public string Address { get; private set; }
      public string DetachCode { get; private set; }
      public DateTime RequestDate { get; private set; }

      #region Relations
      public virtual User User { get; private set; }
      public virtual Car Car { get; private set; }
      #endregion

      #region Edit
      public void Cancel() => StatusId = (int)RequestStatuses.Canceled;

      public void Wait() => StatusId = (int)RequestStatuses.Waiting;

      public void Done() => StatusId = (int)RequestStatuses.Done;

      public int Status() => StatusId;
      #endregion
   }
}
