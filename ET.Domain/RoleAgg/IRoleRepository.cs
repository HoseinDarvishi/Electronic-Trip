using ET.Constracts.RoleConstracts;
using System.Collections.Generic;

namespace ET.Domain.RoleAgg
{
   public interface IRoleRepository
   {
      List<RoleVM> GetAll(SearchRole search);
      RoleVM GetById(int id);
      RoleVM GetByTitle(string title);
      void AddRole(CreateRole role);
      bool IsExsist(string roleTitle);
      bool IsExsist(int id);
   }
}