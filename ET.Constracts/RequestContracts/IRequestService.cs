using System.Collections.Generic;

namespace ET.Constracts.RequestContracts
{
   public interface IRequestService
   {
      List<RequestVM> GetAll(SearchRequest search);
      OperationResult SetRequest(AddRequest request);
      OperationResult CancelRequest(int requestId);
      OperationResult DoneRequest(int requestId);
   }
}
