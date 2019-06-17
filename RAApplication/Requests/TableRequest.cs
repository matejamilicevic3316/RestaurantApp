using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Requests
{
    public class TableRequest
    {
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Name Too Long")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Range(1,10,ErrorMessage ="Not in value radius")]
        public int IdSector { get; set; }
    }
}
