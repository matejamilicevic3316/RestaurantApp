using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Requests
{
    public class ArticleDecreaseRequest
    {
        [Required(ErrorMessage = "This field is required")]
        public int IdArticle { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Range(0,1,ErrorMessage ="Not valid value")]
        public int DeleteAll { get; set; }
    }
}
