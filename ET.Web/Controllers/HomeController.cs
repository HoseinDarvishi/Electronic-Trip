using ET.Constracts.CarConstracts;
using ET.Constracts.RequestContracts;
using ET.Constracts.UserContracts;
using ET.Web.Auth;
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
         string refs = AuthHelper.AuthName;
         var sdad = AuthHelper.PermissionCodes;
         var sasd = AuthHelper.IsAuthenticate();

         var cars = _carService.GetAll(new SearchCar() , showAll:false);
         return View(cars);
      }
      #endregion

      #region SetRequest
      [Route("SetRequest")]
      [Authorize]
      public ActionResult SetRequest(int carId)
      {
         var user = _userService.GetByUserName(User.Identity.Name);

         if (user == null)
         {
            TempData["Message"] = "خطایی پیش آمده";
            return RedirectToAction("Index", "Home");
         }

         var car = _carService.GetDetails(carId);

         var newRequest = new AddRequest
         {
            CarId = car.CarId,
            CarName = car.CarName,
            UserId = user.UserId,
            FullName = user.FullName,
            DriverName = car.DriverName
         };

         return View(newRequest);
      }

      [Route("SetRequest")]
      [HttpPost]
      [Authorize]
      public ActionResult SetRequest(AddRequest request)
      {
         if (!ModelState.IsValid) return View(request);

         var result = _reqService.SetRequest(request);

         TempData["Message"] = result.Message;

         return RedirectToAction("Index", "Home");
      }
      #endregion
   }
}