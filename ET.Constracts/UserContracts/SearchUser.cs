namespace ET.Constracts.UserContracts
{
   public class SearchUser
   {
      public string FullNameOrEmailOrUserName { get; set; }
      public bool ShowWithDeActives { get; set; } = false;
   }
}
