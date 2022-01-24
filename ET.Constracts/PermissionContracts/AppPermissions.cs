namespace ET.Constracts.PermissionContracts
{
   public class AppPermissions
   {
      // User
      public const int ListUser = 101;
      public const int AddUser = 102;
      public const int ActivitionUser = 103;

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

      // Role
      public const int ListRole = 401;
      public const int AddRole = 402;
      public const int SetPermission = 403;
   }
}
