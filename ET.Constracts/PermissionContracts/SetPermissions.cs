using System.Collections.Generic;

namespace ET.Constracts.PermissionContracts
{
   public class SetPermissions
   {
      public int RoleId { get; set; }
      public List<PermissionVM> Permissions { get; set; }
   }
}
