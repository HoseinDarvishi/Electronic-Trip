using ET.Domain.RoleAgg;
using System.Data.Entity.ModelConfiguration;

namespace ET.Data.Mappings
{
   public class PermissionMapping : EntityTypeConfiguration<Permission>
   {
      public PermissionMapping()
      {
         this.ToTable("Permissions");
         this.HasKey<int>(p => p.PermissionId);
         this.Property(p => p.Name).HasMaxLength(300).IsRequired();

         this.HasRequired(p => p.Role).WithMany(r => r.Permissions).HasForeignKey(p => p.RoleId);
      }
   }
}
