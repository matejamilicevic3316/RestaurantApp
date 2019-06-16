using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // GET: api/Waiter
        [HttpGet]
        public IActionResult Get([FromQuery] WaiterSearch search)
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

        // GET: api/Waiter/5
        [HttpGet("{id}", Name = "GetWaiter")]
        public IActionResult Get(int id)
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
        [LoggedIn("Manager")]
        [HttpPost]
        public IActionResult Post([FromBody] WaiterRequest value)
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
