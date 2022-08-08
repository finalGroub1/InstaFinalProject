using Core.Data;
using Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaFinalProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        //dsbfkjsfnkjsndhaya //dskjfnskjdnckjsnd //jksdhfjksdkjsb //jdksbckjsdbckj //hvkhvkjv
        private readonly IRoleService _IRoleService; //haya

        public RoleController(IRoleService IRoleService)
        {
            _IRoleService = IRoleService;
        }
        [HttpDelete("{id}")]
        public bool deleteRole(int id)
        {
            return _IRoleService.deleteRole(id);
        }
        [HttpGet]
        public List<Role> getallRole()
        {
            return _IRoleService.getallRole();
        }

        [HttpGet("{id}")]
        public Role getbyidRole(int id)
        {
            return _IRoleService.getbyidRole(id);
        }


        [HttpPost]
        public bool insertRole([FromBody]Role role)
        {
            return _IRoleService.insertRole(role);
        }
        [HttpPut]
        public bool updateRole(Role role)
        {
            return _IRoleService.updateRole(role);
        }

        [HttpPut]
        public bool updateRoleksjfnf(Role role)
        {
            return _IRoleService.updateRole(role);
        }

    }
}
