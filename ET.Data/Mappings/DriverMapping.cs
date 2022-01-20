using ET.Domain.DriverAgg;
using System.Data.Entity.ModelConfiguration;

namespace ET.Data.Mappings
{
   public class DriverMapping : EntityTypeConfiguration<Driver>
   {
      public DriverMapping()
      {
         this.ToTable("Drivers");
         this.HasKey(d => d.DriverId);
         this.Property(d => d.FullName).HasMaxLength(300).IsRequired();
         this.Property(d => d.Age).IsRequired();
         this.Property(d => d.ExprienceYears).IsRequired();

         this.HasMany(d => d.Cars).WithRequired(c => c.Driver).HasForeignKey(c => c.DriverId);
      }
   }
}
