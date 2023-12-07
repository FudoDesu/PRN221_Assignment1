using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface ICustomerRepository
    {
        public void CreateCustomer(Customer customer);
        public Customer GetCustomerById(int id);
        public List<Customer> GetListCustomer();
        public void UpdateCustomer(Customer customer);
        public void DeleteCustomer(int id);
    }
}
