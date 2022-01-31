using ET.Constracts.CarConstracts;
using ET.Constracts.RequestContracts;
using ET.Constracts.UserContracts;
using System.Web.Mvc;

namespace ET.Web.Controllers
{
   public class HomeController : Controller
   {
      private readonly ICarService _carService;
      private readonly IUserService _userService;
      private readonly IRequestService _reqService;

      #region Ctor
      public HomeController(ICarService carService , IUserService userService , IRequestService requestService)
      {
         _carService = carService;
         _userService = userService;
         _reqService = requestService;
      }
      #endregion

      #region Index-CarList
      public ActionResult Index()
      {
         var cars = _carService.GetAll(new SearchCar() , showAll:false);
         return View(cars);
      } 
      #endregion
   }
}