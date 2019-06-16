using RAApplication.DTO;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMVC.Models
{
    public class CreateOrderModel
    {
        public OrderRequest OrderRequest { get; set; }
        public IEnumerable<ArticleDTO> Articles { get; set; }
        public IEnumerable<TableDTO> Tables { get; set; }
        public IEnumerable<WaiterDTO> Waiters { get; set; }
    }
}
