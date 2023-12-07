using BusinessObject.DAO;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public class RentingTransactionRepository : IRentingTransactionRepository
    {
        public List<RentingTransaction> GetListRentingTransaction() => RentingTransactionDAO.Instance.GetListRentingTransaction();
    }
}
