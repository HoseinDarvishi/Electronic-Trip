using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ET.Constracts.RequestContracts
{
   public class AddRequest
   {
      public int UserId { get; set; }
      public int CarId { get; set; }

      [DisplayName("خودرو : ")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string CarName { get; set; }

      [DisplayName("راننده : ")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string DriverName { get; set; }

      [DisplayName("مسافر : ")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string FullName { get; set; }

      [DisplayName("آدرس : ")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(20, ErrorMessage = "حداقل 20 کاراکتر")]
      [StringLength(3000, ErrorMessage = "حداکثر 3000 کاراکتر")]
      public string Address { get; set; }

      public string DetachCode { get; set; }
   }
}
