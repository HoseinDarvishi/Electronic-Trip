using System.Collections.Generic;

namespace ET.Constracts.PermissionContracts
{
   public interface IPermissionExposer
   {
      Dictionary<string,List<PermissionVM>> Expose();
   }
}
