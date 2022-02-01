using ET.Constracts.UserContracts;
using System.Collections.Generic;

namespace ET.Domain.UserAgg
{
   public interface IUserRepository
   {
      void Register(CreateUser user);
      void Login(LoginUser user);
      UserVM GetForLogin(LoginUser login);
      List<UserVM> GetAll(SearchUser search);
      List<UserVM> GetAllDrivers();
      List<UserVM> GetAllDrivers(int driverRoleId);
      User GetById(int userId);
      EditUser GetForEdit(int userId);
      UserVM GetByUserName(string userName);
      bool IsExists(string userName);
      bool IsExists(int id);
      void Save();
      int UserCount(bool onlyDeActives);
      int DriverCount(bool onlyDeActives, string driverRoleTitle = "");
   }
}
