using System.Collections.Generic;

namespace ET.Constracts.PermissionContracts
{
   public class AppPermissions
   {
      // User
      public const int ListUser = 101;
      public const int AddUser = 102;
      public const int ActivitionUser = 103;
      public const int EditUser = 104;

      // Car
      public const int ListCar = 201;
      public const int AddCar = 202;
      public const int EditCar = 203;
      public const int RemoveCar = 204;
      public const int RestoreCar = 205;

      // Request
      public const int ListRequest = 301;
      public const int CancelRequest = 302;
      public const int DoneRequest = 303;
      public const int WaitRequest = 304;

      // Role
      public const int ListRole = 401;
      public const int AddRole = 402;
      public const int SetPermission = 403;
      public const int EditRole = 404;

      // Reports
      public const int ListReports = 500;


      public static List<int> GetAll()
      {
         return new List<int>
         {
            101 , 102 , 103 ,104 ,201 , 202, 203 , 204 , 205 , 301 , 302 , 303, 304, 401 , 402 ,403 , 404, 500
         };
      }
   }
}
