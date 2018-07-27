using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Search
{
    public static class clsSearchSQL
    {
        #region Methods
        #region CBSQL
        /// <summary>
        /// This SQL gets all InvoiceNum
        /// </summary>
        /// <returns>All data for all invoices</returns>
        public static string GetAllInvoiceNums()//To fill CBInvoice
        {
            try
            {
                string sSQL = "SELECT DISTINCT InvoiceNum FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all InvoiceDates
        /// </summary>
        /// <returns>All InvoiceDates</returns>
        public static string GetAllInvoiceDates()//To fill CBDate
        {
            try
            {
                string sSQL = "SELECT DISTINCT InvoiceDate FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all invoice totals
        /// </summary>
        /// <returns>All invoice totals</returns>
        public static string GetAllInvoiceTotals()//To fill CBTotal
        {
            try
            {
                string sSQL = "SELECT DISTINCT SUM(id.Cost) AS Total" +
                              "FROM ItemDesc id, LineItems li, Invoices i" +
                              "WHERE i.InvoiceNum = li.InvoiceNum " +
                              "AND li.ItemCode = id.ItemCode" +
                              "GROUP BY i.InvoiceNum";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets the all dates for an invoice for a given InvoiceNum
        /// </summary>
        /// <param name="sInvoiceNum">The InvoiceNum for the invoice to retrieve the date.</param>
        /// <returns>The date of the invoice.</returns>
        public static string GetInvoiceDateWithNum(string sInvoiceNum)//Fill CBDate when filtered by sInvoiceNum
        {
            try
            {
                string sSQL = "SELECT DISTINCT InvoiceDate FROM Invoices WHERE InvoiceNum = " + sInvoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all totals of invoices for a given InvoiceNum
        /// </summary>
        /// <param name="sInvoiceNum">The InvoiceNum for the invoice to retrieve the total cost.</param>
        /// <returns>The total cost of the invoice.</returns>
        public static string GetInvoiceTotalWithNum(string sInvoiceNum)//Fill CBTotal when filtered by sInvoiceNum
        {
            try
            {
                string sSQL = "SELECT DISTINCT SUM(id.Cost) AS Total" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "AND i.InvoiceNum = " + sInvoiceNum +
                                "GROUP BY i.InvoiceNum, i.InvoiceDate";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets the InvoiceNum for invoices with the given InvoiceDate
        /// </summary>
        /// <param name="sInvoiceDate">The InvoiceDate for the filtering</param>
        /// <returns>All invoiceNums with the specified date</returns>
        public static string GetInvoiceNumsWithDate(string sInvoiceDate)//Fill CBInvoice when filtered by sInvoiceDate
        {
            try
            {
                string sSQL = "SELECT DISTINCT InvoiceNum" +
                                "FROM Invoices" +
                                "WHERE InvoiceDate = #" + sInvoiceDate + "#";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets the InvoiceNum for invoices with the given InvoiceTotal
        /// </summary>
        /// <param name="sInvoiceTotal">The InvoiceTotal for filtering</param>
        /// <returns>All invoiceNums with the specified total</returns>
        public static string GetInvoiceNumsWithTotal(string sInvoiceTotal)//Fill CBInvoice when filtered by total
        {

            try
            {
                string sSQL = "SELECT DISTINCT SUM(id.Cost) AS Total" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "GROUP BY i.InvoiceNum" +
                                "HAVING SUM(id.Cost) = " + sInvoiceTotal;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets the InvoiceNum for invoices with the given InvoiceDate and InvoiceTotal
        /// </summary>
        /// <param name="sInvoiceDate">The InvoiceDate for filtering</param>
        /// <param name="sInvoiceTotal">The InvoiceTotal for filtering</param>
        /// <returns>All invoiceNums with the specified date and total</returns>
        public static string GetInvoiceNumsWithDateTotal(string sInvoiceDate, string sInvoiceTotal)//filter invoicenums by date and total
        {
            try
            {
                string sSQL = "SELECT DISTINCT i.InvoiceNum" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "AND i.InvoiceDate = #" + sInvoiceDate + "#" +
                                "GROUP BY i.InvoiceNum" +
                                "HAVING SUM(id.Cost) = " + sInvoiceTotal;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        
        /// <summary>
        /// This SQL gets the InvoiceDate for invoices with the given InvoiceTotal
        /// </summary>
        /// <param name="sInvoiceTotal">The InvoiceTotal for filtering</param>
        /// <returns>All invoiceDates with the specified total</returns>
        public static string GetInvoiceDateWithTotal(string sInvoiceTotal)//filter date by total
        {
            try
            {
                string sSQL = "SELECT DISTINCT i.InvoiceDate" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "GROUP BY i.InvoiceNum, i.InvoiceDate" +
                                "HAVING SUM(id.Cost) = " + sInvoiceTotal;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        
        public static string GetInvoiceTotalWithDate(string sInvoiceDate)//filter total by date
        {
            try
            {
                string sSQL = "SELECT DISTINCT SUM(id.Cost) AS Total" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "AND i.InvoiceDate = #" + sInvoiceDate + "#" +
                                "GROUP BY i.InvoiceNum, i.InvoiceDate";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        #endregion

        #region DGFiltersSQL
        /// <summary>
        /// This SQL gets all data for all invoices
        /// </summary>
        /// <returns>All info for all invoices</returns>
        public static string GetAllInvoices()//Fill DG with all invoices
        {
            try
            {
                string sSQL = "SELECT i.InvoiceNum, i.InvoiceDate, SUM(id.Cost) AS Total" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "GROUP BY i.InvoiceNum, i.InvoiceDate";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all data on invoices for a given InvoiceNum.
        /// </summary>
        /// <param name="sInvoiceNum">The InvoiceNum for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public static string GetAllInvoicesWithNum(string sInvoiceNum)//Fill DG when selected sInvoiceNum
        {
            try
            {
                string sSQL = "SELECT i.InvoiceNum, i.InvoiceDate, SUM(id.Cost) AS Total" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "AND i.InvoiceNum = " + sInvoiceNum +
                                "GROUP BY i.InvoiceNum, i.InvoiceDate";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all invoices with a given InvoiceDate
        /// </summary>
        /// <param name="sInvoiceDate">The InvoiceDate for the invoice to retrieve all data.</param>
        /// <returns>All invoices for the given InvoiceDate.</returns>
        public static string GetAllInvoicesWithDate(string sInvoiceDate)//Fill DG when selected sInvoiceDate
        {
            try
            {
                string sSQL = "SELECT i.InvoiceNum, i.InvoiceDate, SUM(id.Cost) AS Total" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "AND i.InvoiceDate = #" + sInvoiceDate + "#" +
                                "GROUP BY i.InvoiceNum, i.InvoiceDate";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all invoices with a given InvoiceTotal
        /// </summary>
        /// <param name="sInvoiceTotal">The InvoiceTotal for filtering</param>
        /// <returns>All invoices with the specified total cost</returns>
        public static string GetAllInvoicesWithTotal(string sInvoiceTotal)//Fill DG when selected sInvoiceTotal
        {
            try
            {
                string sSQL = "SELECT i.InvoiceNum, i.InvoiceDate, SUM(id.Cost) AS Total" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "GROUP BY i.InvoiceNum, i.InvoiceDate" +
                                "HAVING SUM(id.Cost) = " + sInvoiceTotal;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        
        /// <summary>
        /// This SQL gets all invoices with given InvoiceDate and InvoiceTotal
        /// </summary>
        /// <param name="sInvoiceDate">The InvoiceDate for filtering</param>
        /// <param name="sInvoiceTotal">The InvoiceTotal for filtering</param>
        /// <returns>All invoices with the specified date and total</returns>
        public static string GetAllInvoicesWithDateTotal(string sInvoiceDate, string sInvoiceTotal)//Fill DG when selected sInvoiceDate and sInvoiceTotal
        {

            try
            {
                string sSQL = "SELECT i.InvoiceNum, i.InvoiceDate, SUM(id.Cost) AS Total" +
                                "FROM ItemDesc id, LineItems li, Invoices i" +
                                "WHERE i.InvoiceNum = li.InvoiceNum" +
                                "AND li.ItemCode = id.ItemCode" +
                                "AND i.InvoiceDate = #" + sInvoiceDate + "#" +
                                "GROUP BY i.InvoiceNum, i.InvoiceDate" +
                                "HAVING SUM(id.Cost) = " + sInvoiceTotal;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        #endregion

        #region OtherSQL
        //None
        #endregion
        #endregion
    }
}
