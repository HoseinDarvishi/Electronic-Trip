using ET.Constracts.RequestContracts;
using System.Collections.Generic;

namespace ET.Domain.RequestAgg
{
   public interface IRequestRepository
   {
      Request GetById(int id);
      RequestVM GetDetailById(int id);
      List<RequestVM> GetAll(SearchRequest search);
      string AddRequest(AddRequest request);
      void Save();
   }
}
