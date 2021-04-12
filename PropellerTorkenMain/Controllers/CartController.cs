using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PropellerTorkenMain.Models;
using PropellerTorkenMain.Models.Database;
using PropellerTorkenMain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropellerTorkenMain.Controllers
{
    public class CartController : Controller
    {
        private ProductService pc;

        public CartController()
        {
            pc = new ProductService();
        }

        public Cart DecrementQty(string productname)
        {
            var str = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<Cart>(str);

            if (cart.Products.Any(product => product.Name == productname))
            {
                if (cart.Products.Find(product => product.Name == productname).Qty > 0)
                {
                    cart.Products.Find(product => product.Name == productname).Qty--;
                    cart.GetCartSum();
                }
            }

            str = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", str);

            return JsonConvert.DeserializeObject<Cart>(str);
        }

        public IActionResult DecrementQtyForProduct(string productName)
        {
            var cart = DecrementQty(productName);

            return View("Index", cart);
        }

        public IActionResult DeleteProduct(string productName)
        {
            var str = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<Cart>(str);

            var itemToRemove = cart.Products.Single(p => p.Name == productName);
            cart.Products.Remove(itemToRemove);
            cart.GetCartSum();

            str = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", str);
            cart = JsonConvert.DeserializeObject<Cart>(str);

            return View("Index", cart);
        }

        public IActionResult IncrementQty(string productname)
        {
            if (HttpContext.Session.GetString("cart") == null)
            {
                return View("IndexEmpty");
            }
            var str = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<Cart>(str);
            if (cart.Products.Any(product => product.Name == productname))
            {
                cart.Products.Find(product => product.Name == productname).Qty++;
            }

            return View(cart);
        }

        public IActionResult IncrementQtyForProduct(string productName)
        {
            var cart = IncrementQty(productName);

            return View("Index", cart);
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("cart") == null)
            {
                return View("IndexEmpty");
            }
            Cart cart = GetCart();

            return View(cart);
        }

        public IActionResult Submit(Cart cart)
        {
            var cartCart = GetCart();
            cart.CartSum = cartCart.CartSum;
            cart.Products = cartCart.Products;
            OrderService orderService = new();
            CustomerService customerService = new();
            CartService cartService = new(cart);
            var orderNo = cartService.CreateOrder();
            var order = orderService.GetOrderById(orderNo).Single<Order>();
            return View("OrderComplete", order);
        }

        private Cart GetCart()
        {
            var str = HttpContext.Session.GetString("cart");
            var cart = JsonConvert.DeserializeObject<Cart>(str);
            return cart;
        }

        //public Cart IncrementQty(string productname)
        //{
        //    var str = HttpContext.Session.GetString("cart");
        //    var cart = JsonConvert.DeserializeObject<Cart>(str);

        //    if (cart.products.Any(product => product.Name == productname))
        //    {
        //        cart.products.Find(product => product.Name == productname).Qty++;
        //        cart.GetCartSum();
        //    }

        //    str = JsonConvert.SerializeObject(cart);
        //    HttpContext.Session.SetString("cart", str);

        //    return JsonConvert.DeserializeObject<Cart>(str);
        //}
    }
}