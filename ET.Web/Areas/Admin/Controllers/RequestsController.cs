using ET.Constracts.RequestContracts;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   [Authorize]
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

      #region Status
      public ActionResult Done(int id)
      {
         var result = _reqService.DoneRequest(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Requests", new { area = "Admin" });
      }

      public ActionResult Cancel(int id)
      {
         var result = _reqService.CancelRequest(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Requests", new { area = "Admin" });
      }

      public ActionResult Wait(int id)
      {
         var result = _reqService.WaitRequest(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Requests", new { area = "Admin" });
      }
      #endregion
   }
}