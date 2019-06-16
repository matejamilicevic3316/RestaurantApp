using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAApplication.DTO;
using RAApplication.Exceptions;
using RAApplication.ICommands.ICommandsOrder;
using RAApplication.Requests;
using RAApplication.Searches;
using RestaurantApi.Helpers;

namespace RestaurantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IAddOrderArticle addOrderArticle;
        readonly IGetOrders getOrders;
        readonly IGetOrder getOrder;
        readonly IChangeStatus changeStatus;
        readonly IChangeTable changeTable;
        readonly IDecreaseArticlesOrder decreaseArticlesOrder;
        readonly IDeleteOrder deleteOrder;
        public OrderController(IDeleteOrder deleteOrder,IAddOrderArticle addOrderArticle,IGetOrders getOrders,IGetOrder getOrder, IChangeStatus changeStatus, IChangeTable changeTable, IDecreaseArticlesOrder decreaseArticlesOrder)
        {
            this.addOrderArticle = addOrderArticle;
            this.getOrders = getOrders;
            this.getOrder = getOrder;
            this.changeStatus = changeStatus;
            this.changeTable = changeTable;
            this.decreaseArticlesOrder = decreaseArticlesOrder;
            this.deleteOrder = deleteOrder;
        }
        // GET: api/Order
        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch request)
        {
            try
            {
                return Ok(getOrders.Execute(request));
            }
            catch(ObjectDoesntExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "GetOrder")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(getOrder.Execute(id));
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

        // POST: api/Order
        [HttpPost]
        public IActionResult Post([FromBody] OrderRequest value)
        {
            try
            {
                this.addOrderArticle.Execute(value);
                return NoContent();
            }
            catch(NotFoundObjectException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TableChangeRequest value)
        {
            try
            {
                this.changeTable.Execute(id, value);
                return NoContent();
            }
            catch(ObjectDoesntExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
       
        [HttpPut("Status/{id}")]
        [LoggedIn]
        public IActionResult Status(int id, [FromBody] StatusRequest value)
        {
            try
            {
                this.changeStatus.Execute(value, id);
                return NoContent();
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
        [HttpPut("Decrease/{id}")]
        [LoggedIn]
        public IActionResult Decrease(int id,[FromBody] ArticleDecreaseRequest value)
        {
            try
            {
                this.decreaseArticlesOrder.Execute(value, id);
                return NoContent();
            }
            catch(ObjectDoesntExistException e)
            {
                return UnprocessableEntity(e.Message);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
        }
        // DELETE: api/ApiWithActions/5
        [LoggedIn]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                this.deleteOrder.Execute(id);
                return NoContent();
            }
            catch(ObjectDoesntExistException e)
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
