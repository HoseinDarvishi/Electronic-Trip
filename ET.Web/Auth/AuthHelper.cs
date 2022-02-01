using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;

namespace ET.Web.Auth
{
   public class AuthHelper
   {
      public static string AuthName
      {
         get
         {
            if (!IsAuthenticate()) return null;
            string cookieVal = HttpContext.Current.User.Identity.Name;
            return cookieVal.Split(new[] { "|H|" }, StringSplitOptions.None)[0];
         }
      }

      public static List<int> PermissionCodes
      {
         get
         {
            if (!IsAuthenticate()) return null;
            var cookieVal = HttpContext.Current.User.Identity.Name;
            string permCodes = cookieVal.Split(new[] { "|H|" },StringSplitOptions.None)[1];
            return JsonConvert.DeserializeObject<List<int>>(permCodes);
         }
      }

      public static bool IsAuthenticate() => HttpContext.Current.User.Identity.IsAuthenticated;

      public static bool HasPermission(int permissionCode) 
      {
         if (!IsAuthenticate()) return false;
         return PermissionCodes.Contains(permissionCode); 
      }
   }
}