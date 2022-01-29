using ET.Constracts.CarConstracts;
using ET.Constracts.UserContracts;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   public class CarsController : Controller
   {
      private readonly ICarService _carService;
      private readonly IUserService _userService;

      #region Ctor
      public CarsController(ICarService carService , IUserService userService)
      {
         _carService = carService;
         _userService = userService;
      }
      #endregion

      #region List
      public ActionResult Index(SearchCar search)
      {
         var cars = _carService.GetAll(search);
         return View(cars);
      }
      #endregion

      #region Activation
      public ActionResult Active(int id)
      {
         var result = _carService.Restore(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Cars", new { area = "Admin" });
      }

      public ActionResult DeActive(int id)
      {
         var result = _carService.Remove(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Cars", new { area = "Admin" });
      }
      #endregion

      #region Register
      public ActionResult Register() 
      {
         var drivers = _userService.GetAllDrivers();

         if(drivers.Count <= 0)
         {
            TempData["Message"] = "راننده ای در سیستم ثبت نشده است";
            return RedirectToAction("Index", "Cars", new { area = "Admin" });
         }

         var createCar = new CreateCar() { Drivers = drivers };

         return View(createCar); 
      }

      [HttpPost]
      public ActionResult Register(CreateCar car)
      {
         if (!ModelState.IsValid) 
         {
            car.Drivers = _userService.GetAllDrivers();
            return View(car); 
         }

         var result = _carService.RegisterCar(car);
         TempData["Message"] = result.Message;

         if (!result.IsSuccess)
         {
            car.Drivers = _userService.GetAllDrivers();
            return View(car); 
         }

         return RedirectToAction("Index", "Cars", new { area = "Admin" });
      }
      #endregion

      #region Edit
      public ActionResult Edit(int carId)
      {
         var car = _carService.GetForEdit(carId);
         car.Drivers = _userService.GetAllDrivers();
         return View(car);
      }

      [HttpPost]
      public ActionResult Edit(EditCar edit)
      {
         if(!ModelState.IsValid)
         {
            edit.Drivers = _userService.GetAllDrivers();
            return View(edit);
         }

         var result = _carService.EditCar(edit);

         TempData["Message"] = result.Message;

         if (!result.IsSuccess)
         {
            edit.Drivers = _userService.GetAllDrivers();
            return View(edit);
         }

         return RedirectToAction("Index", "Cars", new { area = "Admin" });
      }
      #endregion
   }
}