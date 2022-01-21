﻿using ET.Constracts.RoleConstracts;
using ET.Data.Context;
using ET.Domain.RoleAgg;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ET.Data.Repositories
{
   public class RoleRepository : IRoleRepository
   {
      private ETContext _context = new ETContext();

      public void AddRole(CreateRole role)
      {
         var newRole = new Role(role.RoleTitle);
         _context.Roles.Add(newRole);
         Save();
      }

      public List<RoleVM> GetAll(SearchRole search)
      {
         var query = _context.Roles.Select(x => new RoleVM
         {
            RoleId = x.RoleId,
            RoleTitle = x.RoleTitle
         })
         .AsNoTracking();

         if (!string.IsNullOrWhiteSpace(search.RoleTitle))
            query = query.Where(x => x.RoleTitle.Contains(search.RoleTitle));

         return query.OrderByDescending(x => x.RoleId).ToList();
      }

      public RoleVM GetById(int id)
      {
         return _context.Roles.Select(x => new RoleVM
         {
            RoleId = x.RoleId,
            RoleTitle = x.RoleTitle
         })
         .AsNoTracking()
         .FirstOrDefault(x => x.RoleId == id);
      }

      public RoleVM GetByTitle(string title)
      {
         return _context.Roles.Select(x => new RoleVM
         {
            RoleId = x.RoleId,
            RoleTitle = x.RoleTitle
         })
         .AsNoTracking()
         .FirstOrDefault(x => x.RoleTitle.Contains(title));
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
   }
}