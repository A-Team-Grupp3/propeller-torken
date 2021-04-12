using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropellerTorkenMain.Models.Database;
using PropellerTorkenMain.Services;
using System.Collections.Generic;

namespace PropellerTorkenMain.Controllers
{
    public class AdminController : Controller
    {
        private PropellerDataContext _ctx = new PropellerDataContext();

        public AdminController(OrderService orderService)
        {
            OrderService = orderService;
        }

        public List<Order> orderList { get; set; }

        private OrderService OrderService { get; set; }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminContact()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOrders()
        {
            var orders = OrderService.GetOrders();
            return View(orders);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Adminpage()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminSent()
        {
            var orders = OrderService.GetOrders("SENT");
            return View(orders);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            OrderService.RemoveItemFromList(id);

            return RedirectToAction("AdminOrders");
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Send(int id)
        {
            OrderService.SetStatusToSent(id);

            return View("AdminOrders");
        }
    }
}