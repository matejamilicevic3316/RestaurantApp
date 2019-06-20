using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsArticle;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.ICommands.ICommandsTable;
using RAApplication.ICommands.ICommandsWaiter;
using RAApplication.Requests;
using RAApplication.Searches;
using RestaurantMVC.Models;

namespace RestaurantMVC.Controllers
{
    public class OrdersController : Controller
    {
        readonly IGetOrders getOrders;
        readonly IGetOrder getOrder;
        readonly IGetArticles getArticles;
        readonly IGetWaiters getWaiters;
        readonly IGetTables getTables;
        readonly IAddOrderArticle addOrderArticle;
        readonly IChangeTable changeTable;
        readonly IDecreaseArticlesOrder decreaseArticlesOrder;
        readonly IDeleteOrder deleteOrder;
        readonly IChangeStatus changeStatus;
        public OrdersController(IChangeStatus changeStatus, IDeleteOrder deleteOrder, IDecreaseArticlesOrder decreaseArticlesOrder, IChangeTable changeTable, IAddOrderArticle addOrderArticle,IGetTables getTables, IGetArticles getArticles, IGetWaiters getWaiters, IGetOrders getOrders,IGetOrder getOrder)
        {
            this.getOrders = getOrders;
            this.getOrder = getOrder;
            this.getTables = getTables;
            this.getWaiters = getWaiters;
            this.getArticles = getArticles;
            this.addOrderArticle = addOrderArticle;
            this.changeTable = changeTable;
            this.decreaseArticlesOrder = decreaseArticlesOrder;
            this.deleteOrder = deleteOrder;
            this.changeStatus = changeStatus;
        }
        // GET: Orders
        public ActionResult Index([FromQuery] OrderSearch orderSearch)
        {
            try
            {
                return View(getOrders.Execute(orderSearch));
            }
            catch (ObjectDoesntExistException e)
            {
                TempData["error"] = e.Message;
                return View(nameof(Index));
            }
            catch (Exception)
            {
                TempData["error"] = "Server error";
                return View(nameof(Index));
            }
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            try
            { 
                return View(getOrder.Execute(id));
            }
            catch (NotFoundObjectException e)
            {
                TempData["Error"] = e.Message;
                return View(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = "Server error";
                return View(nameof(Index));
            }
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            var co = new CreateOrderModel();
            co.Articles = getArticles.Execute(new ArticleSearch() { PerPage = 1000 }).Data;
            co.Tables = getTables.Execute(new TableSearch() { IsFree=true });
            co.Waiters = getWaiters.Execute(new WaiterSearch());
            return View(co);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateOrderModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Articles = getArticles.Execute(new ArticleSearch() { PerPage = 1000 }).Data;
                model.Tables = getTables.Execute(new TableSearch() { IsFree = true });
                model.Waiters = getWaiters.Execute(new WaiterSearch());
                return View(model);
            }
            try
            {
                this.addOrderArticle.Execute(model.OrderRequest);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundObjectException e)
            {
                TempData["Error"] = e.Message;
                return View(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = "Server error";
                return View(nameof(Index));
            }
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int id)
        {
            var OrderUpdate = new OrderUpdate();
            OrderUpdate.orderDTO = getOrder.Execute(id);
            OrderUpdate.Articles = getArticles.Execute(new ArticleSearch { IdOrder = id,PerPage=1000 }).Data;
            OrderUpdate.Tables = getTables.Execute(new TableSearch { IsFree = true });
            OrderUpdate.ArticlesAll = getArticles.Execute(new ArticleSearch()).Data;
            return View(OrderUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,OrderUpdate orderUpdate)
        {
            if (!ModelState.IsValid)
            {
                orderUpdate.orderDTO = getOrder.Execute(id);
                orderUpdate.Articles = getArticles.Execute(new ArticleSearch { IdOrder = id, PerPage = 1000 }).Data;
                orderUpdate.Tables = getTables.Execute(new TableSearch { IsFree = true });
                orderUpdate.ArticlesAll = getArticles.Execute(new ArticleSearch()).Data;
                return View(orderUpdate);
            }
            if (orderUpdate.TableChangeRequest != null)
            {
                try
                {
                    this.changeTable.Execute(id, orderUpdate.TableChangeRequest);
                    return RedirectToAction(nameof(Index));
                }
                catch (NotFoundObjectException e)
                {
                    TempData["Error"] = e.Message;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    TempData["Error"] = "Server error";
                    return RedirectToAction(nameof(Index));
                }
            }
            if (orderUpdate.ArticleDecreaseRequest != null)
            {
                try
                {
                    this.decreaseArticlesOrder.Execute(orderUpdate.ArticleDecreaseRequest, id);
                    return RedirectToAction(nameof(Index));
                }
                catch (ObjectDoesntExistException e)
                {
                    TempData["Error"] = e.Message;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    TempData["Error"] = "Server error";
                    return RedirectToAction(nameof(Index));
                }
            }
            if (orderUpdate.OrderRequest != null)
            {
                try
                {
                    orderUpdate.OrderRequest.IdTable = getOrder.Execute(id).IdTable;
                    this.addOrderArticle.Execute(orderUpdate.OrderRequest);
                    return RedirectToAction(nameof(Edit));
                }
                catch (NotFoundObjectException e)
                {
                    TempData["Error"] = e.Message;
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    TempData["Error"] = "Server error";
                    return RedirectToAction(nameof(Index));
                }
            }
            if (orderUpdate.Status != null)
            {
                try
                {
                    this.changeStatus.Execute(new StatusRequest { status =  orderUpdate.Status }, id);   
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {
                    TempData["Error"] = "Server error";
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View(getOrder.Execute(id));
        }

        // POST: Orders/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                deleteOrder.Execute(id);
                return RedirectToAction(nameof(Index));
            }
            catch (ObjectDoesntExistException e)
            {
                TempData["Error"] = e.Message;
                return View(nameof(Index));
            }
            catch (Exception e)
            {
                TempData["Error"] = "Server error";
                return View(nameof(Index));
            }
        }
    }
}
