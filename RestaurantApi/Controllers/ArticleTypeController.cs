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
        [HttpGet]
        public IActionResult Get([FromQuery] ArticleTypeSearch search)
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
        [HttpGet("{id}", Name = "GetAT")]
        public IActionResult Get(int id)
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
        [HttpPost]
        public IActionResult Post([FromBody] ArticleTypeDTO value)
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
