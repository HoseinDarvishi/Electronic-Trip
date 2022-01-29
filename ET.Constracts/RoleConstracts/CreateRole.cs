using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ET.Constracts.RoleConstracts
{
   public class CreateRole
   {
      [DisplayName("عنوان نقش")]
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(4, ErrorMessage = "حداقل 4 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string RoleTitle { get; set; }
   }
}