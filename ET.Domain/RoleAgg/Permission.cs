using System.Collections.Generic;

namespace ET.Domain.RoleAgg
{
   public class Permission
   {
      #region Ctor
      private Permission() { }
      public Permission(string name, int code)
      {
         Name = name;
         Code = code;
      } 
      #endregion

      public int PermissionId { get; private set; }
      public string Name { get; private set; }
      public int Code { get; private set; }

      #region Relations
      public virtual List<Role_Permission> RolePermissions { get; private set; }
      #endregion
   }
}
