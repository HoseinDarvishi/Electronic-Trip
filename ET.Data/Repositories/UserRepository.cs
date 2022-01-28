using ET.Constracts.UserContracts;
using ET.Data.Context;
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

      public void Register(RegisterUser user)
      {
         User newUser = new User(user.FullName, user.UserName, user.Email, user.Password,user.RoleId);
         _context.Users.Add(newUser);
         Save();
      }

      public void Login(LoginUser user)
      {
         throw new NotImplementedException();
      }

      public User GetById(int userId)
      {
         return _context.Users.FirstOrDefault(x=>x.UserId == userId);
      }

      public User GetByUserName(string userName)
      {
         return _context.Users.FirstOrDefault(x => x.UserName == userName);
      }

      public bool IsExists(string userName)
      {
         return _context.Users.Any(x => x.UserName == userName);
      }

      public bool IsExists(int id)
      {
         return _context.Users.Any(x => x.UserId == id);
      }

      public List<UserVM> GetAll(SearchUser search)
      {
         var query = _context.Users.Include(u=>u.Role).Select(x => new UserVM
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
            query = query.Where(u=>u.FullName.Contains(search.FullNameOrEmailOrUserName) || u.Email.Contains(search.FullNameOrEmailOrUserName));

         var list = query.OrderByDescending(x=>x.UserId).ToList();

         list.ForEach(u => u.RegisterDate = u.RegisterDateEn.ToShamsi());

         return list;
      }

      public EditUser GetForEdit(int userId)
      {
         return _context.Users
            .Select(x=> new EditUser
            {
               UserId = x.UserId,
               FullName = x.FullName,
               Email = x.Email,
               RoleId = x.RoleId
            })
            .AsNoTracking()
            .FirstOrDefault(x => x.UserId == userId);
      }
   }
}
