using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "this field is required")]
        [MaxLength(30, ErrorMessage = "Max length for this field is 30")]
        [MinLength(3, ErrorMessage = "Min length for this field is 3")]
        public string Name { get; set; }
    }
}
