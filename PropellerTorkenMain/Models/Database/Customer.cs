using System.Collections.Generic;

#nullable disable

namespace PropellerTorkenMain.Models.Database
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string Address { get; set; }
        public string City { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public string PhoneNr { get; set; }
        public int Zipcode { get; set; }
    }
}