using RAApplication.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Requests
{
    public class StatusRequest
    {
        [Required(ErrorMessage = "This field is required")]
        public Status status { get; set; }
    }
}
