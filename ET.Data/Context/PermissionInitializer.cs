using ET.Constracts.PermissionContracts;
using ET.Domain.RoleAgg;
using System.Data.Entity;

namespace ET.Data.Context
{
   public class PermissionInitializer : DropCreateDatabaseIfModelChanges<ETContext>
   {
      protected override void Seed(ETContext context)
      {
         var role = new Role("Admin");
         var permissions = AppPermissions.GetAll();

         permissions.ForEach(code => role.Permissions.Add(new Permission(code)));
         context.Roles.Add(role);
         context.SaveChanges();

         base.Seed(context);
      }
   }
}