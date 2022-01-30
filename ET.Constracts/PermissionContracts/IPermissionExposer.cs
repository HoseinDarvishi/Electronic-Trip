using System.Collections.Generic;

namespace ET.Constracts.PermissionContracts
{
   public interface IPermissionExposer
   {
      List<PermissionVM> Expose();
   }
}
