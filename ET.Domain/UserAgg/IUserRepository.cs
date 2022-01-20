using ET.Constracts.UserContracts;

namespace ET.Domain.UserAgg
{
   public interface IUserRepository
   {
      void Register(RegisterUser user);
      void Login(LoginUser user);
      UserVM GetById(int userId);
      UserVM GetByUserName(string userName);
      bool ActiveUser(int userId);
      bool DeActiveUser(int userId);
      bool IsExists(string userName);
      bool IsExists(int id);
   }
}
