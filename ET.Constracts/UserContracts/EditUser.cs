using ET.Constracts.RoleConstracts;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ET.Constracts.UserContracts
{
   public class EditUser
   {
      public int UserId { get; set; }

      [DisplayName("نام و نام خانوادگی")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(4, ErrorMessage = "حداقل 4 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string FullName { get; set; }

      [DisplayName("نقش")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [Range(1, 20, ErrorMessage = "این مورد الزامی است")]
      public int RoleId { get; set; }

      [DisplayName("ایمیل")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [EmailAddress(ErrorMessage = "ایمیل را به درستی وارد کنید")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string Email { get; set; }

      public List<RoleVM> Roles { get; set; }
   }
}
