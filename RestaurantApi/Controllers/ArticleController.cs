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
        [HttpGet]
        public IActionResult Get([FromQuery] ArticleSearch search)
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

        // GET: api/Article/5
        [HttpGet("{id}", Name = "GetArticle")]
        public IActionResult Get(int id)
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
        [LoggedIn]
        [HttpPost]
        public IActionResult Post([FromForm] ArticleImageDTO p)
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
