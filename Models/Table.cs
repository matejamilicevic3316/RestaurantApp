using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Table:BaseEntity
    {
        public string Name { get; set; }
        public int IdRestaurant_sector { get; set; }
        public Restaurant_Sector Restaurant_Sector { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
