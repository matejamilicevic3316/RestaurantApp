using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Waiter:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdRole { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
