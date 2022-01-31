using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ET.Constracts.UserContracts
{
   public class LoginUser
   {
      [DisplayName("نام کاربری")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string UserName { get; set; }

      [DisplayName("رمز عبور")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      [DataType(DataType.Password)]
      public string Password { get; set; }
   }
}
