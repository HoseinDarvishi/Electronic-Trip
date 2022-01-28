using System.Data.Entity.Migrations;

namespace ET.Data.Migrations
{
   internal sealed class Configuration : DbMigrationsConfiguration<Context.ETContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = false;
         ContextKey = "ET.Data.Context.ETContext";
      }

      protected override void Seed(Context.ETContext context)
      {

      }
   }
}
