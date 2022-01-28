using ET.Constracts.CarConstracts;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   public class CarsController : Controller
   {
      private readonly ICarService _carService;

      #region Ctor
      public CarsController(ICarService carService)
      {
         _carService = carService;
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
      
      #endregion
   }
}