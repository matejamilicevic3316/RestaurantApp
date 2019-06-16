using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsRole;
using RAApplication.Login;
using RAApplication.Searches;
using RestaurantApi.Helpers;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly LoggedUser user;

        readonly IGetRoles getRoles;
        readonly IGetRole getRole;
        readonly IAddRole addRole;
        readonly IUpdateRole updateRole;
        readonly IDeleteRole deleteRole;
        public RoleController(LoggedUser user,IDeleteRole deleteRole,IGetRoles getRoles,IGetRole getRole, IAddRole addRole, IUpdateRole updateRole)
        {
            this.getRoles = getRoles;
            this.getRole = getRole;
            this.addRole = addRole;
            this.updateRole = updateRole;
            this.deleteRole = deleteRole;
            this.user = user;
        }
        // GET: api/Role
        
        [HttpGet]
        public IActionResult Get([FromQuery] RoleSearch search)
        {
            try
            {
                return Ok(getRoles.Execute(search));
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Role/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getRole.Execute(id));
            }
            catch(NotFoundObjectException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Role
        [HttpPost]
        public IActionResult Post([FromBody] RoleDTO role)
        {
            try
            {
                var insert = this.addRole.Execute(role);
                return Created("api/Role/" + insert.Id, insert);
            }
            catch(ObjectAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RoleDTO value)
        {
            try
            {
                this.updateRole.Execute(value, id);
                return NoContent();
            }
            catch (ObjectDoesntExistException e)
            {
                return NotFound(e.Message);
            }
            catch(ObjectAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.deleteRole.Execute(id);
                return NoContent();
            }
            catch(ObjectDoesntExistException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
