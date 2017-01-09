using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uow, IRoleRepository repository)
        {
            this.uow = uow;
            this.roleRepository = repository;
        }
        public void AddRole(BllRole role)
        {
            roleRepository.Create(role.ToDalRole());
            uow.Commit();
        }

        public void DeleteRole(BllRole role)
        {
            roleRepository.Delete(role.ToDalRole());
            uow.Commit();
        }

        public List<BllRole> GetAllRoles()
        {
            return roleRepository.GetAll().Select(u=>u.ToBllRole()).ToList();
        }

        public void UpdateRole(BllRole role)
        {
            roleRepository.Update(role.ToDalRole());
        }

        public BllRole GetRoleById(int key)
        {
            return roleRepository.GetById(key).ToBllRole();
        }
    }
}
