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
    /// Interaction logic for UpdateCarInformation.xaml
    /// </summary>
    public partial class UpdateCarInformation : Window
    {
        ICarInformationRepository carInfodb = new CarInformationRepository();
        static CarInformation _carInformation;
        public UpdateCarInformation(CarInformation carInformation)
        {
            _carInformation = carInformation;
            InitializeComponent();
            loadCarInfomationValue();
        }
        private void loadCarInfomationValue()
        {
            txtCarName.Text = _carInformation.CarName;
            txtCarDescription.Text = _carInformation.CarDescription;
            txtNumOfDoor.Text = _carInformation.NumberOfDoors.ToString();
            txtSeatingCapacity.Text = _carInformation.SeatingCapacity.ToString();
            txtFuelType.Text = _carInformation.FuelType;
            txtYear.Text = _carInformation.Year.ToString();
            txtCarRentingPricePerDay.Text = _carInformation.CarRentingPricePerDay.ToString();
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            CarInformation carInfo = new CarInformation()
            {
                CarId = _carInformation.CarId,
                CarName = txtCarName.Text,
                CarDescription = txtCarDescription.Text,
                NumberOfDoors = Int32.Parse(txtNumOfDoor.Text),
                SeatingCapacity = Int32.Parse(txtSeatingCapacity.Text),
                FuelType = txtFuelType.Text,
                Year = Int32.Parse(txtYear.Text),
                CarRentingPricePerDay = decimal.Parse(txtCarRentingPricePerDay.Text),
                CarStatus = _carInformation.CarStatus,
                Manufacturer = _carInformation.Manufacturer,
                ManufacturerId = _carInformation.ManufacturerId,
                RentingDetails = _carInformation.RentingDetails,
                SupplierId = _carInformation.SupplierId,
                Supplier = _carInformation.Supplier
            };

            carInfodb.UpdateCarInformation(carInfo);

            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
            this.Close();
        }
    }
}
