using ET.Constracts.RequestContracts;
using ET.Data.Context;
using ET.Domain.RequestAgg;
using ET.Tools;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ET.Data.Repositories
{
   public class RequestRepository : IRequestRepository
   {
      private ETContext _context;

      #region Ctor
      public RequestRepository(ETContext context)
      {
         _context = context;
      } 
      #endregion

      public string AddRequest(AddRequest request)
      {
         var newRequest = new Request(request.UserId, request.CarId, request.Address, request.DetachCode);
         _context.Requests.Add(newRequest);
         Save();
         return newRequest.DetachCode;
      }

      public List<RequestVM> GetAll(SearchRequest search)
      {
         var query = _context.Requests
            .Include(r => r.Car)
            .Include(r => r.User)
            .Select(x => new RequestVM
            {
               RequestId = x.RequestId,
               StatusId = x.StatusId,
               DetachCode = x.DetachCode,
               Address = x.Address,
               RequestDateEN = x.RequestDate,
               CarId = x.CarId,
               UserId = x.UserId,
               CarName = x.Car.CarName,
               CarColor = x.Car.Color,
               CarModel = x.Car.Model,
               UserName = x.User.UserName,
            })
            .AsNoTracking();

         if (!string.IsNullOrWhiteSpace(search.DetachCode))
            query = query.Where(r => r.DetachCode == search.DetachCode);

         if (search.StatusId > 0)
            query = query.Where(r => r.StatusId == search.StatusId);

         var list = query.OrderByDescending(r => r.RequestId).ToList();

         list.ForEach(r => r.RequestDate = r.RequestDateEN.ToShamsi());

         return list;
      }

      public Request GetById(int id)
      {
         return _context.Requests.FirstOrDefault(x => x.RequestId == id);
      }

      public RequestVM GetDetailById(int id)
      {
         return _context.Requests
            .Include(r=>r.Car)
            .Include(r=>r.User)
            .Select(x => new RequestVM
            {
               RequestId = x.RequestId,
               StatusId = x.StatusId,
               DetachCode = x.DetachCode,
               Address = x.Address,
               RequestDate = x.RequestDate.ToShamsi(),
               CarId = x.CarId,
               UserId = x.UserId,
               CarName = x.Car.CarName,
               CarColor = x.Car.Color,
               CarModel = x.Car.Model,
               UserName = x.User.UserName,
            })
            .AsNoTracking()
            .FirstOrDefault(x => x.RequestId == id);
      }

      public int RequestCount(RequestStatuses status)
      {
         return _context.Requests.Where(x => x.StatusId == (int)status).Count();
      }

      public int RequestCount()
      {
         return _context.Requests.Count();
      }

      public void Save() => _context.SaveChanges();
   }
}
