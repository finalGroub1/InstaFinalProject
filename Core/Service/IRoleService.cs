using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IRoleService
    {
        public List<Role> getallRole();
        public bool updateRole(Role role);
        public bool deleteRole(int id);
        public bool insertRole(Role role);
        public Role getbyidRole(int id);
    }
}
