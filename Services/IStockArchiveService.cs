using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    interface IStockArchiveService
    {
        /// <summary>
        /// Insert Stock Archives data into database
        /// </summary>
        /// <returns></returns>
        bool InsertSockArchivesBulkDate(string filepath);
    }
}
