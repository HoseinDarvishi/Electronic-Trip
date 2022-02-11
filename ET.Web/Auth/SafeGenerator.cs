using System;
using System.Text;
using System.Web.Security;

namespace ET.Web.Auth
{
   public static class SafeGenerator
   {
      public static string Protect(this string data ,params string[] keys)
      {
         byte[] dataBytes = Encoding.UTF8.GetBytes(data);
         byte[] encryptedBytes = MachineKey.Protect(dataBytes, keys);

         return Convert.ToBase64String(encryptedBytes);
      }

      public static OutType UnProtect<OutType>(this string data , params string[] keys)
      {
         byte[] encryptedBytes = Convert.FromBase64String(data);
         byte[] originalBytes = MachineKey.Unprotect(encryptedBytes, keys);
         string originalData = Encoding.UTF8.GetString(originalBytes);

         var convertedValue = Convert.ChangeType(originalData, typeof(OutType));

         return (OutType)convertedValue;
      }
   }
}