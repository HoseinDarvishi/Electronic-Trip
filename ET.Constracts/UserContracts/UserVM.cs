﻿namespace ET.Constracts.UserContracts
{
   public class UserVM
   {
      public int UserId { get; set; }
      public string FullName { get; set; }
      public string UserName { get; set; }
      public string Email { get; set; }
      public string RegisterDate { get; set; }
      public bool IsActive { get; set; }
   }
}
