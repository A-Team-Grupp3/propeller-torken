using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propeller_torken.Models
{
    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public bool isAdmin { get; set; }

    }
}
