using ET.Constracts.RoleConstracts;
using ET.Constracts.UserContracts;
using ET.Web.Auth;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ET.Web.Controllers
{
   public class AccountController : Controller
   {
      private readonly IUserService _userService;
      private readonly IRoleService _roleService;

      #region Ctor
      public AccountController(IUserService userService, IRoleService roleService)
      {
         _userService = userService;
         _roleService = roleService;
      }
      #endregion

      #region Register
      [Route("Register")]
      public ActionResult Register() => View();

      [HttpPost]
      [Route("Register")]
      public ActionResult Register([Bind(Exclude = "RoleId")] RegisterUser register)
      {
         if (!ModelState.IsValid) return View(register);

         var registerVM = new CreateUser
         {
            FullName = register.FullName,
            UserName = register.UserName,
            Email = register.Email,
            RoleId = _roleService.GetByRoleTitle("User").RoleId,
            Password = register.Password,
            RePassword = register.RePassword
         };

         var result = _userService.Register(registerVM);

         TempData["Message"] = result.Message;

         if (!result.IsSuccess)
            return View(register);

         TempData["Message"] += Environment.NewLine + "اکنون وارد شوید";
         return RedirectToAction("Login", "Account");
      }
      #endregion

      #region Login
      [Route("Login")]
      public ViewResult Login() => View();

      [Route("Login")]
      [HttpPost]
      public ActionResult Login(LoginUser login)
      {
         if (!ModelState.IsValid) return View(login);

         var result = _userService.Login(login);

         TempData["Message"] = result.Message;

         if (!result.IsSuccess)
            return View(login);

         #region Set Auth Cookies
         var permissionCodes = _roleService.GetPermissionCodesByUserName(login.UserName);

         if (permissionCodes != null)
         {
            string serializePermissions = JsonConvert.SerializeObject(permissionCodes);

            var permissionCookie = new HttpCookie("PCl0-AIOP1") { Secure = true , HttpOnly = true};
            permissionCookie.Value = serializePermissions.Protect("UserPermCookie");
            permissionCookie.Expires = DateTime.Now.AddDays(30);

            Response.Cookies.Add(permissionCookie);
         }

         FormsAuthentication.SetAuthCookie($"{login.UserName}", true, "/"); 
         #endregion

         return RedirectToAction("Index", "Home");
      }
      #endregion

      #region Logout
      [Route("Logout")]
      public RedirectToRouteResult Logout()
      {
         if (User.Identity.IsAuthenticated)
            FormsAuthentication.SignOut();
         return RedirectToAction("Index", "Home");
      }
      #endregion
   }
}