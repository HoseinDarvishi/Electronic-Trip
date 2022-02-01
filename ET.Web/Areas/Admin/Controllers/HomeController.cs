using ET.Constracts.PermissionContracts;
using ET.Web.Auth;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   [Authorize]
   public class HomeController : Controller
   {
      [AuthFilter(AppPermissions.ListUser)]
      public ActionResult Index()
      {
         return View();
      }
   }
}