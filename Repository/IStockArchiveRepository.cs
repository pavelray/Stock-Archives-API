using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IStockArchiveRepository
    {
        /// <summary>
        /// Get Stock Archives Dump Data
        /// </summary>
        void GetStockArchivesData();

        /// <summary>
        /// Insert Stock Archives data into database
        /// </summary>
        /// <returns></returns>
        bool InsertSockArchivesBulkDate(string filepath);

        /// <summary>
        /// Delete the 1st column data from database
        /// </summary>
        /// <returns></returns>
        bool DeleteTopHeaderRow();


    }
}
