using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Search
{
    class clsSearchLogic
    {
        /// <summary>
        /// Executes SQL strings that are passed into its methods
        /// </summary>
        clsDataAccess dataAccess;

        public clsSearchLogic()
        {
            dataAccess = new clsDataAccess();
        }

        /// <summary>
        /// Retrieves a list of invoice nums as strings from the database
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllInvoiceNums()
        {
            string sSQL = clsSearchSQL.GetAllInvoiceNums();
            int tempRows = 0;
            DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
            List<string> tempNums = new List<string>();
            for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
            {
                tempNums.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
            }
            return tempNums;
        }

        /// <summary>
        /// Retrieves a list of invoice dates as strings from the database
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllInvoiceDates()
        {
            string sSQL = clsSearchSQL.GetAllInvoiceDates();
            int tempRows = 0;
            DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
            List<string> tempDates = new List<string>();
            for(int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
            {
                tempDates.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
            }
            return tempDates;
        }

        public List<string> GetAllInvoiceTotals()
        {
            string sSQL = clsSearchSQL.GetAllInvoiceTotals();
            int tempRows = 0;
            DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
            List<string> tempTotals = new List<string>();
            for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
            {
                tempTotals.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
            }
            return tempTotals;
        }
    }
}
