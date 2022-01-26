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
      public ViewResult Register() => View();

      [HttpPost]
      public ActionResult Register(RegisterUser register)
      {
         return View();
      }
      #endregion
   }
}