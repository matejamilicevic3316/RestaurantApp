using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class OrderArticle
    {
        public int IdOrder { get; set; }
        public int IdArticle { get; set; }
        public int ArticlesNumber { get; set; }
        public double ArticlePrice { get; set; }
        public Order Order { get; set; }
        public Article Article { get; set; }
    }
}
