using System.Collections.Generic;

namespace ET.Constracts.PermissionContracts
{
   public class AppPermissions
   {
      // User
      public int ListUser { get; } = 101;
      public int AddUser { get; } = 102;
      public int ActivitionUser { get; } = 103;

      // Car
      public int ListCar { get; } = 201;
      public int AddCar { get; } = 202;
      public int EditCar { get; } = 203;
      public int RemoveCar { get; } = 204;
      public int RestoreCar { get; } = 205;

      // Request
      public int ListRequest { get; } = 301;
      public int CancelRequest { get; } = 302;
      public int DoneRequest { get; } = 303;

      // Role
      public int ListRole { get; } = 401;
      public int AddRole { get; } = 402;
      public int SetPermission { get; } = 403;

      public static List<int> GetAll()
      {
         return new List<int>
         {
            101 , 102 , 103 ,201 , 202, 203 , 204 , 205 , 301 , 302 , 303 , 401 , 402 ,403
         };
      }
   }
}
