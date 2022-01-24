using ET.Constracts;
using ET.Constracts.UserContracts;
using ET.Domain.UserAgg;
using ET.Tools;
using System;
using System.Collections.Generic;

namespace ET.Service.Services
{
   public class UserService : IUserService
   {
      private readonly IUserRepository _userRepo;

      #region Ctor
      public UserService(IUserRepository userRepository)
      {
         _userRepo = userRepository;
      } 
      #endregion

      public OperationResult Active(int id)
      {
         var user = _userRepo.GetById(id);
         if (user != null)
         {
            user.Active();
            _userRepo.Save();
            return new OperationResult().Success(Messages.SuccessActiveUser);
         }
         return new OperationResult().Failed(Messages.NotFound);
      }

      public OperationResult DeActive(int id)
      {
         var user = _userRepo.GetById(id);
         if (user != null)
         {
            user.DeActive();
            _userRepo.Save();
            return new OperationResult().Success(Messages.SuccessActiveUser);
         }
         return new OperationResult().Failed(Messages.NotFound);
      }

      public List<UserVM> GetAll(SearchUser search)
      {
         return _userRepo.GetAll(search);
      }

      public OperationResult Login(LoginUser login)
      {
         throw new NotImplementedException();
      }

      public OperationResult Register(RegisterUser register)
      {
         if (!_userRepo.IsExists(register.UserName))
         {
            register.Email = register.Email.FixEmail();
            register.Password = register.Password.EncodePassword();
            _userRepo.Register(register);
            return new OperationResult().Success(Messages.SuccessRegisterUser);
         }
         return new OperationResult().Failed(Messages.ExsitsUserName);
      }
   }
}
