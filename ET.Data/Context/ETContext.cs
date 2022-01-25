using ET.Data.Mappings;
using ET.Data.Migrations;
using ET.Domain.CarAgg;
using ET.Domain.RequestAgg;
using ET.Domain.RoleAgg;
using ET.Domain.UserAgg;
using System.Data.Entity;

namespace ET.Data.Context
{
   public class ETContext : DbContext
   {
      public ETContext() : base("Data Source=.\\SQL2019;Initial Catalog=ElekTrip;Integrated Security=True;") 
      {
         Database.SetInitializer(new MigrateDatabaseToLatestVersion<ETContext, Configuration>());
      }
      
      public virtual DbSet<User> Users { get; set; }
      public virtual DbSet<Car> Cars { get; set; }
      public virtual DbSet<Role> Roles { get; set; }
      public virtual DbSet<Permission> Permissions { get; set; }
      public virtual DbSet<Request> Requests { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Configurations.AddFromAssembly(typeof(UserMapping).Assembly);
         base.OnModelCreating(modelBuilder);
      }
   }
}