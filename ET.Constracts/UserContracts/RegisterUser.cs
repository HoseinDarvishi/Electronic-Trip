using System.ComponentModel.DataAnnotations;

namespace ET.Constracts.UserContracts
{
   public class RegisterUser
   {
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(4, ErrorMessage = "حداقل 4 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string FullName { get; set; }

      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string UserName { get; set; }

      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      [DataType(DataType.Password)]
      public string Password { get; set; }

      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(5, ErrorMessage = "حداقل 5 کاراکتر")]
      [DataType(DataType.Password)]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      [Compare(nameof(Password), ErrorMessage = "رمز عبور و تکرار آن با هم مغایرت دارند")]
      public string RePassword { get; set; }

      [Required(ErrorMessage = "این مورد الزامی است")]
      [EmailAddress(ErrorMessage = "ایمیل را به درستی وارد کنید")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string Email { get; set; }

      public int RoleId { get; set; }
   }
}
