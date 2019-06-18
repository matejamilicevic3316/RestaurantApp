using RAApplication.DTO;
using RAApplication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantMVC.Models
{
    public class CreateArticleModel
    {
        public ArticleRequest Article { get; set; }
        public IEnumerable<ArticleTypeDTO> ArticleTypes { get; set; }
    }
}
