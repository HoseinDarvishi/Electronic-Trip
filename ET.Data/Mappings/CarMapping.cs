using ET.Domain.CarAgg;
using System.Data.Entity.ModelConfiguration;

namespace ET.Data.Mappings
{
   public class CarMapping : EntityTypeConfiguration<Car>
   {
      public CarMapping()
      {
         this.ToTable("Cars");
         this.HasKey<int>(c => c.CarId);
         this.Property(c => c.CarName).HasMaxLength(300).IsRequired();
         this.Property(c => c.Model).IsRequired();
         this.Property(c => c.Speed).IsRequired();
         this.Property(c => c.Color).HasMaxLength(300).IsRequired();

         this.HasRequired(x => x.Driver).WithMany(x => x.Cars).HasForeignKey(x => x.DriverId);
         this.HasMany(c => c.Requests).WithRequired(r => r.Car).HasForeignKey(r => r.CarId);
      }
   }
}
