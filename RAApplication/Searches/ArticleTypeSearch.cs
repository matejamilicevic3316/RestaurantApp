using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Searches
{
    public class ArticleTypeSearch
    {
        [StringLength(40, ErrorMessage = "Too long text")]
        public string Name { get; set; }
    }
}
