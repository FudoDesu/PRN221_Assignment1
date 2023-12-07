using BusinessObject.Models;
using BusinessObject.Repository;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        ICustomerRepository customerdb = new CustomerRepository();
        ICarInformationRepository carInformationdb = new CarInformationRepository();
        IRentingTransactionRepository rentingTransactiondb = new RentingTransactionRepository();
        public AdminWindow()
        {
            InitializeComponent();
            loadWindow();
        }

        private void loadWindow()
        {
            loadGrid();
        }

        private void loadGrid()
        {
            List<Customer> listCustomer = customerdb.GetListCustomer();
            List<CarInformation> listCarInfo = carInformationdb.GetListCarInformation();
            List<RentingTransaction> listTransaction = rentingTransactiondb.GetListRentingTransaction();

            dgvCustomerInfo.ItemsSource = listCustomer;
            dgvCarInfo.ItemsSource = listCarInfo;
            dgvRentingTransaction.ItemsSource = listTransaction;
        }

        private void dgvCustomerInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Customer customer = (Customer)dgvCustomerInfo.SelectedItem;
                UpdateCustomerProfile update = new UpdateCustomerProfile(customer, 0);
                this.Close();
                update.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvCarInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                CarInformation carInformation = (CarInformation)dgvCarInfo.SelectedItem;
                UpdateCarInformation update = new UpdateCarInformation(carInformation);
                this.Close();
                update.Show();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
