namespace ET.Constracts.UserContracts
{
   public interface IUserService
   {
      OperationResult Register(RegisterUser register);
      OperationResult Login(LoginUser login);
      OperationResult Active(int id);
      OperationResult DeActive(int id);
   }
}
