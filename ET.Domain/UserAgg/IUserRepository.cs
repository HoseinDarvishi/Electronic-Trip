using ET.Constracts.UserContracts;
using System.Collections.Generic;

namespace ET.Domain.UserAgg
{
   public interface IUserRepository
   {
      void Register(RegisterUser user);
      void Login(LoginUser user);
      List<UserVM> GetAll(SearchUser search);
      User GetById(int userId);
      User GetByUserName(string userName);
      bool IsExists(string userName);
      bool IsExists(int id);
      void Save();
   }
}
