using BusinessObject.Models;
using BusinessObject.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        IRentingTransactionRepository rentingdb = new RentingTransactionRepository();
        ICustomerRepository customerdb = new CustomerRepository();
        static int _customerId;
        public CustomerWindow(int customerId)
        {
            _customerId = customerId;
            InitializeComponent();
            loadWindow();
        }

        private void loadWindow()
        {
            loadGrid();
            loadCustomerName();
        }
        private void loadGrid()
        {
            List<RentingTransaction> listData = rentingdb.GetListRentingTransaction();
            List<RentingTransaction> data = new List<RentingTransaction>();
            foreach (var item in listData.Where(x => x.CustomerId == _customerId))
            {
                data.Add(item);
            }
            dgvRentingTransaction.ItemsSource = data;
            
        }

        private void loadCustomerName()
        {
            Customer customer = customerdb.GetCustomerById(_customerId);
            lblCustomerName.Content = $"Hello {customer.CustomerName}";
        }
        private void btnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = customerdb.GetCustomerById(_customerId);
            UpdateCustomerProfile update = new UpdateCustomerProfile(customer, 1);
            this.Close();
            update.Show();
        }
    }
}
