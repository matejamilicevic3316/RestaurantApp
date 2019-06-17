using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Table { get; set; }
        public int IdTable { get; set; }
        public string FullName { get; set; }
        public double TotalPrice { get; set; }
        public List<OrderArticlesDTO> Articles { get; set; }
    }
    public enum Status { paid, storned, active}
}
