using ET.Domain.UserAgg;
using System.Data.Entity.ModelConfiguration;

namespace ET.Data.Mappings
{
   public class UserMapping : EntityTypeConfiguration<User>
   {
      public UserMapping()
      {
         this.ToTable("Users");
         this.HasKey<int>(u => u.UserId);
         this.Property(u => u.FullName).HasMaxLength(300).IsRequired();
         this.Property(u => u.UserName).HasMaxLength(300).IsRequired().IsUnicode();
         this.Property(u => u.Email).HasMaxLength(500).IsRequired();
      }
   }
}
