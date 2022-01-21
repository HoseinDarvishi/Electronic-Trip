using ET.Domain.CarAgg;
using ET.Domain.RoleAgg;
using System;
using System.Collections.Generic;

namespace ET.Domain.UserAgg
{
   public class User
   {
      #region Ctor
      private User() { }
      public User(string fullName ,string userName , string email,string password,int roleId)
      {
         FullName = fullName;
         UserName = userName;
         Email = email;
         Password = password;
         RoleId = roleId;
         RegisterDate = DateTime.Now;
      }
      #endregion

      public int UserId { get; private set; }
      public string FullName { get; private set; }
      public string UserName { get; private set; }
      public string Password { get; private set; }
      public string Email { get; private set; }
      public int RoleId { get;private set; }
      public bool IsActive { get; private set; }
      public DateTime RegisterDate { get; private set; }

      #region Relations
      public virtual List<Car> Cars { get; set; }
      public virtual Role Role { get; set; }
      #endregion

      #region Edit
      public void Active() => IsActive = true;

      public void DeActive() => IsActive = false;

      public void Edit(string fullName, string userName, string email)
      {
         FullName = fullName;
         UserName = userName;
         Email = email;
      }
      #endregion
   }
}
