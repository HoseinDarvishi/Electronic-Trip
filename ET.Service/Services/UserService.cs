using ET.Constracts;
using ET.Constracts.UserContracts;
using ET.Data.Repositories;
using ET.Domain.UserAgg;
using ET.Tools;
using System;
using System.Collections.Generic;

namespace ET.Service.Services
{
   public class UserService : IUserService
   {
      private readonly IUserRepository _userRepository = new UserRepository();

      public OperationResult Active(int id)
      {
         if (_userRepository.IsExists(id))
         {
            _userRepository.ActiveUser(id);
            return new OperationResult().Success(Messages.SuccessActiveUser);
         }
         return new OperationResult().Failed(Messages.NotFound);
      }

      public OperationResult DeActive(int id)
      {
         if (_userRepository.IsExists(id))
         {
            _userRepository.DeActiveUser(id);
            return new OperationResult().Success(Messages.SuccessDeActiveUser);
         }
         return new OperationResult().Failed(Messages.NotFound);
      }

      public List<UserVM> GetAll(SearchUser search)
      {
         return _userRepository.GetAll(search);
      }

      public OperationResult Login(LoginUser login)
      {
         throw new NotImplementedException();
      }

      public OperationResult Register(RegisterUser register)
      {
         if (!_userRepository.IsExists(register.UserName))
         {
            register.Email = register.Email.FixEmail();
            register.Password = register.Password.EncodePassword();
            _userRepository.Register(register);
            return new OperationResult().Success(Messages.SuccessRegister);
         }
         return new OperationResult().Failed(Messages.ExsitsUserName);
      }
   }
}
