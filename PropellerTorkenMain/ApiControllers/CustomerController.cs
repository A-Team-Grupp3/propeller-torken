using Microsoft.AspNetCore.Mvc;
using PropellerTorkenMain.Models.Database;
using PropellerTorkenMain.Services;
using System.Collections.Generic;

namespace PropellerTorkenMain.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerService cService = new CustomerService();

        public CustomerController()
        {
        }

        [HttpPost]
        public string AddCustomer(string firstName, string lastName, string address, string city, string email, string phoneNr, int zipcode)
        {
            return cService.AddCustomer(firstName, lastName, address, city, email, phoneNr, zipcode);
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return cService.DeleteCustomer(id);
        }

        [HttpGet]
        public IEnumerable<Customer> Get(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return cService.Get();
            }
            else
            {
                return cService.GetByName(name);
            }
        }
    }
}