using ET.Constracts.UserContracts;
using ET.Data.Context;
using ET.Domain.RoleAgg;
using ET.Domain.UserAgg;
using ET.Tools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ET.Data.Repositories
{
   public class UserRepository : IUserRepository
   {
      private ETContext _context;

      #region Ctor
      public UserRepository(ETContext context)
      {
         _context = context;
      }
      #endregion

      public void Save() => _context.SaveChanges();

      public void Register(CreateUser user)
      {
         User newUser = new User(user.FullName, user.UserName, user.Email, user.Password, user.RoleId);
         _context.Users.Add(newUser);
         Save();
      }

      public void Login(LoginUser user)
      {
         throw new NotImplementedException();
      }

      public User GetById(int userId)
      {
         return _context.Users.FirstOrDefault(x => x.UserId == userId);
      }

      public UserVM GetByUserName(string userName)
      {
         return _context.Users
            .Select(x => new UserVM
            {
               UserId = x.UserId,
               FullName = x.FullName,
               Email = x.Email,
               IsActive = x.IsActive,
               UserName = x.UserName,
               RoleId = x.RoleId,
               RoleName = x.Role.RoleTitle,
               RegisterDateEn = x.RegisterDate
            })
            .AsNoTracking()
            .FirstOrDefault(x => x.UserName == userName);
      }

      public bool IsExists(string userName)
      {
         return _context.Users.Any(x => x.UserName == userName);
      }

      public bool IsExists(int id)
      {
         return _context.Users.Any(x => x.UserId == id);
      }

      public UserVM GetForLogin(LoginUser login)
      {
         return _context.Users
            .Select(x=> new UserVM
            {
               IsActive = x.IsActive,
               UserName = x.UserName,
               Password = x.Password
            })
            .AsNoTracking()
            .FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
      }

      public List<UserVM> GetAll(SearchUser search)
      {
         var query = _context.Users.Include(u => u.Role).Select(x => new UserVM
         {
            UserId = x.UserId,
            FullName = x.FullName,
            Email = x.Email,
            IsActive = x.IsActive,
            UserName = x.UserName,
            RoleId = x.RoleId,
            RoleName = x.Role.RoleTitle,
            RegisterDateEn = x.RegisterDate
         })
         .AsNoTracking();

         if (!string.IsNullOrWhiteSpace(search.FullNameOrEmailOrUserName))
            query = query.Where(u => u.FullName.Contains(search.FullNameOrEmailOrUserName) || u.Email.Contains(search.FullNameOrEmailOrUserName));

         var list = query.OrderByDescending(x => x.UserId).ToList();

         list.ForEach(u => u.RegisterDate = u.RegisterDateEn.ToShamsi());

         return list;
      }

      public EditUser GetForEdit(int userId)
      {
         return _context.Users
            .Select(x => new EditUser
            {
               UserId = x.UserId,
               FullName = x.FullName,
               Email = x.Email,
               RoleId = x.RoleId
            })
            .AsNoTracking()
            .FirstOrDefault(x => x.UserId == userId);
      }

      public List<UserVM> GetAllDrivers()
      {
         return _context.Users.Include(x => x.Role)
            .Where(u => u.Role.RoleTitle == "Driver" || u.Role.RoleTitle == "راننده")
            .Select(x => new UserVM
            {
               UserId = x.UserId,
               FullName = x.FullName
            })
            .AsNoTracking()
            .ToList();
      }

      public List<UserVM> GetAllDrivers(int driverRoleId)
      {
         return _context.Users.Include(x => x.Role)
            .Where(u => u.Role.RoleId == driverRoleId)
            .Select(x => new UserVM
            {
               UserId = x.UserId,
               FullName = x.FullName
            })
            .AsNoTracking()
            .ToList();
      }

      public int UserCount(bool onlyDeActives)
      {
         if (onlyDeActives)
            return _context.Users.Where(u => !u.IsActive).Count();
         else
            return _context.Users.Count();
      }

      public int DriverCount(bool onlyDeActives , string driverRoleTitle = "")
      {
         Role role;

         if (!string.IsNullOrWhiteSpace(driverRoleTitle))
            role = _context.Roles.AsNoTracking().FirstOrDefault(x => x.RoleTitle == driverRoleTitle);
         else
         {
            role = _context.Roles.AsNoTracking().FirstOrDefault(x => x.RoleTitle == "Driver");
            if(role == null)
               role = _context.Roles.AsNoTracking().FirstOrDefault(x => x.RoleTitle == "راننده");
         }

         if (role == null) return 0;

         if (onlyDeActives)
            return _context.Users.Where(u => u.RoleId == role.RoleId && !u.IsActive).Count();
         else
            return _context.Users.Where(u=>u.RoleId == role.RoleId).Count();
      }
   }
}