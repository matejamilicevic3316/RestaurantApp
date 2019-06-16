using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Article_type:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
