using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.Helpers;
using RAApplication.ICommands.ICommandsArticle;
using RAApplication.Requests;
using RAApplication.Searches;
using RestaurantApi.DTO;
using RestaurantApi.Helpers;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        readonly IGetArticle getArticle;
        readonly IGetArticles getArticles;
        readonly IAddArticle addArticle;
        readonly IDeleteArticle deleteArticle;
        readonly IUpdateArticle updateArticle;

        public ArticleController(IGetArticle getArticle, IGetArticles getArticles, IAddArticle addArticle, IDeleteArticle deleteArticle, IUpdateArticle updateArticle)
        {
            this.getArticle = getArticle;
            this.getArticles = getArticles;
            this.updateArticle = updateArticle;
            this.addArticle = addArticle;
            this.deleteArticle = deleteArticle;
            
        }
        // GET: api/Article
        /// <summary>
        /// Gets Articles
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /RoleSearch
        ///     {
        ///        "IdArticleType":1,
        ///        "IdOrder":1,
        ///        "Keyword":"word",
        ///        "Perpage":5,
        ///        "Pagenumber":1
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Roles</returns>
        /// <response code="201">Roles with the similar or same name</response>
        [HttpGet]
        public ActionResult<IEnumerable<ArticleDTO>> Get([FromQuery] ArticleSearch search)
        {
            try
            {
                return Ok(getArticles.Execute(search).Data);
            }
            catch (NotFoundObjectException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
        
        /// <summary>
        /// Gets a Article
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Article/Id
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Article with the same id</returns>
        /// <response code="201">Returns the Article</response>
        /// <response code="400">If the Article is null</response>
        // GET: api/Article/5
        [HttpGet("{id}", Name = "GetArticle")]
        public ActionResult<ArticleDTO> Get(int id)
        {
            try
            {
                return Ok(getArticle.Execute(id));
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

        // POST: api/Article
        /// <summary>
        /// Creates a Article.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Post /ArticleImageDTO
        ///     {
        ///        "Name": "Article35",
        ///        "ArticleTypeId":1,
        ///        "Price":120,
        ///        "Image":Image
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created Article</returns>
        /// <response code="201">Returns a Article</response>
        /// <response code="400">If the Article is null</response>
        [LoggedIn]
        [HttpPost]
        public ActionResult<ArticleDTO> Post([FromForm] ArticleImageDTO p)
        {
            var ext = Path.GetExtension(p.Image.FileName); //.gif

            if (!FileUpload.AllowedExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                
            
            try
            {
                    var ArticleRequest = new ArticleRequest
                    {
                        Image=newFileName,
                        ArticleTypeId=p.ArticleTypeId,
                        Name=p.Name,
                        Price=p.Price
                    };
                var article = this.addArticle.Execute(ArticleRequest);
                return Created("api/Article/" + article.Id, article);
            }
            catch (ObjectDoesntExistException e)
            {
                return NotFound(e.Message);
            }
            catch (ObjectAlreadyExistsException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Article/5
        /// <summary>
        /// Updates a Article.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///      PUT /ArticleRequest
        ///     {
        ///        "Name": "Article35",
        ///        "ArticleTypeId":1,
        ///        "Price":120
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">If the Name is already used</response>
        [LoggedIn]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ArticleRequest value)
        {
            try
            {
                this.updateArticle.Execute(value, id);
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
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// Deletes a specific Article.
        /// </summary>
        /// <param name="id"></param>   
        [LoggedIn("Manager")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.deleteArticle.Execute(id);
                return NoContent();
            }
            catch (ObjectDoesntExistException e)
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
