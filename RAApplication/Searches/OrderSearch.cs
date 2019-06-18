using RAApplication.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Searches
{
    public class OrderSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        [Range(1, 100, ErrorMessage = "Value out of radius")]
        public int? IdTable { get; set; }
        [Range(1, 100, ErrorMessage = "Value out of radius")]
        public int? IdWaiter { get; set; }
        public Status? Status { get; set; } 
    }
}
