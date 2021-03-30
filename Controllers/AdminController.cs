﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using propeller_torken.Models;
using propeller_torken.Services;

namespace propeller_torken.Controllers
{
    public class AdminController : Controller
    {
        public OrderService ourOrderService = new OrderService();
        public CombinedViewModelsService myCVMS = new CombinedViewModelsService();


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
            

            return View(ourOrderService.CurrentOrderList);
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
