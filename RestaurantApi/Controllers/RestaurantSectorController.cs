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

        // POST: api/RestaurantSector
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
