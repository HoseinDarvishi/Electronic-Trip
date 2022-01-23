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
         var user = _userRepository.GetById(id);
         if (user != null)
         {
            user.Active();
            _userRepository.Save();
            return new OperationResult().Success(Messages.SuccessActiveUser);
         }
         return new OperationResult().Failed(Messages.NotFound);
      }

      public OperationResult DeActive(int id)
      {
         var user = _userRepository.GetById(id);
         if (user != null)
         {
            user.DeActive();
            _userRepository.Save();
            return new OperationResult().Success(Messages.SuccessActiveUser);
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
            return new OperationResult().Success(Messages.SuccessRegisterUser);
         }
         return new OperationResult().Failed(Messages.ExsitsUserName);
      }
   }
}
