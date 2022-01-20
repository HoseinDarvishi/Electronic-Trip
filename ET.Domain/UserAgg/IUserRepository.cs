using ET.Constracts.UserContracts;
using System.Threading.Tasks;

namespace ET.Domain.UserAgg
{
   public interface IUserRepository
   {
      Task<bool> Register(RegisterUser user);
      Task<bool> Login(LoginUser user);
      Task<UserVM> GetById(int userId);
      Task<UserVM> GetByUserName(string userName);
      Task<bool> ActiveUser(int userId);
      Task<bool> DeActiveUser(int userId);
      Task<bool> IsExists(string userName);
      Task<bool> IsExists(int id);
   }
}
