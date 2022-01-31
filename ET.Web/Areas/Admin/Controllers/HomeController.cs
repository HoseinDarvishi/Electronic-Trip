using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   [Authorize]
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }
   }
}