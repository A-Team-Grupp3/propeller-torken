using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PropellerTorkenMain.Models;
using PropellerTorkenMain.Models.Database;
using PropellerTorkenMain.Services;
using System.Linq;

namespace PropellerTorkenMain.Controllers
{
    public class ProductController : Controller
    {
        private PropellerDataContext _ctx = new PropellerDataContext();
        private ProductService pc;

        public ProductController()
        {
            pc = new ProductService();
        }

          public IActionResult Index()
        {
            return View();
        }

        public IActionResult PropellerKepsar()
        {
            return View();
        }
          public IActionResult TorkTumlare()
        {
            return View();
        }

        public IActionResult CreateSessionForItem1()
        {
            SessionHandler("PropellerKeps1");

            return View("PropellerKepsar");
        }

        public IActionResult CreateSessionForItem2()
        {
            SessionHandler("PropellerKeps2");

            return View("PropellerKepsar");
        }

        public IActionResult CreateSessionForItem3()
        {
            SessionHandler("PropellerKeps3");

            return View("PropellerKepsar");
        }

        public IActionResult CreateSessionForItem4()
        {
            SessionHandler("Torktumlare1");

            return View("Torktumlare");
        }

        public IActionResult CreateSessionForItem5()
        {
            SessionHandler("Torktumlare2");

            return View("Torktumlare");
        }

        public IActionResult CreateSessionForItem6()
        {
            SessionHandler("Torktumlare3");
            return View("Torktumlare");
        }

        public void SessionHandler(string productname)
        {
            if (HttpContext.Session.GetString("cart") == null)
            {
                Cart cart = new Cart();
                var product = pc.GetProductsByName(productname).FirstOrDefault();

                cart.Products.Add(product);
                cart.CartSum = cart.Products.FirstOrDefault().Price;

                var str = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString("cart", str);
            }
            else
            {
                var str = HttpContext.Session.GetString("cart");
                var cart = JsonConvert.DeserializeObject<Cart>(str);
                if (cart.Products.Any(product => product.Name == productname))
                {
                    cart.Products.Find(product => product.Name == productname).Qty++;
                    cart.GetCartSum();
                }
                else
                {
                    var product = pc.GetProductsByName(productname).FirstOrDefault();
                    cart.Products.Add(product);
                    cart.GetCartSum();
                }

                str = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString("cart", str);
            }
        }
    }
}