using System;

namespace ET.Domain.UserAgg
{
   public class User
   {
      #region Ctor
      private User() { }
      public User(string fullName ,string userName , string email,string password)
      {
         FullName = fullName;
         UserName = userName;
         Email = email;
         Password = password;
         RegisterDate = DateTime.Now;
      }
      #endregion

      public int UserId { get; private set; }
      public string FullName { get; private set; }
      public string UserName { get; private set; }
      public string Password { get; private set; }
      public string Email { get; private set; }
      public bool IsActive { get; private set; }
      public DateTime RegisterDate { get; private set; }

      #region Relations
      #endregion

      #region Edit
      public void Active() => IsActive = true;
      public void DeActive() => IsActive = false;
      #endregion
   }
}
