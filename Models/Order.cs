using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Order:BaseEntity
    {
        public int IdTable { get; set; }
        public int IdWaiter { get; set; }
        public bool Active { get; set; }
        public bool IsPaid { get; set; }
        public bool IsStorned { get; set; }
        public Waiter Waiter { get; set; }
        public Table Table { get; set; }
        public ICollection<OrderArticle> OrderArticles { get; set; }
    }
}
