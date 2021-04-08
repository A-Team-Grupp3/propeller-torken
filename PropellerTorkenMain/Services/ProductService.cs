using PropellerTorkenMain.Models.Database;
using System.Collections.Generic;
using System.Linq;

namespace PropellerTorkenMain.Services
{
    public class ProductService
    {
        private PropellerDataContext pdc;

        public ProductService()
        {
            pdc = new PropellerDataContext();
        }

        public List<Product> productList { get; set; }

        public string AddProduct(string name, int price, int qty)
        {
            pdc.Products.Add(new Product() { Name = name, Price = price, Qty = qty });
            pdc.SaveChanges();
            return "New product was succesfully created";
        }

        public string DeleteProduct(int id)
        {
            var productToDelete = pdc.Products.Where(p => p.Id == id).Single<Product>();
            pdc.Products.Remove(productToDelete);
            pdc.SaveChanges();
            return "Record was successfully deleted";
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return pdc.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByName(string s)
        {
            if (string.IsNullOrEmpty(s))

            {
                return pdc.Products.ToList();
            }
            else
            {
                return pdc.Products.Where(p => p.Name.ToLower().Contains(s)).ToList();
            }
        }
    }
}