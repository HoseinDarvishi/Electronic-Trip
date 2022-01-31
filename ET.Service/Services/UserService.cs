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

      public OperationResult Edit(EditUser edit)
      {
         var user = _userRepo.GetById(edit.UserId);
         if (user == null) return new OperationResult().Failed(Messages.NotFound);
         user.Edit(edit.FullName,edit.Email,edit.RoleId);
         _userRepo.Save();
         return new OperationResult().Success(Messages.Success);
      }

      public List<UserVM> GetAll(SearchUser search)
      {
         return _userRepo.GetAll(search);
      }

      public List<UserVM> GetAllDrivers()
      {
         return _userRepo.GetAllDrivers();
      }

      public EditUser GetById(int id)
      {
         return _userRepo.GetForEdit(id);
      }

      public UserVM GetByUserName(string userName)
      {
         if (!_userRepo.IsExists(userName)) return null;
         return _userRepo.GetByUserName(userName);
      }

      public OperationResult Login(LoginUser login)
      {
         login.Password = login.Password.EncodePassword();

         var user = _userRepo.GetForLogin(login);

         if (user == null)
            return new OperationResult().Failed(Messages.Failedlogin);

         if (!user.IsActive)
            return new OperationResult().Failed(Messages.NotActiveUser);

         return new OperationResult().Success(Messages.SuccessLoginUser);
      }

      public OperationResult Register(CreateUser register)
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
