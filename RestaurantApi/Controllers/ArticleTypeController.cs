using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticleType;
using RAApplication.Searches;
using RestaurantApi.Helpers;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleTypeController : ControllerBase
    {
        readonly IGetArticleTypes getArticleTypes;
        readonly IGetArticleType getArticleType;
        readonly IAddArticleType addArticleType;
        readonly IUpdateArticleType updateArticleType;
        readonly IDeleteArticleType deleteArticleType;

        public ArticleTypeController(IGetArticleTypes getArticleTypes,IGetArticleType getArticleType,IAddArticleType addArticleType,IUpdateArticleType updateArticleType,IDeleteArticleType deleteArticleType)
        {
            this.getArticleTypes = getArticleTypes;
            this.getArticleType = getArticleType;
            this.addArticleType = addArticleType;
            this.updateArticleType = updateArticleType;
            this.deleteArticleType = deleteArticleType;
        }
        // GET: api/ArticleType
        /// <summary>
        /// Gets ArticleTypes
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /ArticleTypeSearch
        ///     {
        ///        "Name":"Type"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>ArticleTypes</returns>
        /// <response code="201">ArticleTypes with the similar or same name</response>
        [HttpGet]
        public ActionResult<IEnumerable<ArticleTypeDTO>> Get([FromQuery] ArticleTypeSearch search)
        {
            try
            {
                return Ok(getArticleTypes.Execute(search));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // GET: api/ArticleType/5
        /// <summary>
        /// Gets a ArticleType
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /ArticleType/Id
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>ArticleType with the same id</returns>
        /// <response code="201">Returns the ArticleType</response>
        /// <response code="400">If the ArticleType is null</response>
        [HttpGet("{id}", Name = "GetAT")]
        public ActionResult<ArticleTypeDTO> Get(int id)
        {
            try
            {
                return Ok(getArticleType.Execute(id));
            }
            catch (NotFoundObjectException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        // POST: api/ArticleType
        /// <summary>
        /// Creates a ArticleType.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /ArticleTypeDTO
        ///     {
        ///        "Name": "Ime tralala"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created ArticleType</returns>
        /// <response code="204">Returns a ArticleType</response>
        /// <response code="400">If the ArticleType is null</response>
        [LoggedIn("Manager")]
        [HttpPost]
        public ActionResult<ArticleTypeDTO> Post([FromBody] ArticleTypeDTO value)
        {
            try
            {
                var obj=addArticleType.Execute(value);
                return Created("api/ArticleType", obj);
            }
            catch(ObjectAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT: api/ArticleType/5
        /// <summary>
        /// Updates a ArticleType.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /ArticleTypeDTO
        ///     {
        ///        "Name": "Name"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">If the Name is already used</response>
        [LoggedIn("Manager")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ArticleTypeDTO value)
        {
            try
            {
                this.updateArticleType.Execute(value, id);
                return NoContent();
            }
            catch(ObjectDoesntExistException e)
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
        /// Deletes a specific Article Type.
        /// </summary>
        /// <param name="id"></param>   
        [LoggedIn("Manager")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.deleteArticleType.Execute(id);
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
