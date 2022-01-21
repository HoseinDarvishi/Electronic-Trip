using ET.Constracts.RoleConstracts;
using System.Collections.Generic;

namespace ET.Domain.RoleAgg
{
   public interface IRoleRepository
   {
      List<RoleVM> GetAll(string roleTitle);
      Role GetById(int id);
      Role GetByTitle(string title);
      void AddRole(string roleTitle);
      bool IsExsist(string roleTitle);
      bool IsExsist(int id);
      void Save();
   }
}