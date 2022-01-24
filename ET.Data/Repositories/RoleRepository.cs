using ET.Constracts.RoleConstracts;
using ET.Data.Context;
using ET.Domain.RoleAgg;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ET.Data.Repositories
{
   public class RoleRepository : IRoleRepository
   {
      private ETContext _context;

      #region Ctor
      public RoleRepository(ETContext context)
      {
         _context = context;
      } 
      #endregion

      public void AddRole(string roleTitle)
      {
         var newRole = new Role(roleTitle);
         _context.Roles.Add(newRole);
         Save();
      }

      public List<RoleVM> GetAll(string roleTitle)
      {
         var query = _context.Roles.Select(x => new RoleVM
         {
            RoleId = x.RoleId,
            RoleTitle = x.RoleTitle
         })
         .AsNoTracking();

         if (!string.IsNullOrWhiteSpace(roleTitle))
            query = query.Where(x => x.RoleTitle.Contains(roleTitle));

         return query.OrderByDescending(x => x.RoleId).ToList();
      }

      public Role GetById(int id)
      {
         return _context.Roles.FirstOrDefault(x => x.RoleId == id);
      }

      public Role GetByTitle(string title)
      {
         return _context.Roles.FirstOrDefault(x => x.RoleTitle.Contains(title));
      }

      public bool IsExsist(string roleTitle)
      {
         return _context.Roles.Any(x => x.RoleTitle == roleTitle);
      }

      public bool IsExsist(int id)
      {
         return _context.Roles.Any(x => x.RoleId == id);
      }

      public void Save() => _context.SaveChanges();

      public void SetPermissions(int roleId , List<Permission> permissions)
      {
         var role = GetById(roleId);

         role.Permissions = permissions;

         //role.Permissions.Clear();
         //permissions.ForEach(p => role.Permissions.Add(p));

         Save();
      }
   }
}