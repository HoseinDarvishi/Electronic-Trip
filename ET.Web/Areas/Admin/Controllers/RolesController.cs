using ET.Constracts.PermissionContracts;
using ET.Constracts.RoleConstracts;
using ET.Web.Auth;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   //[RoutePrefix("Roles")]
   [Authorize]
   public class RolesController : Controller
   {
      private readonly IRoleService _roleService;
      private readonly IPermissionExposer _permExposer;

      #region Ctor
      public RolesController(IRoleService roleService , IPermissionExposer permExposer)
      {
         _roleService = roleService;
         _permExposer = permExposer;
      }
      #endregion

      #region List
      [AuthFilter(AppPermissions.ListRole)]
      public ActionResult Index(string roleTitle)
      {
         var roles = _roleService.GetAll(roleTitle);
         return View(roles);
      }
      #endregion

      #region Craete
      [AuthFilter(AppPermissions.AddRole)]
      public ViewResult Create() => View();

      [HttpPost]
      [AuthFilter(AppPermissions.AddRole)]
      public ActionResult Create(CreateRole role)
      {
         if (!ModelState.IsValid) return View(role);

         var result = _roleService.AddRole(role.RoleTitle);

         TempData["Message"] = result.Message;

         return RedirectToAction("Index", "Roles", new { area = "Admin" });
      }
      #endregion

      #region Edit
      [AuthFilter(AppPermissions.EditRole)]
      public ActionResult Edit(int id)
      {
         var role = _roleService.GetById(id);
         return View(role);
      }

      [HttpPost]
      [AuthFilter(AppPermissions.EditRole)]
      public ActionResult Edit(EditRole role)
      {
         if (!ModelState.IsValid) return View(role);

         var result = _roleService.EditRole(role);
         TempData["Message"] = result.Message;

         return RedirectToAction("Index", "Roles", new { area = "Admin" });
      }
      #endregion

      #region SetPermissions
      [AuthFilter(AppPermissions.SetPermission)]
      public ActionResult SetPermissions(int id)
      {
         var setPerms = new SetPermissions
         {
            RoleId = id,
            MappedPermissions = _permExposer.Expose()
         };
         return View(setPerms);
      }

      [HttpPost]
      [AuthFilter(AppPermissions.SetPermission)]
      public ActionResult SetPermissions(SetPermissions setPermissions)
      {
         var result = _roleService.SetPermissions(setPermissions);
         TempData["Message"] = result.Message;
         return RedirectToAction("Index", "Roles", new { area = "Admin" });
      }
      #endregion
   }
}