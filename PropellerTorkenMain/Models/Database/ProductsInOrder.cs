#nullable disable

namespace PropellerTorkenMain.Models.Database
{
    public partial class ProductsInOrder
    {
        public int Amount { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}