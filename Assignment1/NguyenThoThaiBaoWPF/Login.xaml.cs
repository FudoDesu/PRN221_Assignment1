using BusinessObject.Repository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ICustomerRepository _context = new CustomerRepository();
        public Login()
        {
            InitializeComponent();
            SetLblWarningToNull();
        }
        public void SetLblWarningToNull()
        {
            lblWarning.Content = "";
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var customer = _context.GetListCustomer().FirstOrDefault(x => x.Email.Equals(txtEmail.Text)
                                                                && x.Password.Equals(txtPassword.Password));
            if (customer != null)
            {
                CustomerWindow customerwindow = new CustomerWindow(customer.CustomerId);
                this.Close();
                customerwindow.Show();
            }
            else
            {
                string filename = "appsettings.json";
                StreamReader reader = new StreamReader(filename);
                var json = reader.ReadToEnd();
                var jtoken = JObject.Parse(json)["Admin"];
                string email = JObject.Parse(jtoken.ToString())["Email"].ToString();
                string password = JObject.Parse(jtoken.ToString())["Password"].ToString();
                if (txtEmail.Text.Equals(email)
                    && txtPassword.Password.Equals(password))
                {
                    AdminWindow adminwindow = new AdminWindow();
                    this.Close();
                    adminwindow.Show();
                }
                else
                {
                    lblWarning.Content = "Wrong Email or Password";
                }
            }
        }
    }
}
