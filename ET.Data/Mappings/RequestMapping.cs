using ET.Domain.RequestAgg;
using System.Data.Entity.ModelConfiguration;

namespace ET.Data.Mappings
{
   public class RequestMapping : EntityTypeConfiguration<Request>
   {
      public RequestMapping()
      {
         this.ToTable("Requestes");
         this.HasKey<int>(r=>r.RequestId);

         this.Property(r => r.StatusId).IsRequired();
         this.Property(r => r.DetachCode).HasMaxLength(255).IsRequired();
         this.Property(r => r.Address).HasMaxLength(2000).IsRequired();

         this.HasRequired(r => r.Car).WithMany(c => c.Requests).HasForeignKey(r => r.CarId);
         this.HasRequired(r => r.User).WithMany(c => c.Requests).HasForeignKey(r => r.UserId);
      }
   }
}
