using ET.Constracts.PermissionContracts;
using ET.Constracts.ReportContracts;
using ET.Web.Auth;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   [Authorize]
   public class HomeController : Controller
   {
      private readonly IReportService _reportService;

      #region Ctor
      public HomeController(IReportService reportService)
      {
         _reportService = reportService;
      } 
      #endregion

      [AuthFilter(AppPermissions.ListUser)]
      public ActionResult Index()
      {
         var reportAgg = new Dictionary<string, int>
         {
            {"تعداد کل کاربران" , _reportService.UserCount },
            {"تعداد کاربران غیرفعال" , _reportService.DeActiveUserCount},
            {"تعداد خودروها" , _reportService.CarCount},
            {"تعداد راننده ها" , _reportService.DriverCount},
            {"تعداد راننده های غیرفعال" , _reportService.DeActiveDriverCount},
            {"تعداد کل درخواستها" , _reportService.RequestCount},
            {"تعداد درخواستهای موفق " , _reportService.DoneRequestCont},
            {"تعداد درخواستهای در انتظار" , _reportService.WaitingRequestCont},
            {"تعداد درخواستهای لغو شده" , _reportService.CancelRequestCount}
         };
         return View(reportAgg);
      }
   }
}