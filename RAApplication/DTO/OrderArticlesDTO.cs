using System;
using System.Collections.Generic;
using System.Text;

namespace RAApplication.DTO
{
    public class OrderArticlesDTO
    {
        public string ArticleName { get; set; }
        public int ArticleNumber { get; set; }
        public double TotalArticlesPrice { get; set; }
    }
}
