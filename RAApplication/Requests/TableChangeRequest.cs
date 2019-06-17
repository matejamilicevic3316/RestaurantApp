using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Requests
{
    public class TableChangeRequest
    {
        [Required(ErrorMessage = "This field is required")]
        public int IdTable { get; set; }
    }
}
