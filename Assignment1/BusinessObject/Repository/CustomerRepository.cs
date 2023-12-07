using BusinessObject.DAO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        public void CreateCustomer(Customer customer) => CustomerDAO.Instance.CreateCustomer(customer);

        public void DeleteCustomer(int id) => CustomerDAO.Instance.DeleteCustomer(id);

        public Customer GetCustomerById(int id) => CustomerDAO.Instance.GetCustomerById(id);

        public List<Customer> GetListCustomer() => CustomerDAO.Instance.GetListCustomer();

        public void UpdateCustomer(Customer customer) => CustomerDAO.Instance.UpdateCustomer(customer);
    }
}
