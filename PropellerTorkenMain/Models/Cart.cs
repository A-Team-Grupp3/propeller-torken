using PropellerTorkenMain.Models.Database;
using System.Collections.Generic;

namespace PropellerTorkenMain.Models
{
    public class Cart
    {
        public List<Product> products { get; set; }
        public Customer customer { get; set; }
        public int CartSum { get; set; }

        public Cart()
        {
            products = new List<Product>();
        }

        public void GetCartSum()
        {
            CartSum = 0;
            for (int i = 0; i < products.Count; i++)
            {
                CartSum += products[i].Price * products[i].Qty;
            }
        }
    }
}