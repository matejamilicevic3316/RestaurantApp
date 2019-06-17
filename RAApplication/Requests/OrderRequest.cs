using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Requests
{
    public class OrderRequest
    {
        [Required(ErrorMessage = "This field is required")]
        public int IdArticle { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int IdTable { get; set; }
        public int? IdWaiter { get; set; }
    }
}
