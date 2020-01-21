using Entities.DataTransferObjects;
using EntityAuth.Core.Services;
using EntityAuth.Core.Uttils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountOwnerServer.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            try
            {
                var nodeRoles = roleRepository.Get(x => x.Parent == null);

                var rolesComposites = nodeRoles.Select(x => new RoleComposite(x));

                return Ok(rolesComposites);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{roleName}", Name = "RoleByName")]
        public IActionResult GetRoleByName(string roleName)
        {
            try
            {
                var role = roleRepository.Get(x => x.Name == roleName);

                if (role == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(role);
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateRole([FromBody]RoleForCreationDto owner)
        {
            try
            {
                if (owner == null)
                {
                    return BadRequest("role object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                roleRepository.Add(owner.ParentRoleName, owner.NewRoleName);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{roleName}")]
        public IActionResult DeleteRole(string roleName)
        {
            try
            {
                var role = roleRepository.Get(x => x.Name == roleName).FirstOrDefault();
                if (role == null)
                {
                    return NotFound();
                }

                roleRepository.Delete(role);

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
