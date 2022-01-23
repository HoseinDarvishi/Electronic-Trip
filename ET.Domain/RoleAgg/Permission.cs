using System.Collections.Generic;

namespace ET.Domain.RoleAgg
{
   public class Permission
   {
      #region Ctor
      private Permission() {}

      public Permission(int code)
      {
         Code = code;
      }

      public Permission(int code, string name, int roleId)
      {
         Code = code;
         Name = name;
         RoleId = roleId;
      }
      #endregion

      public int PermissionId { get; private set; }
      public int Code { get; private set; }
      public string Name { get; private set; }
      public int RoleId { get;  private set; }

      #region Relations
      public Role Role { get; private set; } 
      #endregion
   }
}
