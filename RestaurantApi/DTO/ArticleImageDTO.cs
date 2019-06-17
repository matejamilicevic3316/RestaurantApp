using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApi.DTO
{
    public class ArticleImageDTO
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Name Too Long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int ArticleTypeId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public double Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
