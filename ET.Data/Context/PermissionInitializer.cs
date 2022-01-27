using ET.Constracts.PermissionContracts;
using ET.Domain.RoleAgg;
using System.Collections.Generic;
using System.Data.Entity;

namespace ET.Data.Context
{
   public class PermissionInitializer : CreateDatabaseIfNotExists<ETContext>
   {
      protected override void Seed(ETContext context)
      {
         var roleAdmin = new Role("Admin");
         var roleUser = new Role("User");

         var permissions = AppPermissions.GetAll();

         permissions.ForEach(code => roleAdmin.Permissions.Add(new Permission(code)));
         context.Roles.Add(roleAdmin);

         context.Roles.Add(roleUser);

         context.SaveChanges();

         base.Seed(context);
      }
   }
}