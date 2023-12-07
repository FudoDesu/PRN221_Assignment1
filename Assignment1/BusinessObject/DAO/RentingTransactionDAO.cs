using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DAO
{
    public class RentingTransactionDAO
    {
        private static RentingTransactionDAO instance;
        private static readonly object instancelock = new object();
        private RentingTransactionDAO() { }
        public static RentingTransactionDAO Instance
        {
            get
            {
                lock (instancelock)
                {
                    if (instance == null)
                    {
                        instance = new RentingTransactionDAO();
                    }
                    return instance;
                }
            }
        }

        FUCarRentingManagementContext db = new FUCarRentingManagementContext();

        public List<RentingTransaction> GetListRentingTransaction()
        {
            return db.RentingTransactions.ToList();
        }

    }
}
