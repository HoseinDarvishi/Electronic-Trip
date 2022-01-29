using ET.Constracts;
using ET.Constracts.PermissionContracts;
using ET.Constracts.RoleConstracts;
using ET.Domain.RoleAgg;
using ET.Tools;
using System.Collections.Generic;

namespace ET.Service.Services
{
   public class RoleService : IRoleService
   {
      private IRoleRepository _roleRepo;

      #region Ctor
      public RoleService(IRoleRepository roleRepository)
      {
         _roleRepo = roleRepository;
      } 
      #endregion

      public OperationResult AddRole(string roleTitle)
      {
         if (_roleRepo.IsExsist(roleTitle.Trim())) return new OperationResult().Failed(Messages.ExsistRoleTitle);
         _roleRepo.AddRole(roleTitle.Trim());
         return new OperationResult().Success(Messages.SuccessAddingRole);
      }

      public OperationResult EditRole(EditRole editRole)
      {
         Role role = _roleRepo.GetById(editRole.RoleId);

         if (role == null) return new OperationResult().Failed(Messages.NotFound);

         Role existsRole = _roleRepo.GetByTitle(editRole.RoleTitle.Trim());

         if (existsRole != null && existsRole.RoleId != editRole.RoleId)
            return new OperationResult().Failed(Messages.ExsistRoleTitle);

         role.Edit(editRole.RoleTitle);
         _roleRepo.Save();

         return new OperationResult().Success(Messages.SuccessEditRole);
      }

      public List<RoleVM> GetAll(string roleTitle)
      {
         return _roleRepo.GetAll(roleTitle);
      }

      public EditRole GetById(int id)
      {
         var role = _roleRepo.GetById(id);
         return new EditRole { RoleId = role.RoleId, RoleTitle = role.RoleTitle };
      }

      public string GetNameById(int id)
      {
         var role = _roleRepo.GetById(id);
         if (role != null) return role.RoleTitle;
         return string.Empty;
      }

      public OperationResult SetPermissions(SetPermissions permissionsVM)
      {
         var role = _roleRepo.GetById(permissionsVM.RoleId);

         if (role == null) 
            return new OperationResult().Failed(Messages.NotFound);

         List<Permission> permissions = new List<Permission>();
         permissionsVM.Permissions.ForEach(p => permissions.Add(new Permission(p.Code)));

         _roleRepo.SetPermissions(permissionsVM.RoleId, permissions);
         return new OperationResult().Success(Messages.Success);
      }
   }
}
