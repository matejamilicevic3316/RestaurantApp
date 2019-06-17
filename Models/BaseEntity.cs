using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
