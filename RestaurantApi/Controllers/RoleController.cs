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
        /// <summary>
        /// Gets Role
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /RoleSearch
        ///     {
        ///        "Name":"RoleName"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Roles</returns>
        /// <response code="201">Roles with the similar or same name</response>
      
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
        /// <summary>
        /// Gets a Role
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Role/Id
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Role with the same id</returns>
        /// <response code="201">Returns the Role</response>
        /// <response code="400">If the Role is null</response>
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
        /// <summary>
        /// Creates a Role.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /RoleRequest
        ///     {
        ///        "Name": "Roletralala"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created role</returns>
        /// <response code="204">Returns a Role</response>
        /// <response code="400">If the Role is null</response>
        [LoggedIn("Manager")]
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
        /// <summary>
        /// Updates a Role.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /TableRequest
        ///     {
        ///        "Name": "Tabletralala"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">If the Name is already used</response>
        [LoggedIn("Manager")]
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
        /// <summary>
        /// Deletes a specific Role for Waiter.
        /// </summary>
        /// <param name="id"></param>   
        [LoggedIn("Manager")]
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
