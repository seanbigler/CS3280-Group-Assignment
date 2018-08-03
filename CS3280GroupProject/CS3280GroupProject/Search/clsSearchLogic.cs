using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Search
{
    /// <summary>
    /// Class that contains the logic for the search window
    /// </summary>
    class clsSearchLogic
    {
        #region Attributes
        /// <summary>
        /// Executes SQL strings that are passed into its methods
        /// </summary>
        clsDataAccess dataAccess;
        #endregion

        #region Methods
        /// <summary>
        /// Initializes search largic class
        /// </summary>
        public clsSearchLogic()
        {
            try
            {
                dataAccess = new clsDataAccess();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        #region CB
        /// <summary>
        /// Retrieves a list of invoice nums as strings from the database
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllInvoiceNums()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of invoice dates as strings from the database
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllInvoiceDates()
        {
            try
            {
                string sSQL = clsSearchSQL.GetAllInvoiceDates();
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                List<string> tempDates = new List<string>();
                for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempDates.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
                }
                return tempDates;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of invoice totals as strings from the database
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllInvoiceTotals()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of InvoiceDates filtered by InvoiceNum as strings in a list
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        public List<string> GetInvoiceDateWithNum(string invoiceNum)
        {
            try
            {
                string sSQL = clsSearchSQL.GetInvoiceDateWithNum(invoiceNum);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                List<string> tempTotals = new List<string>();
                for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempTotals.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
                }
                return tempTotals;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of InvoiceTotals filtered by InvoiceNum as strings in a list
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <returns></returns>
        public List<string> GetInvoiceTotalWithNum(string invoiceNum)
        {
            try
            {
                string sSQL = clsSearchSQL.GetInvoiceTotalWithNum(invoiceNum);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                List<string> tempTotals = new List<string>();
                for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempTotals.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
                }
                return tempTotals;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of InvoiceNums filtered by InvoiceDate as strings in a list
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <returns></returns>
        public List<string> GetInvoiceNumsWithDate(string invoiceDate)
        {
            try
            {
                string sSQL = clsSearchSQL.GetInvoiceNumsWithDate(invoiceDate);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                List<string> tempTotals = new List<string>();
                for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempTotals.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
                }
                return tempTotals;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of InvoiceNums filtered by InvoiceTotal as strings in a list
        /// </summary>
        /// <param name="invoiceTotal"></param>
        /// <returns></returns>
        public List<string> GetInvoiceNumsWithTotal(string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.GetInvoiceNumsWithTotal(invoiceTotal);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                List<string> tempTotals = new List<string>();
                for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempTotals.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
                }
                return tempTotals;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of InvoiceNums filtered by InvoiceDate and InvoiceTotal as strings in a list
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <param name="invoiceTotal"></param>
        /// <returns></returns>
        public List<string> GetInvoiceNumsWithDateTotal(string invoiceDate, string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.GetInvoiceNumsWithDateTotal(invoiceDate, invoiceTotal);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                List<string> tempTotals = new List<string>();
                for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempTotals.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
                }
                return tempTotals;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of InvoiceDates filtered by InvoiceTotal as strings in a list
        /// </summary>
        /// <param name="invoiceTotal"></param>
        /// <returns></returns>
        public List<string> GetInvoiceDateWithTotal(string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.GetInvoiceDateWithTotal(invoiceTotal);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                List<string> tempTotals = new List<string>();
                for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempTotals.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
                }
                return tempTotals;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a list of InvoiceTotal filtered by InvoiceDate as strings in a list
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <returns></returns>
        public List<string> GetInvoiceTotalWithDate(string invoiceDate)
        {
            try
            {
                string sSQL = clsSearchSQL.GetInvoiceTotalWithDate(invoiceDate);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                List<string> tempTotals = new List<string>();
                for (int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempTotals.Add(tempDataSet.Tables[0].Rows[i][0].ToString());
                }
                return tempTotals;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        #endregion

        #region DG
        /// <summary>
        /// Retrieves a dataset of invoices from the database
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllInvoices()
        {
            try
            {
                string sSQL = clsSearchSQL.GetAllInvoices();
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                tempDataSet.Tables[0].Columns[2].ColumnName = "Total";
                /*for(int i = 0; i < tempDataSet.Tables[0].Rows.Count; i++)
                {
                    tempDataSet.Tables[0].Rows[i][2] = "$" + tempDataSet.Tables[0].Rows[i][2];
                }*/
                return tempDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a dataset of invoices filtered by invoiceNum from the database
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        public DataSet GetAllInvoicesWithNum(string invoiceNum)
        {
            try
            {
                string sSQL = clsSearchSQL.GetAllInvoicesWithNum(invoiceNum);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                tempDataSet.Tables[0].Columns[2].ColumnName = "Total";
                return tempDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a dataset of invoices filtered by invoiceDate from the database
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <returns></returns>
        public DataSet GetAllInvoicesWithDate(string invoiceDate)
        {
            try
            {
                string sSQL = clsSearchSQL.GetAllInvoicesWithDate(invoiceDate);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                tempDataSet.Tables[0].Columns[2].ColumnName = "Total";
                return tempDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a dataset of invoices filtered by invoiceTotal from the database
        /// </summary>
        /// <param name="invoiceTotal"></param>
        /// <returns></returns>
        public DataSet GetAllInvoicesWithTotal(string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.GetAllInvoicesWithTotal(invoiceTotal);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                tempDataSet.Tables[0].Columns[2].ColumnName = "Total";
                return tempDataSet;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Retrieves a dataset of invoices filtered by invoiceDate and invoiceTotal from the database
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <param name="invoiceTotal"></param>
        /// <returns></returns>
        public DataSet GetAllInvoicesWithDateTotal(string invoiceDate, string invoiceTotal)
        {
            try
            {
                string sSQL = clsSearchSQL.GetAllInvoicesWithDateTotal(invoiceDate, invoiceTotal);
                int tempRows = 0;
                DataSet tempDataSet = dataAccess.ExecuteSQLStatement(sSQL, ref tempRows);
                tempDataSet.Tables[0].Columns[2].ColumnName = "Total";
                return tempDataSet;
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
