using ET.Domain.RoleAgg;
using System.Collections.Generic;
using System.Data.Entity;

namespace ET.Data.Context
{
   public class PermissionInitializer : DropCreateDatabaseIfModelChanges<ETContext>
   {
      protected override void Seed(ETContext context)
      {
         var permissions = new List<Permission>();
         permissions.ForEach(p => context.Permissions.Add(p));
         context.SaveChanges();
         base.Seed(context);
      }
   }
}
