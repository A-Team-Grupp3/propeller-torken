using PropellerTorkenMain.Models.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PropellerTorkenMain.Services
{
    public class OrderService
    {
        public PropellerDataContext ctx = new PropellerDataContext();

        public OrderService()
        {
            //CurrentOrderList = ctx.Orders.ToList();
        }

        public List<Order> CurrentOrderList { get; set; }
        public Order Order { get; set; }
        public List<Order> SentOrderList { get; set; }

        public int AddOrder(int customerId, int orderSum)
        {
            var returnValue = ctx.Orders.Add(new Order
            {
                Date = DateTime.Now,
                OurCustomer = customerId,
                OrderSum = orderSum
            });

            ctx.SaveChanges();
            return returnValue.Entity.Id;
        }

        public string DeleteOrder(int id)
        {
            var orderToRemove = ctx.Orders.Where(o => o.Id == id).Single<Order>();
            ctx.Orders.Remove(orderToRemove);
            ctx.SaveChanges();
            return "Order successfully removed";
        }

        public IEnumerable<Order> Get()
        {
            return ctx.Orders.ToList();
        }

        public IEnumerable<Order> GetOrderById(int id)
        {
            if (int.Equals(id, 0))
            {
                return ctx.Orders.ToList();
            }
            else
            {
                return ctx.Orders.Where(o => o.Id == id).ToList();
            }
        }

        public List<Order> GetOrders(string orderStatus = null)
        {
            var orders = ctx.Orders.Include(o => o.OurCustomerNavigation).Where(o => o.OrderStatus == orderStatus);

            return orders.ToList();
            //return null;
        }

        public void RemoveItemFromList(int id)
        {
            var listItemToRemove = ctx.Orders.FirstOrDefault(p => p.Id == id);
            ctx.Orders.Remove(listItemToRemove);
            ctx.SaveChanges();

            //Products myProducts = new Products() { ID = 1, Name = "PropellerKeps1", Price = 150 };
            //Customer myCustomer = new Customer() { FirstName = "Carl", LastName = "Bajs", Address = "Bajsgatan 1", City = "Malmö", ZipCode = 12345, Email = "InteBajs@gmail.com", PhoneNr = "070812345678" };
            //Products myProducts2 = new Products() { ID = 2, Name = "Torktumlare", Price = 1500 };
            //Customer myCustomer2 = new Customer() { FirstName = "Anton", LastName = "Fitness", Address = "LundVägen 37", City = "Lund", ZipCode = 11223, Email = "AntonFitness@gmail.com", PhoneNr = "07089996633" };

            //CurrentOrderList = new List<Orders>()
            //{
            //    new Orders{Id = 1, OurCustomer = myCustomer, Date = DateTime.Now, OurProduct = new List<Products>{myProducts } },
            //    new Orders{Id = 2, OurCustomer = myCustomer2, Date = DateTime.Now, OurProduct = new List<Products>{myProducts2}}
            //};

            //SentOrderList = new List<Orders>();
        }

        public void SetStatusToSent(int id)
        {
            var sentItem = ctx.Orders.FirstOrDefault(x => x.Id == id);
            sentItem.OrderStatus = "SENT";
            ctx.SaveChanges();
        }

        //public void List<SentOrder> GetAllSentOrders()
        //{
        //    return ctx.SentOrders.ToList();

        //}
    }
}