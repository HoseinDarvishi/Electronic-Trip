using System.Collections.Generic;

namespace ET.Constracts.UserContracts
{
   public interface IUserService
   {
      List<UserVM> GetAll(SearchUser search);
      OperationResult Register(RegisterUser register);
      OperationResult Login(LoginUser login);
      OperationResult Active(int id);
      OperationResult DeActive(int id);
   }
}
