using Core.Data;
using Core.Repository;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Service
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _IRoleRepository;

        public RoleService(IRoleRepository iRoleRepository)
        {
            _IRoleRepository = iRoleRepository;
        }

        public bool deleteRole(int id)
        {
            return _IRoleRepository.deleteRole(id);
        }

        public List<Role> getallRole()
        {
            return _IRoleRepository.getallRole();
        }

        public Role getbyidRole(int id)
        {
            return _IRoleRepository.getbyidRole(id);
        }

        public bool insertRole(Role role)
        {
            return _IRoleRepository.insertRole(role);
        }

        public bool updateRole(Role role)
        {
            return _IRoleRepository.updateRole(role);
        }
    }
}
