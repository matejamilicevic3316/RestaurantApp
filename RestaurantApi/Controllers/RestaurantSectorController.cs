using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands;
using RAApplication.Searches;
using RestaurantApi.Helpers;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantSectorController : ControllerBase
    {
        readonly IGetRestaurantSectors getRestaurantSectors;
        readonly IAddRestaurantSector addRestaurantSector;
        readonly IGetRestaurantSector getRestaurantSector;
        readonly IDeleteRestaurantSector deleteRestaurantSector;
        readonly IUpdateRestaurantSector updateRestaurantSector;
        public RestaurantSectorController(IGetRestaurantSectors getRestaurantSectors, IAddRestaurantSector addRestaurantSector, IGetRestaurantSector getRestaurantSector, IDeleteRestaurantSector deleteRestaurantSector, IUpdateRestaurantSector updateRestaurantSector)
        {
            this.getRestaurantSectors = getRestaurantSectors;
            this.addRestaurantSector = addRestaurantSector;
            this.getRestaurantSector = getRestaurantSector;
            this.deleteRestaurantSector = deleteRestaurantSector;
            this.updateRestaurantSector = updateRestaurantSector;
        }
        // GET: api/RestaurantSector
       
        /// <summary>
        /// Gets RestaurantSectors
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /RestaurantSectorSearch
        ///     {
        ///        "Name":"Ime"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>RestaurantSectors</returns>
        /// <response code="201">RestaurantSectors with the similar or same name</response>
        [HttpGet]
        public IActionResult Get([FromQuery] RestaurantSectorSearch search)
        {
            try
            {
                return Ok(getRestaurantSectors.Execute(search));
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        // GET: api/RestaurantSector/5
        /// <summary>
        /// Gets a RestaurantSector
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /RestaurantSector/Id
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>RestaurantSector with the same id</returns>
        /// <response code="201">Returns the RestaurantSector</response>
        /// <response code="400">If the RestaurantSector is null</response>
        [HttpGet("{id}", Name = "GetRS")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getRestaurantSector.Execute(id));
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
        
        /// <summary>
        /// Creates a RestaurantSector.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /RestaurantSector
        ///     {
        ///        "Name": "Roletralala"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created RestaurantSector</returns>
        /// <response code="204">Returns a RestaurantSector</response>
        /// <response code="400">If the RestaurantSector is null</response>
        // POST: api/RestaurantSector
        [LoggedIn("Manager")]
        [HttpPost]
        public IActionResult Post([FromBody] RestaurantSectorDTO value)
        {
            try
            {
                var obj = addRestaurantSector.Execute(value);
                return Created("api/ArticleType/" + obj.Id, obj);
            }
            catch (ObjectAlreadyExistsException e)
            {
                return StatusCode(404);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/RestaurantSector/5
        // PUT: api/RestaurantSector/5
        /// <summary>
        /// Updates a RestaurantSector.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /RestaurantSectorRequest
        ///     {
        ///        "Name": "SectorRandom"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">If the Name is already used</response>
        [LoggedIn("Manager")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] RestaurantSectorDTO value)
        {
            try
            {
                this.updateRestaurantSector.Execute(value, id);
                return NoContent();
            }
            catch(NotFoundObjectException e)
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

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deletes a specific Restaurant Sector.
        /// </summary>
        /// <param name="id"></param>   
        [LoggedIn("Manager")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.deleteRestaurantSector.Execute(id);
                return NoContent();
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
    }
}
