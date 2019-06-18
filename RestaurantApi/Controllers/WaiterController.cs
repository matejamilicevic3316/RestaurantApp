using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsWaiter;
using RAApplication.Requests;
using RAApplication.Searches;
using RestaurantApi.Helpers;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaiterController : ControllerBase
    {
        IGetWaiter getWaiter;
        IGetWaiters getWaiters;
        IAddWaiter addWaiter;
        IUpdateWaiter updateWaiter;
        IDeleteWaiter deleteWaiter;
        public WaiterController(IGetWaiter getWaiter,IAddWaiter addWaiter, IGetWaiters getWaiters, IUpdateWaiter updateWaiter, IDeleteWaiter deleteWaiter)
        {
            this.getWaiter = getWaiter;
            this.getWaiters = getWaiters;
            this.addWaiter = addWaiter;
            this.updateWaiter = updateWaiter;
            this.deleteWaiter = deleteWaiter;
        }
        /// <summary>
        /// Gets Waiters
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /WaiterSearch
        ///     {
        ///        "IdRole":1
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Waiters with the same role</returns>
        /// <response code="201">Returns the WAITER which has same IdRole</response>
        /// <response code="400">If the IdRole is null</response>    
        // GET: api/Waiter
        [HttpGet]
        public ActionResult<IEnumerable<WaiterDTO>> Get([FromQuery] WaiterSearch search)
        {
            try
            {
                return Ok(getWaiters.Execute(search));
            }
            catch(ObjectDoesntExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        /// <summary>
        /// Gets a Waiter
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Waiter/Id
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Waiters with the id</returns>
        /// <response code="201">Returns the Waiter</response>
        /// <response code="400">If the Waiter is null</response>    
        // GET: api/Waiter/5
        [HttpGet("{id}", Name = "GetWaiter")]
        public ActionResult<WaiterDTO> Get(int id)
        {
            try
            {
                return Ok(getWaiter.Execute(id));
            }
            catch(NotFoundObjectException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Waiter
        /// <summary>
        /// Creates a Waiter.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /WaiterRequest
        ///     {
        ///        "FirstnName": "Ime",
        ///        "LastName": "Prezime",
        ///        "IdRole": 1,
        ///        "Email":"email123@gmail.com
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created Waiter</returns>
        /// <response code="201">Returns the newly created WAITER</response>
        /// <response code="400">If the Waiter is null</response>    
        [LoggedIn("Manager")]
        [HttpPost]
        public ActionResult<WaiterDTO> Post([FromBody] WaiterRequest value)
        {
            try
            {
                var waiter = this.addWaiter.Execute(value);
                return Created("api/Waiter/" + waiter.Id, waiter);
            }
            catch(ObjectDoesntExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
        // PUT: api/Waiter
        /// <summary>
        /// Creates a Waiter.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /WaiterRequest
        ///     {
        ///        "FirstnName": "Ime",
        ///        "LastName": "Prezime",
        ///        "IdRole": 1,
        ///        "Email":"email123@gmail.com
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">If the Waiter is null</response>    
        // PUT: api/Waiter/5
        [LoggedIn]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] WaiterRequest value)
        {
            try
            {
                this.updateWaiter.Execute(value, id);
                return NoContent();
            }
            catch(NotFoundObjectException e)
            {
                return NotFound(e.Message);
            }
            catch(ObjectDoesntExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deletes a specific Waiter.
        /// </summary>
        /// <param name="id"></param>   
        [LoggedIn("Manager")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.deleteWaiter.Execute(id);
                return NoContent();
            }
            catch(ObjectDoesntExistException e)
            {
                return NotFound(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
