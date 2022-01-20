using ET.Constracts.UserContracts;
using ET.Data.Context;
using ET.Domain.UserAgg;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ET.Data.Repositories
{
   public class UserRepository : IUserRepository
   {
      private ETContext _context = new ETContext();

      public async Task SaveAsync() => await _context.SaveChangesAsync();
      public void Save() => _context.SaveChanges();

      public void Register(RegisterUser user)
      {
         User newUser = new User(user.FullName, user.UserName, user.Email, user.Password);
         _context.Users.Add(newUser);
         Save();
      }

      public void Login(LoginUser user)
      {
         throw new NotImplementedException();
      }

      public UserVM GetById(int userId)
      {
         return _context.Users.Select(x => new UserVM
         {
            UserId = x.UserId,
            FullName = x.FullName,
            UserName = x.UserName,
            Email = x.Email,
            RegisterDate = x.RegisterDate.ToString()
         })
         .AsNoTracking()
         .FirstOrDefault(x=>x.UserId == userId);
      }

      public UserVM GetByUserName(string userName)
      {
         return _context.Users.Select(x => new UserVM
         {
            UserId = x.UserId,
            FullName = x.FullName,
            UserName = x.UserName,
            Email = x.Email,
            RegisterDate = x.RegisterDate.ToString()
         })
         .AsNoTracking()
         .FirstOrDefault(x => x.UserName == userName);
      }

      public bool ActiveUser(int userId)
      {
         var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
         if (user == null) return false;
         user.Active();
         Save();
         return true;
      }

      public bool DeActiveUser(int userId)
      {
         var user = _context.Users.FirstOrDefault(x => x.UserId == userId);
         if (user == null) return false;
         user.DeActive();
         Save();
         return true;
      }

      public bool IsExists(string userName)
      {
         return _context.Users.Any(x => x.UserName == userName);
      }

      public bool IsExists(int id)
      {
         return _context.Users.Any(x => x.UserId == id);
      }
   }
}
