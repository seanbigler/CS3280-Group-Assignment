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
        /// This SQL gets all invoices
        /// </summary>
        /// <returns>All data for all invoices</returns>
        public static string GetAllInvoices()//Not tested
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices";
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
        public static string GetAllInvoiceDates()//Not tested
        {
            try
            {
                string sSQL = "SELECT InvoiceDate FROM Invoices";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets all invoice total costs
        /// </summary>
        /// <returns>All invoice totals</returns>
        public static string GetAllInvoiceTotals()//Not tested
        {
            try
            {
                string sSQL = "SELECT SUM(id.Cost) " +
                              "FROM id ItemDesc, li LineItems, i Invoices" +
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
        #endregion

        #region DGFiltersSQL
        /// <summary>
        /// This SQL gets all data on an invoice for a given InvoiceNum.
        /// </summary>
        /// <param name="sInvoiceNum">The InvoiceNum for the invoice to retrieve all data.</param>
        /// <returns>All data for the given invoice.</returns>
        public static string GetInvoice(string sInvoiceNum)//Not tested
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + sInvoiceNum;
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
        public static string GetAllInvoicesWithDate(string sInvoiceDate)//Not tested
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices WHERE InvoiceDate = " + sInvoiceDate;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets the total cost of an invoice for a given InvoiceNum
        /// </summary>
        /// <param name="sInvoiceNum">The InvoiceNum for the invoice to retrieve the total cost.</param>
        /// <returns>The total cost of the invoice.</returns>
        public static string GetAllInvoicesWithTotal(string sInvoiceNum)//Not complete Not tested
        {
            try
            {
                string sSQL = "SELECT InvoiceNum " +
                              "FROM " +
                                  "(SELECT i.InvoiceNum, SUM(id.Cost) " +
                                  "FROM id ItemDesc, li LineItems, i Invoices" +
                                  "WHERE i.InvoiceNum = li.InvoiceNum " +
                                  "AND li.ItemCode = id.ItemCode" +
                                  "GROUP BY i.InvoiceNum)";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        #endregion

        #region OtherSQL - Possibly Not Needed
        /// <summary>
        /// This SQL gets the date for an invoice for a given InvoiceNum
        /// </summary>
        /// <param name="sInvoiceNum">The InvoiceNum for the invoice to retrieve the date.</param>
        /// <returns>The date of the invoice.</returns>
        public static string GetInvoiceDate(string sInvoiceNum)//Not tested
        {
            try
            {
                string sSQL = "SELECT InvoiceDate FROM Invoices WHERE InvoiceNum = " + sInvoiceNum;
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL gets the total cost of an invoice for a given InvoiceNum
        /// </summary>
        /// <param name="sInvoiceNum">The InvoiceNum for the invoice to retrieve the total cost.</param>
        /// <returns>The total cost of the invoice.</returns>
        public static string GetInvoiceTotal(string sInvoiceNum)//Not tested
        {
            try
            {
                string sSQL = "SELECT SUM(id.Cost) " +
                              "FROM id ItemDesc, li LineItems, i Invoices" +
                              "WHERE i.InvoiceNum = li.InvoiceNum " +
                              "AND li.ItemCode = id.ItemCode" +
                              "AND i.Invoice Num = " + sInvoiceNum +
                              "GROUP BY i.InvoiceNum";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        #endregion
        #endregion
    }
}
