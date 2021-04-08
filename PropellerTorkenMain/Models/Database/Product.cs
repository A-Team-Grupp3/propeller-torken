using System.Collections.Generic;

#nullable disable

namespace PropellerTorkenMain.Models.Database
{
    public partial class Product
    {
        public Product()
        {
            ProductsInOrders = new HashSet<ProductsInOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public virtual ICollection<ProductsInOrder> ProductsInOrders { get; set; }
        public int Qty { get; set; }
    }
}