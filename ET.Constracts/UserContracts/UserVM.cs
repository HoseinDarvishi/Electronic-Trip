﻿using System;

namespace ET.Constracts.UserContracts
{
   public class UserVM
   {
      public int UserId { get; set; }
      public string FullName { get; set; }
      public string UserName { get; set; }
      public string Email { get; set; }
      public string RegisterDate { get; set; }
      public bool IsActive { get; set; }
      public int RoleId { get; set; }
      public string RoleName { get; set; }
      public string Password { get; set; }
      public DateTime RegisterDateEn { get; set; }
   }
}
