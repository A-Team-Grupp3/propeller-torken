using PropellerTorkenMain.Models.Database;
using System.Collections.Generic;
using PropellerTorkenMain.Services;

namespace PropellerTorkenMain.Models
{
    public class Cart
    {
        public Cart()
        {
            Products = new List<Product>();
        }

        public int CartSum { get; set; }
        public DummyCustomer Customer { get; set; }
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }

        public void GetCartSum()
        {
            CartSum = 0;
            for (int i = 0; i < Products.Count; i++)
            {
                CartSum += Products[i].Price * Products[i].Qty;
            }
        }
    }
}