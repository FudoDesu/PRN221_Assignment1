﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Repository
{
    public interface IRentingTransactionRepository
    {
        public List<RentingTransaction> GetListRentingTransaction();
    }
}
