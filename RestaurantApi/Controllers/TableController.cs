using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsTable;
using RAApplication.Requests;
using RAApplication.Searches;
using RestaurantApi.Helpers;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        readonly IGetTable getTable;
        readonly IAddTable addTable;
        readonly IGetTables getTables;
        readonly IDeleteTable deleteTable;
        readonly IUpdateTable updateTable;
        public TableController(IGetTable getTable, IAddTable addTable, IGetTables getTables, IDeleteTable deleteTable, IUpdateTable updateTable)
        {
            this.getTable = getTable;
            this.addTable = addTable;
            this.getTables = getTables;
            this.deleteTable = deleteTable;
            this.updateTable = updateTable;
        }
        // GET: api/Table
        [HttpGet]
        public IActionResult Get([FromQuery]TableSearch search)
        {
            try
            {
                return Ok(getTables.Execute(search));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Table/5
        [HttpGet("{id}", Name = "GetTable")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getTable.Execute(id));
            }
            catch(NotFoundObjectException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Table
        [LoggedIn("Manager")]
        [HttpPost]
        public IActionResult Post([FromBody] TableRequest request)
        {
            try
            {
                var result = this.addTable.Execute(request);
                return Created("api/Table/" + result.Id, result);
            }
            catch(ObjectDoesntExistException e)
            {
                return NotFound(e.Message);
            }
            catch(ObjectAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Table/5
        [LoggedIn("Manager")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TableRequest value)
        {
            try
            {
                this.updateTable.Execute(value, id);
                return NoContent();
            }
            catch (ObjectDoesntExistException e)
            {
                return NotFound(e.Message);
            }
            catch (ObjectAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
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
                this.deleteTable.Execute(id);
                return NoContent();
            }
            catch (ObjectDoesntExistException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
