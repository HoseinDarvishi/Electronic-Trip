using ET.Domain.UserAgg;
using System.Collections.Generic;

namespace ET.Domain.RoleAgg
{
   public class Role
   {
      #region Ctor
      private Role() { }
      public Role(string roleTitle) => RoleTitle = roleTitle; 
      #endregion

      public int RoleId { get; private set; }
      public string RoleTitle { get; private set; }

      #region Relations
      public virtual List<User> Users { get; private set; }
      public virtual List<Permission> Permissions { get; set; }
      #endregion

      #region Edit
      public void Edit(string roleTitle) => RoleTitle = roleTitle;
      #endregion
   }
}