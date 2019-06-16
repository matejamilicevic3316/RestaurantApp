using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RAApplication.Searches
{
    public class WaiterSearch
    {
        [Range(1, 50, ErrorMessage = "Not in the radius")]
        public int? IdRole { get; set; }
    }
}
