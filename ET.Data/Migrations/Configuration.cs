namespace ET.Data.Migrations
{
   using ET.Constracts.PermissionContracts;
   using ET.Domain.RoleAgg;
   using System;
   using System.Data.Entity;
   using System.Data.Entity.Migrations;
   using System.Linq;

   internal sealed class Configuration : DbMigrationsConfiguration<Context.ETContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = true;
         ContextKey = "ET.Data.Context.ETContext";
      }

      protected override void Seed(Context.ETContext context)
      {

      }
   }
}
