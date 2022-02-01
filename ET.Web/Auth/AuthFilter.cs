using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ET.Web.Auth
{
   public class AuthFilterAttribute : ActionFilterAttribute , IAuthorizationFilter
   {
      public int PermissionCode { get; set; }
      private List<int> PermissionsCodes;

      public AuthFilterAttribute(int permissinCode)
      {
         PermissionCode = permissinCode;

         if (AuthHelper.IsAuthenticate())
            PermissionsCodes = AuthHelper.PermissionCodes;
      }

      public void OnAuthorization(AuthorizationContext filterContext)
      {
         if (!AuthHelper.IsAuthenticate() || PermissionsCodes == null || !PermissionsCodes.Contains(PermissionCode))
            filterContext.Result = new HttpUnauthorizedResult();
         
      }
   }
}