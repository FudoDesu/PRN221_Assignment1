using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface ICarInformationRepository
    {
        public List<CarInformation> GetListCarInformation();
        public CarInformation GetCarInformation(int id);
        public void UpdateCarInformation(CarInformation carInformation);
    }
}
