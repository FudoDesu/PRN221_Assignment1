using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DAO
{
    public class CarInformationDAO
    {
        private static CarInformationDAO instance;
        private static readonly object instancelock = new object();
        private CarInformationDAO() { }
        public static CarInformationDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new CarInformationDAO();
                    }
                    return instance;
                }
            }
        }
        
        FUCarRentingManagementContext db = new FUCarRentingManagementContext();

        public List<CarInformation> GetListCarInformation()
        {
            return db.CarInformations.ToList();
        }

        public CarInformation GetCarInformation(int id)
        {
            return db.CarInformations.SingleOrDefault(x => x.CarId == id);
        }
        public void UpdateCarInformation(CarInformation carInformation)
        {
            CarInformation _carInformation = GetCarInformation(carInformation.CarId);
            if (_carInformation != null)
            {
                db.Entry(_carInformation).CurrentValues.SetValues(carInformation);
                db.SaveChanges();
            }
        }
    }
}
