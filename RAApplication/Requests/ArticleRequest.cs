using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Requests
{
    public class ArticleRequest
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Name Too Long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int ArticleTypeId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
