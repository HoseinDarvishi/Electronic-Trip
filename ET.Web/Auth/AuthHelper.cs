using Newtonsoft.Json;
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
            return HttpContext.Current.User.Identity.Name;
         }
      }

      public static List<int> PermissionCodes
      {
         get
         {
            if (!IsAuthenticate()) return null;

            string cookieValEncrypted = HttpContext.Current.Request.Cookies["PCl0-AIOP1"].Value;
            string cookieValDecrypted = cookieValEncrypted.UnProtect<string>("UserPermCookie");

            return JsonConvert.DeserializeObject<List<int>>(cookieValDecrypted);
         }
      }

      public static bool IsAuthenticate()
      {
         if (HttpContext.Current.User == null || !HttpContext.Current.User.Identity.IsAuthenticated)
            return false;
         return true;
      }

      public static bool HasPermission(int permissionCode) 
      {
         if (!IsAuthenticate()) return false;
         return PermissionCodes.Contains(permissionCode); 
      }
   }
}