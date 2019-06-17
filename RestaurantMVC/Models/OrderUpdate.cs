using RAApplication.DTO;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMVC.Models
{
    public class OrderUpdate
    {
        public Status Status { get; set; }
        public OrderRequest OrderRequest { get; set; }
        public TableChangeRequest TableChangeRequest { get; set; }
        public ArticleDecreaseRequest ArticleDecreaseRequest { get; set; }
        public OrderDTO orderDTO { get; set; } 
        public IEnumerable<TableDTO> Tables { get; set; }
        public IEnumerable<ArticleDTO> Articles { get; set; }
        public IEnumerable<ArticleDTO> ArticlesAll { get; set; }
    }
}
