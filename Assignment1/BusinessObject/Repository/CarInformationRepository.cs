using BusinessObject.DAO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class CarInformationRepository : ICarInformationRepository
    {
        public List<CarInformation> GetListCarInformation() => CarInformationDAO.Instance.GetListCarInformation();
        public CarInformation GetCarInformation(int id) => CarInformationDAO.Instance.GetCarInformation(id);
        public void UpdateCarInformation(CarInformation carInformation) => CarInformationDAO.Instance.UpdateCarInformation(carInformation);
    }
}
