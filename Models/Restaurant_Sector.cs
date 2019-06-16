using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Restaurant_Sector:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Table> Tables { get; set; }
    }
}
