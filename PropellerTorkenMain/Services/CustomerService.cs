using PropellerTorkenMain.Models.Database;
using System.Collections.Generic;
using System.Linq;

namespace PropellerTorkenMain.Services
{
    public class CustomerService
    {
        private PropellerDataContext pdc = new PropellerDataContext();

        public CustomerService()
        {
        }

        public string AddCustomer(string firstName, string lastName, string address, string city, string email, string phoneNr, int zipcode)
        {
            pdc.Customers.Add(new Customer
            {
                Firstname = firstName,
                Lastname = lastName,
                Address = address,
                City = city,
                Email = email,
                PhoneNr = phoneNr,
                Zipcode = zipcode
            });
            pdc.SaveChanges();
            return "Customer succefully added";
        }

        public string DeleteCustomer(int id)
        {
            var customerToDelete = pdc.Customers.Where(c => c.CustomerId == id).Single<Customer>();
            pdc.Customers.Remove(customerToDelete);
            pdc.SaveChanges();
            return "Customer was succesfully Deleted";
        }

        public IEnumerable<Customer> Get()
        {
            return pdc.Customers.ToList();
        }

        public IEnumerable<Customer> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return pdc.Customers.ToList();
            }
            else
            {
                return pdc.Customers.Where(p => p.Firstname.ToLower().Contains(name)).ToList();
            }
        }
    }
}