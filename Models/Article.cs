using System.Collections.Generic;

namespace Domain
{
    public class Article:BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int IdArtical_type { get; set; }
        public Article_type Artical_Type { get; set; }
        public ICollection<OrderArticle> OrderArticles { get; set; }
        public string Image { get; set; }
    }
}
