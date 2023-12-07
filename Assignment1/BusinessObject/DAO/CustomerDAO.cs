using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        private static readonly object instancelock = new object();
        private CustomerDAO() { }
        public static CustomerDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new CustomerDAO();
                    }
                    return instance;
                }
            }
        }

        FUCarRentingManagementContext db = new FUCarRentingManagementContext();
        public void CreateCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public Customer GetCustomerById(int id)
        {
            return db.Customers.FirstOrDefault(x => x.CustomerId == id);
        }

        public List<Customer> GetListCustomer()
        {
            return db.Customers.ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer _customer = GetCustomerById(customer.CustomerId);
            if (_customer != null)
            {
                db.Entry(_customer).CurrentValues.SetValues(customer);
                db.SaveChanges();
            }
        }

        public void DeleteCustomer(int id)
        {
            var customer = GetCustomerById(id);
            db.Remove(customer);
            db.SaveChanges();
        }
    }
}
