using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticle;
using RAApplication.ICommands.ICommandsArticleType;
using RAApplication.Requests;
using RAApplication.Searches;
using RestaurantMVC.Models;

namespace RestaurantMVC.Controllers
{
    public class ArticlesController : Controller
    {
        readonly IGetArticles getArticles;
        readonly IGetArticle getArticle;
        readonly IGetArticleTypes getArticleTypes;
        readonly IAddArticle addArticle;
        readonly IUpdateArticle updateArticle;
        readonly IDeleteArticle deleteArticle;
        public ArticlesController(IDeleteArticle deleteArticle, IAddArticle addArticle,IGetArticles getArticles,IGetArticle getArticle,IGetArticleTypes getArticleTypes, IUpdateArticle updateArticle)
        {
            this.getArticles = getArticles;
            this.getArticle = getArticle;
            this.getArticleTypes = getArticleTypes;
            this.addArticle = addArticle;
            this.updateArticle = updateArticle;
            this.deleteArticle = deleteArticle;
        }
        // GET: Articles
        public ActionResult Index([FromQuery]ArticleSearch articleSearch)
        {
            try
            {
                return View(getArticles.Execute(articleSearch).Data);
            }
            catch (NotFoundObjectException e)
            {
                TempData["error"] = e.Message;
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = "Error on Server";
                return StatusCode(500);
            }
        }

        // GET: Articles/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                return View(getArticle.Execute(id));
            }
            catch (NotFoundObjectException e)
            {
                TempData["error"] = e.Message;
                return View();
            }
            catch (Exception e)
            {
                TempData["error"] = "Error on Server";
                return View();
            }
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
                var vm = new CreateArticleModel();
                vm.ArticleTypes = getArticleTypes.Execute(new ArticleTypeSearch());
                return View(vm);
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateArticleModel dto)
        {
            dto.ArticleTypes = getArticleTypes.Execute(new ArticleTypeSearch());
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                this.addArticle.Execute(dto.Article);
                return RedirectToAction(nameof(Index)); 
            }
            catch (ObjectDoesntExistException e)
            {
                TempData["error"]=e.Message;
                return View();
            }
            catch (ObjectAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
                return View();
            }
            catch (Exception)
            {
                TempData["error"] = "Error on server";
                return View();
            }
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            var vm = new CreateArticleModel();
            var articleDTO = getArticle.Execute(id);
            var article = new ArticleRequest();
            article.Name = articleDTO.Name;
            article.Price = articleDTO.Price;
            vm.Article = article;
            vm.ArticleTypes = getArticleTypes.Execute(new ArticleTypeSearch());
            return View(vm);
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateArticleModel dto)
        {
            if (!ModelState.IsValid)
            {
                dto.ArticleTypes = getArticleTypes.Execute(new ArticleTypeSearch());
                return View(dto);
            }
            try
            {
                this.updateArticle.Execute(dto.Article, id);
                return RedirectToAction(nameof(Index));
            }
            catch (ObjectDoesntExistException e)
            {
                TempData["error"] = e.Message;
                return View();
            }
            catch (ObjectAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
                return View();
            }
            catch (Exception)
            {
                TempData["error"] = "Server error";
                return View();
            }
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int id)
        {
            return View(getArticle.Execute(id));
        }

        // POST: Articles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                this.deleteArticle.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ObjectDoesntExistException e)
            {
                TempData["error"] = e.Message;
                return View();
            }
            catch (Exception)
            {
                TempData["error"] = "Server error";
                return View();
            }
        }
    }
}