using ET.Constracts.UserContracts;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ET.Constracts.CarConstracts
{
   public class CreateCar
   {
      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(4, ErrorMessage = "حداقل 4 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string CarName { get; set; }


      [Required(ErrorMessage = "این مورد الزامی است")]
      [Range(1300, 3000, ErrorMessage = "این مورد الزامی است")]
      public int Model { get; set; }

      [Required(ErrorMessage = "این مورد الزامی است")]
      [Range(60, 400, ErrorMessage = "این مورد الزامی است")]
      public int Speed { get; set; }

      [Required(ErrorMessage = "این مورد الزامی است")]
      [MinLength(2, ErrorMessage = "حداقل 2 کاراکتر")]
      [StringLength(200, ErrorMessage = "حداکثر 200 کاراکتر")]
      public string Color { get; set; }

      [Required(ErrorMessage = "این مورد الزامی است")]
      [Range(1, 500, ErrorMessage = "این مورد الزامی است")]
      public int DriverId { get; set; }

      public List<UserVM> Drivers { get; set; }
   }
}