using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Searches
{
    public class ArticleSearch
    {
        [Range(1,100,ErrorMessage ="Value out of radius")]
        public int? IdArticleType { get; set; }
        [Range(1,1000,ErrorMessage ="Value out of radius")]
        public int? IdOrder { get; set; }
        [StringLength(40,ErrorMessage ="Too long text")]
        public string Keyword { get; set; }
        public int PerPage { get; set; } = 5;
        public int PageNumber { get; set; } = 1;
    }
}
