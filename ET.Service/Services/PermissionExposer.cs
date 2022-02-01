using ET.Constracts.PermissionContracts;
using System.Collections.Generic;

namespace ET.Service.Services
{
   public class PermissionExposer : IPermissionExposer
   {
      List<PermissionVM> IPermissionExposer.Expose()
      {
         return new List<PermissionVM>
         {
             new PermissionVM(AppPermissions.ListUser,"مشاهده لیست کاربران"),
             new PermissionVM(AppPermissions.AddUser,"اضافه کردن کاربر"),
             new PermissionVM(AppPermissions.ActivitionUser,"فعال یا غیرفعالسازی کاربران"),
             new PermissionVM(AppPermissions.EditUser,"ویرایش کاربران"),
             new PermissionVM(AppPermissions.ListRole,"مشاهده لیست نقش ها"),
             new PermissionVM(AppPermissions.AddRole,"اضافه کردن نقش"),
             new PermissionVM(AppPermissions.SetPermission,"تعیین دسترسی نقش ها"),
             new PermissionVM(AppPermissions.EditRole,"ویرایش نقش ها"),
             new PermissionVM(AppPermissions.ListCar,"مشاهده لیست اتومبیلها"),
             new PermissionVM(AppPermissions.AddCar,"اصافه کردن اتومبیل"),
             new PermissionVM(AppPermissions.EditCar,"ویرایش اتومبیل"),
             new PermissionVM(AppPermissions.RemoveCar,"غیرفعالسازی اتومبیل"),
             new PermissionVM(AppPermissions.RestoreCar,"فعالسازی اتومبیل"),
             new PermissionVM(AppPermissions.ListRequest,"مشاهده لیست درخواست ها"),
             new PermissionVM(AppPermissions.DoneRequest,"اتمام موفق درخواست"),
             new PermissionVM(AppPermissions.CancelRequest,"لغو درخواست")
         };
      }
   }
}
