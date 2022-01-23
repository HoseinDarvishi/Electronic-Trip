namespace ET.Domain.RoleAgg
{
   public class Role_Permission
   {
      public int RoleId { get; set; }
      public int PermissionId { get; set; }

      public virtual Permission Permission { get; private set; }
      public virtual Role Role { get; private set; }
   }
}
