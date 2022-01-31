using ET.Constracts.PermissionContracts;
using System.Collections.Generic;

namespace ET.Constracts.RoleConstracts
{
   public interface IRoleService
   {
      List<RoleVM> GetAll(string roleTitle);
      EditRole GetById(int id);
      RoleVM GetByRoleTitle(string roleTitle);
      OperationResult AddRole(string roleTitle);
      OperationResult EditRole(EditRole role);
      OperationResult SetPermissions(SetPermissions permissions);
      string GetNameById(int id);
   }
}