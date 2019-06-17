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
        
        /// <summary>
        /// Gets Orders
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /OrderSearch
        ///     {
        ///        "DateFrom":date,
        ///        "DateTo":date,
        ///        "IdWaiter":1,
        ///        "IdTable":1,
        ///        "Status":"active"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Waiters with the same role</returns>
        /// <response code="201">Returns the WAITER which has same IdRole</response>
        /// <response code="400">If the IdRole is null</response>    
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
        
        /// <summary>
        /// Gets a Order
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Order/Id
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Order with the same id</returns>
        /// <response code="201">Returns the Order</response>
        /// <response code="400">If the Order is null</response>
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
        /// <summary>
        /// Creates Order or updates a OrderArticle of the current Order.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /OrderRequest
        ///     {
        ///        "IdArticle": 1,
        ///        "IdTable": 1,
        ///        "IdWaiter": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No content</returns>
        /// <response code="201">Returns NoContent</response>
        /// <response code="400">If the Table,Waiter or Article is null</response>    
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
        /// <summary>
        /// Changes a table of order.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /StatusRequest
        ///     {
        ///        "status":"paid"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">if the Table doesnt exist</response>
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
        // PUT: api/Order/Status/5
        /// <summary>
        /// Updates a Order, changes order status.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /StatusRequest
        ///     {
        ///        "status":"paid"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">if the status is not paid or storned</response>

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
        // PUT: api/Order/Decrease/5
        /// <summary>
        /// Updates a OrderArticle.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /ArticleDecreaseRequest
        ///     {
        ///        "IdArticle": 1,
        ///        "DeleteAll":[0,1]
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>No Content</returns>
        /// <response code="204">Returns No Content</response>
        /// <response code="400">If the Article doesnt exist, or if DeleteAll is not 0 or 1</response>
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
        /// <summary>
        /// Deletes a specific Order.
        /// </summary>
        /// <param name="id"></param>   
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
