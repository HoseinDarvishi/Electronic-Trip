using ET.Constracts.RequestContracts;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   public class RequestsController : Controller
   {
      private readonly IRequestService _reqService;

      #region Ctor
      public RequestsController(IRequestService reqService)
      {
         _reqService = reqService;
      }
      #endregion

      #region List
      public ActionResult Index(SearchRequest search)
      {
         var reqs = _reqService.GetAll(search);
         return View(reqs);
      } 
      #endregion
   }
}