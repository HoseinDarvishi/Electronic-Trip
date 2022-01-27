using ET.Constracts.RoleConstracts;
using ET.Constracts.UserContracts;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   public class UsersController : Controller
   {
      private IUserService _userService;
      private IRoleService _roleService;

      #region Ctor
      public UsersController(IUserService userService , IRoleService roleService)
      {
         _userService = userService;
         _roleService = roleService;
      }
      #endregion

      #region List
      public ActionResult Index(SearchUser search)
      {
         List<UserVM> users = _userService.GetAll(search);
         return View(users);
      }
      #endregion

      #region Register
      public ViewResult Register() 
      {
         var register = new RegisterUser { Roles = _roleService.GetAll(string.Empty) };
         return View(register); 
      }

      [HttpPost]
      public ActionResult Register(RegisterUser register)
      {
         if (!ModelState.IsValid) return View(register);

         var result = _userService.Register(register);

         TempData["Message"] = result.Message;

         return RedirectToAction("Index" , "Users",new {area="Admin"});
      }
      #endregion

      #region Activation
      public ActionResult Active(int id)
      {
         var result = _userService.Active(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Users", new {area="Admin"});
      }

      public ActionResult DeActive(int id)
      {
         var result = _userService.DeActive(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Users", new { area = "Admin" });
      }
      #endregion
   }
}