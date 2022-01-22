using ET.Data.Mappings;
using ET.Domain.CarAgg;
using ET.Domain.RoleAgg;
using ET.Domain.UserAgg;
using System.Data.Entity;

namespace ET.Data.Context
{
   public class ETContext : DbContext
   {
      public ETContext() : base("Data Source=.\\SQL2019;Initial Catalog=Electronic-Trip;Integrated Security=True;") {}

      public virtual DbSet<User> Users { get; set; }
      public virtual DbSet<Car> Cars { get; set; }
      public virtual DbSet<Role> Roles { get; set; }

      protected override void OnModelCreating(DbModelBuilder modelBuilder)
      {
         modelBuilder.Configurations.AddFromAssembly(typeof(UserMapping).Assembly);
         base.OnModelCreating(modelBuilder);
      }
   }
}