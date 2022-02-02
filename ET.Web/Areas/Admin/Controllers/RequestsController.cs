using ET.Constracts.PermissionContracts;
using ET.Constracts.RequestContracts;
using ET.Web.Auth;
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
      [AuthFilter(AppPermissions.ListRequest)]
      public ActionResult Index(SearchRequest search)
      {
         var reqs = _reqService.GetAll(search);
         return View(reqs);
      }
      #endregion

      #region Status
      [AuthFilter(AppPermissions.DoneRequest)]
      public ActionResult Done(int id)
      {
         var result = _reqService.DoneRequest(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Requests", new { area = "Admin" });
      }

      [AuthFilter(AppPermissions.CancelRequest)]
      public ActionResult Cancel(int id)
      {
         var result = _reqService.CancelRequest(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Requests", new { area = "Admin" });
      }

      [AuthFilter(AppPermissions.WaitRequest)]
      public ActionResult Wait(int id)
      {
         var result = _reqService.WaitRequest(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Requests", new { area = "Admin" });
      }
      #endregion
   }
}