using System.Collections.Generic;

namespace ET.Constracts.UserContracts
{
   public interface IUserService
   {
      List<UserVM> GetAll(SearchUser search);
      EditUser GetById(int id);
      UserVM GetByUserName(string userName);
      OperationResult Register(CreateUser register);
      OperationResult Login(LoginUser login);
      OperationResult Active(int id);
      OperationResult DeActive(int id);
      OperationResult Edit(EditUser edit);
      List<UserVM> GetAllDrivers();
   }
}
