using System.Collections.Generic;

namespace ET.Constracts.RoleConstracts
{
   public interface IRoleService
   {
      List<RoleVM> GetAll(string roleTitle);
      OperationResult AddRole(string roleTitle);
      OperationResult EditRole(EditRole role);
      
      // TODO : SET PERMISSIONS 
   }
}