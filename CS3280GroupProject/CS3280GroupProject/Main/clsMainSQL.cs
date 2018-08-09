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
        public static void addInvoice(string sDate)
        {
            try
            {
                clsDataAccess ds = new clsDataAccess();
                string sSQL = "INSERT INTO Invoices (InvoiceDate) VALUES ('" + sDate + "');";
                ds.ExecuteNonQuery(sSQL);
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
        public static void deleteInvoice(int iInvoiceNum)
        {
            try
            {
                clsDataAccess ds = new clsDataAccess();
                string sSQL1 = "DELETE FROM LineItems WHERE InvoiceNum = " + iInvoiceNum;
                ds.ExecuteNonQuery(sSQL1);
                string sSQL = "DELETE FROM Invoices WHERE InvoiceNum = " + iInvoiceNum;
                ds.ExecuteNonQuery(sSQL);

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
        public static int getNewInvoiceNumber()
        {
            try
            {
                clsDataAccess ds = new clsDataAccess();
                int id;
                string sSQL = "SELECT Max(InvoiceNum) AS InvoiceNumber FROM Invoices; ";
                id = Int32.Parse(ds.ExecuteScalarSQL(sSQL));

                return id;
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
        public static void addInvoiceLineItem(int iInvoiceNumber, int iLineItemNumber, string ItemCode)
        {
            try
            {
                clsDataAccess ds = new clsDataAccess();
                string sSQL = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) " +
                              "VALUES (" + iInvoiceNumber + "," + iLineItemNumber + ",'" + ItemCode + "');";
                ds.ExecuteNonQuery(sSQL);
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
        public static void removeInvoiceLineItem(int iInvoiceNumber, int iLineItemNum )
        {
            try
            {
                clsDataAccess ds = new clsDataAccess();
                
                string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = " + iInvoiceNumber + " AND LineItemNum = " + iLineItemNum + "; ";
                ds.ExecuteNonQuery(sSQL);

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
        public static void updateInvoice(int iInvoiceNum, string sDate)
        {
            try
            {
                clsDataAccess ds = new clsDataAccess();
                string sSQL = "UPDATE Invoices SET InvoiceDate = '" + sDate + "' WHERE InvoiceNum = " + iInvoiceNum + "; ";
                ds.ExecuteNonQuery(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        /// <summary>
        /// This SQL statement updates the invoice line item
        /// </summary>
        /// <param name="iInvoiceNumber"></param>
        /// <param name="iLineItemNum"></param>
        /// <returns>SQL statement</returns>
        public static void updateLineItem(int iInvoiceNumber, int iLineItemNumber, string sItemCode)
        {
            try
            {
                clsDataAccess ds = new clsDataAccess();
                string sSQL = "UPDATE LineItems SET ItemCode = '" + sItemCode + "'" +
                              "WHERE InvoiceNum = " + iInvoiceNumber + " AND LineItemNum = " + iLineItemNumber +";";
                ds.ExecuteNonQuery(sSQL);

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
