using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Requests
{
    public class WaiterRequest
    {
        [Required(ErrorMessage ="This field is required")]
        [MaxLength(20,ErrorMessage ="Name Too Long")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(20, ErrorMessage = "Name Too Long")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [Range(1,10,ErrorMessage ="Must be in radius from 1 to 10")]
        public int IdRole { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(70, ErrorMessage = "Name Too Long")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
    }
}
