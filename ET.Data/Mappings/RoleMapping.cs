using ET.Domain.RoleAgg;
using System.Data.Entity.ModelConfiguration;

namespace ET.Data.Mappings
{
   public class RoleMapping : EntityTypeConfiguration<Role>
   {
      public RoleMapping()
      {
         this.ToTable("Roles");
         this.HasKey<int>(x => x.RoleId);
         this.Property(x => x.RoleTitle).HasMaxLength(300).IsRequired();

         this.HasMany(x => x.Users).WithRequired(x => x.Role).HasForeignKey(x => x.RoleId);
         this.HasMany(x => x.RolePermissions).WithRequired(x => x.Role).HasForeignKey(x => x.RoleId);
      }
   }
}
