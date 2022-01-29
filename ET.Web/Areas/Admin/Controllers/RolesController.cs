using ET.Constracts.RoleConstracts;
using System.Web.Mvc;

namespace ET.Web.Areas.Admin.Controllers
{
   public class RolesController : Controller
   {
      private readonly IRoleService _roleService;

      #region Ctor
      public RolesController(IRoleService roleService)
      {
         _roleService = roleService;
      }
      #endregion

      #region List
      public ActionResult Index(string roleTitle)
      {
         var roles = _roleService.GetAll(roleTitle);
         return View(roles);
      }
      #endregion

      #region Craete
      public ViewResult Create() => View();

      [HttpPost]
      public ActionResult Create(CreateRole role)
      {
         if (!ModelState.IsValid) return View(role);

         var result = _roleService.AddRole(role.RoleTitle);

         TempData["Message"] = result.Message;

         return RedirectToAction("Index", "Roles", new { area = "Admin" });
      }
      #endregion

      #region Edit
      public ActionResult Edit(int id)
      {
         var role = _roleService.GetById(id);
         return View(role);
      }

      [HttpPost]
      public ActionResult Edit(EditRole role)
      {
         if (!ModelState.IsValid) return View(role);

         var result = _roleService.EditRole(role);
         TempData["Message"] = result.Message;

         return RedirectToAction("Index", "Roles", new { area = "Admin" });
      }
      #endregion
   }
}