using PropellerTorkenMain.Models.Database;
using System.Collections.Generic;

namespace PropellerTorkenMain.Models
{
    public class Cart
    {
        public Cart()
        {
            products = new List<Product>();
        }

        public Customer customer { get; set; }
        public List<Product> products { get; set; }
    }
}