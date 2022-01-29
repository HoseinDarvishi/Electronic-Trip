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

      public ActionResult Index(string roleTitle)
      {
         var roles = _roleService.GetAll(roleTitle);
         return View(roles);
      }
   }
}