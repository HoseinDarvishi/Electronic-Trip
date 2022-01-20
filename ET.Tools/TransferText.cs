namespace ET.Tools
{
   public static class TransferText
   {
      public static string FixEmail(this string email)
      {
         return email.Trim().ToLower();
      }
   }
}
