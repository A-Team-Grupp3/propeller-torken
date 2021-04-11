using PropellerTorkenMain.Models;
using PropellerTorkenMain.Models.Database;
using System.Collections.Generic;

namespace PropellerTorkenMain.Services
{
    public class CartService
    {
        private CustomerService customerService = new CustomerService();

        public CartService(Cart cart)
        {
            CartSum = cart.CartSum;
            Cart = cart;
        }

        public Cart Cart { get; set; }
        public int CartSum { get; set; }

        public int CreateOrder()
        {
            if (Cart.CustomerId != 0)
            {
                return CreateOrder(Cart.Products, Cart.CustomerId);
            }
            else
            {
                return CreateOrder(Cart.Products, Cart.Customer);
            }
        }

        public int CreateOrder(List<Product> products, int CustomerId)
        {
            PropellerDataContext ctx = new();
            OrderService os = new();
            int orderNumber = os.AddOrder(CustomerId, CartSum);
            if (orderNumber != 0)
            {
                foreach (var prod in products)
                {
                    var newRel = new ProductsInOrder
                    {
                        ProductId = prod.Id,
                        OrderId = orderNumber
                    };
                    ctx.ProductsInOrders.Add(newRel);
                    ctx.SaveChanges();
                }
                return orderNumber;
            }
            else
            {
                return 0;
            }
        }

        public int CreateOrder(List<Product> products, DummyCustomer dummy)
        {
            PropellerDataContext ctx = new();
            Order order = new();
            Customer customer;
            int CustomerId = customerService.AddCustomer(dummy);
            customer = customerService.GetByInt(CustomerId);
            order.OurCustomer = customer.CustomerId;
            order.OrderSum = CartSum;
            foreach (var prod in products)
            {
                var newRel = new ProductsInOrder
                {
                    ProductId = prod.Id,
                    OrderId = order.OurCustomer
                };
                ctx.ProductsInOrders.Add(newRel);
                ctx.SaveChanges();
            }
            var returned = ctx.Orders.Add(order);
            int orderNumber = returned.Entity.Id;

            return orderNumber;
        }
    }
}