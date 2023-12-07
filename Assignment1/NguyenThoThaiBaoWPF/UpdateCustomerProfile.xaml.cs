using BusinessObject.Models;
using BusinessObject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NguyenThoThaiBaoWPF
{
    /// <summary>
    /// Interaction logic for UpdateCustomerProfile.xaml
    /// </summary>
    public partial class UpdateCustomerProfile : Window
    {
        ICustomerRepository customerdb = new CustomerRepository();
        static Customer _customer;
        int _user;
        public UpdateCustomerProfile(Customer customer, int user)
        {
            _customer = customer;
            InitializeComponent();
            LoadCustomerValue();
            _user = user;
        }
        private void LoadCustomerValue()
        {
            txtName.Text = _customer.CustomerName;
            txtTelephone.Text = _customer.Telephone;
            txtPassword.Password = _customer.Password;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Customer updateCustomer = new Customer()
            {
                CustomerId = _customer.CustomerId,
                CustomerName = txtName.Text,
                Email = _customer.Email,
                Telephone = txtTelephone.Text,
                CustomerBirthday = _customer.CustomerBirthday,
                CustomerStatus = _customer.CustomerStatus,
                Password = txtPassword.Password,
                RentingTransactions = _customer.RentingTransactions
            };

            customerdb.UpdateCustomer(updateCustomer);

            if (_user == 1)
            {
                CustomerWindow customerWindow = new CustomerWindow(_customer.CustomerId);
                customerWindow.Show();
            }
            else if (_user == 0)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
            }

            this.Close();
        }
    }
}
