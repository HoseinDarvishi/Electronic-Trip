namespace ET.Constracts.PermissionContracts
{
   public class PermissionVM
   {
      #region Ctor
      public PermissionVM(int code, string name)
      {
         Code = code;
         Name = name;
      } 
      #endregion

      public int Code { get; set; }
      public string Name { get; set; }
   }
}
