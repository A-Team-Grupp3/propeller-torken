using Microsoft.AspNetCore.Mvc;
using PropellerTorkenMain.Models.Database;
using PropellerTorkenMain.Services;
using System.Collections.Generic;

namespace PropellerTorkenMain.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderService os = new OrderService();

        public OrderController()
        {
        }

        [HttpPost]
        public string CreateOrder(int customerId, int orderSum)
        {
            return os.AddOrder(customerId, orderSum);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return os.DeleteOrder(id);
        }

        [HttpGet]
        public IEnumerable<Order> Get(int id)
        {
            if (int.Equals(id, 0))
            {
                return os.Get();
            }
            else
            {
                return os.GetOrderById(id);
            }
        }
    }
}