using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace propeller_torken.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Adminpage()
        {
            return View();
        }

        public IActionResult AdminOrders()
        {
            return View();
        }

        public IActionResult AdminSent()
        {
            return View();
        }


        public IActionResult AdminContact()
        {
            return View();
        }
    }


}
