using System;

namespace ET.Tools
{
   public class Generator
   {
      public static string GenerateUniqCode()
      {
         return Guid.NewGuid().ToString().Replace("-", "");
      }
   }
}
