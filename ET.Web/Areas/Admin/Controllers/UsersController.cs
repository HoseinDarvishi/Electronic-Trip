using ET.Constracts.PermissionContracts;
using ET.Constracts.RoleConstracts;
using ET.Constracts.UserContracts;
using ET.Web.Auth;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   [Authorize]
   public class UsersController : Controller
   {
      private readonly IUserService _userService;
      private readonly IRoleService _roleService;

      #region Ctor
      public UsersController(IUserService userService , IRoleService roleService)
      {
         _userService = userService;
         _roleService = roleService;
      }
      #endregion

      #region List
      [AuthFilter(AppPermissions.ListUser)]
      public ActionResult Index(SearchUser search)
      {
         List<UserVM> users = _userService.GetAll(search);
         return View(users);
      }
      #endregion

      #region Register
      [AuthFilter(AppPermissions.AddUser)]
      public ViewResult Register() 
      {
         var register = new CreateUser { Roles = _roleService.GetAll(string.Empty) };
         return View(register); 
      }

      [HttpPost]
      [AuthFilter(AppPermissions.AddUser)]
      public ActionResult Register(CreateUser register)
      {
         if (!ModelState.IsValid) return View(register);

         var result = _userService.Register(register);

         TempData["Message"] = result.Message;

         return RedirectToAction("Index" , "Users",new {area="Admin"});
      }
      #endregion

      #region Edit
      [AuthFilter(AppPermissions.EditUser)]
      public ActionResult Edit(int id)
      {
         var user = _userService.GetById(id);
         user.Roles = _roleService.GetAll(string.Empty);
         return View(user);
      }

      [HttpPost]
      [AuthFilter(AppPermissions.EditUser)]
      public ActionResult Edit(EditUser edit)
      {
         if (!ModelState.IsValid) 
         {
            edit.Roles = _roleService.GetAll(string.Empty);
            return View(edit); 
         }

         var result = _userService.Edit(edit);

         TempData["Message"] = result.Message;

         if (result.IsSuccess) return RedirectToAction("Index", "Users", new { area = "Admin" });

         edit.Roles = _roleService.GetAll(string.Empty);

         return View(edit);
      } 
      #endregion

      #region Activation
      [AuthFilter(AppPermissions.ActivitionUser)]
      public ActionResult Active(int id)
      {
         var result = _userService.Active(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Users", new {area="Admin"});
      }

      [AuthFilter(AppPermissions.ActivitionUser)]
      public ActionResult DeActive(int id)
      {
         var result = _userService.DeActive(id);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Users", new { area = "Admin" });
      }
      #endregion
   }
}