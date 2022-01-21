using ET.Constracts.RoleConstracts;
using System.Collections.Generic;

namespace ET.Domain.RoleAgg
{
   public interface IRoleRepository
   {
      List<Role> GetAll(SearchRole search);
      Role GetById(int id);
      Role GetByTitle(string title);
      void AddRole(CreateRole role);
      bool IsExsist(string roleTitle);
   }
}