using System;
using System.Security.Cryptography;
using System.Text;

namespace ET.Tools
{
   public static class PasswordHelper
   {
      public static string EncodePassword(this string pass) //Encrypt using MD5   
      {
         byte[] originalBytes;
         byte[] encodedBytes;
         //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)   
         MD5 md5 = new MD5CryptoServiceProvider();
         originalBytes = Encoding.Default.GetBytes(pass);
         encodedBytes = md5.ComputeHash(originalBytes);
         //Convert encoded bytes back to a 'readable' string   
         return BitConverter.ToString(encodedBytes);
      }
   }
}
