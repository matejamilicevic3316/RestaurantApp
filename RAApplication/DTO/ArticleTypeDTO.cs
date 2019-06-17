using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.DTO
{
    public class ArticleTypeDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="this field is required")]
        [MaxLength(30,ErrorMessage ="this field maximum length is 30")]
        [MinLength(3,ErrorMessage ="this field minimum length is 3")]
        public string Name { get; set; }
    }
}
