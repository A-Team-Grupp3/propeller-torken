using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PropellerTorkenMain.Models;
using PropellerTorkenMain.Services;
using System.Linq;

namespace PropellerTorkenMain.Controllers
{
    public class CartController : Controller
    {
        private ProductService pc;

        public CartController()
        {
            pc = new ProductService();
        }

        public void IncrementQty(string productname)
        {
            var str = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<Cart>(str);
            if (cart.products.Any(product => product.Name == productname))
            {
                cart.products.Find(product => product.Name == productname).Qty++;
            }

            str = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", str);
        }

        public IActionResult IncrementQtyForProduct()
        {
            IncrementQty("PropellerKeps2");

            return View("Index");
        }

        public IActionResult Index()
        {
            var str = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<Cart>(str);

            return View(cart);
        }
    }
}