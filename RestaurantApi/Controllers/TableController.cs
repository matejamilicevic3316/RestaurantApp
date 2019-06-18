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
        /// <summary>
        /// Gets Tables
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /TableSearch
        ///     {
        ///        "IdRestaurantSector":1,
        ///        "IsFree":true
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Waiters with the same role</returns>
        /// <response code="201">Returns the WAITER which has same IdRole</response>
         
        [HttpGet]
        public ActionResult<IEnumerable<TableDTO>> Get([FromQuery]TableSearch search)
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
        /// <summary>
        /// Gets a Table
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Table/Id
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Table with the same id</returns>
        /// <response code="201">Returns the Table</response>
        /// <response code="400">If the Table is null</response>
        [HttpGet("{id}", Name = "GetTable")]
        public ActionResult<TableDTO> Get(int id)
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
        /// <summary>
        /// Creates a Table.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /TableRequest
        ///     {
        ///        "Name": "Tabletralala",
        ///        "IdSector": "1",
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created Table</returns>
        /// <response code="201">Returns the newly created WAITER</response>
        /// <response code="400">If the Table is null</response>    
        [LoggedIn("Manager")]
        [HttpPost]
        public ActionResult<TableDTO> Post([FromBody] TableRequest request)
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
        
        /// <summary>
        /// Updates a Table.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /TableRequest
        ///     {
        ///        "Name": "Tabletralala",
        ///        "IdSector": "1",
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">If the Sector is null</response>
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
        /// <summary>
        /// Deletes a specific Table.
        /// </summary>
        /// <param name="id"></param>   
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
