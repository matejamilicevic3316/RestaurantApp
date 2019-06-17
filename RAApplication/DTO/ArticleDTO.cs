using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArticleType { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
