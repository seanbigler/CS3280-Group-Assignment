using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject
{
    class clsMainSQL
    {
        #region Class Methods
        /// <summary>
        /// This SQL inserts a new invoice into the invoices table in Invoice.mdb
        /// </summary>
        /// <returns>Insert SQL</returns>
        public static string addInvoice(string sDate)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices (InvoiceDate) VALUES ('" + sDate + "');";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement deletes a new invoice from the invoices table in Invoice.mdb
        /// </summary>
        /// <returns>Insert SQL</returns>
        public static string deleteInvoice(int iInvoiceNum)
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices i INNER JOIN LineItems li" + 
                              "ON i.InvoiceNum = li.InvoiceNum WHERE i.InvoiceNum = " + iInvoiceNum + ";";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement gets the cost of a perticular item by it's ItemCode
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns>Item Cost</returns>
        public static string getItemCost(string sItemCode)
        {
            try
            {
                string sSQL = "SELECT Cost FROM ItemDesc WHERE ItemCode = '" + sItemCode + "'";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement gets item names of all available items
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns>Item names</returns>
        public static string getItemNames()
        {
            try
            {
                string sSQL = "SELECT ItemDesc FROM ItemDesc";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement gets item names of all available items
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns>Item names</returns>
        public static string getNewInvoiceNumber()
        {
            try
            {
                string sSQL = "SELECT Max(InvoiceNum) AS InvoiceNumber FROM Invoices; ";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement inserts a line item into the LineItem table in Invoice.mdb
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns>Insert Line item</returns>
        public static string addInvoiceLineItem(int iInvoiceNumber, int iLineItemNumber, string ItemCode)
        {
            try
            {
                string sSQL = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) " +
                              "VALUES (" + iInvoiceNumber + "," + iLineItemNumber + ",'" + ItemCode + "');";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// This SQL statement deletes a line item from the LineItem table in Invoice.mdb
        /// </summary>
        /// <param name="sItemCode"></param>
        /// <returns>Line Item deletion</returns>
        public static string removeInvoiceLineItem(int iInvoiceNumber, int iLineItemNum )
        {
            try
            {
                string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = " + iInvoiceNumber + " AND LineItemNum = " + iLineItemNum + "; ";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

       /// <summary>
       /// This SQL statement updates date on Invoices. 
       /// </summary>
       /// <param name="iInvoiceNum"></param>
       /// <param name="sDate"></param>
       /// <returns>Update SQL statement</returns>
        public static string updateInvoice(int iInvoiceNum, string sDate)
        {
            try
            {
                string sSQL = "UPDATE Invoices SET InvoiceDate = '" + sDate + "' WHERE InvoiceNum = " + iInvoiceNum + "; ";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }


        #endregion
    }
}
