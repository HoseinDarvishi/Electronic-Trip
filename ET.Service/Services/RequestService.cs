using ET.Constracts;
using ET.Constracts.RequestContracts;
using ET.Domain.RequestAgg;
using ET.Tools;
using System.Collections.Generic;

namespace ET.Service.Services
{
   public class RequestService : IRequestService
   {
      private IRequestRepository _requestRepo;

      #region Ctor
      public RequestService(IRequestRepository requestRepository)
      {
         _requestRepo = requestRepository;
      } 
      #endregion

      public OperationResult CancelRequest(int requestId)
      {
         var request = _requestRepo.GetById(requestId);
         if (request == null) return new OperationResult().Failed(Messages.NotFound);

         request.Cancel();
         _requestRepo.Save();
         return new OperationResult().Success(Messages.Success);
      }

      public OperationResult DoneRequest(int requestId)
      {
         var request = _requestRepo.GetById(requestId);
         if (request == null) return new OperationResult().Failed(Messages.NotFound);

         request.Done();
         _requestRepo.Save();
         return new OperationResult().Success(Messages.Success);
      }

      public OperationResult WaitRequest(int requestId)
      {
         var request = _requestRepo.GetById(requestId);
         if (request == null) return new OperationResult().Failed(Messages.NotFound);

         request.Wait();
         _requestRepo.Save();
         return new OperationResult().Success(Messages.Success);
      }

      public List<RequestVM> GetAll(SearchRequest search)
      {
         return _requestRepo.GetAll(search);
      }

      public OperationResult SetRequest(AddRequest request)
      {
         request.DetachCode = Generator.GenerateUniqCode();
         string  detachCode = _requestRepo.AddRequest(request);
         return new OperationResult().Success($"سفارش با کد رهگیری {detachCode} ثبت شد");
      }
   }
}