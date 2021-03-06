﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IStockService
    {
        IEnumerable<Stock> GetStocks(string companyName);

        IEnumerable<Stock> GetStocks(string companyName, string fromDate, string toDate);

    }
}
