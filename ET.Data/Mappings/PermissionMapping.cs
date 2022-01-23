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

         this.HasMany(p => p.RolePermissions).WithRequired(rp => rp.Permission).HasForeignKey(rp => rp.PermissionId);
      }
   }

   public class Role_PermissionMapping : EntityTypeConfiguration<Role_Permission>
   {
      public Role_PermissionMapping()
      {
         this.ToTable("Role_Permissions");
         this.HasKey(rp => new { rp.PermissionId, rp.RoleId });
         
         this.HasRequired(rp => rp.Permission).WithMany(p => p.RolePermissions).HasForeignKey(rp => rp.PermissionId);
         this.HasRequired(rp => rp.Role).WithMany(r => r.RolePermissions).HasForeignKey(rp => rp.RoleId);
      }
   }
}
