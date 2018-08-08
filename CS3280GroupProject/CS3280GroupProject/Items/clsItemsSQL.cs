using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Items
{
    class clsItemsSQL
    {
        /// <summary>
        /// Retrieves the entire ItemDesc table
        /// </summary>
        /// <returns></returns>
        public string GetAllItems()
        {
            try
            {
                string sSQL = "SELECT * FROM ItemDesc";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Adds new item into ItemDesc table
        /// </summary>
        /// <param name="itemID">new item ID (confirmed not exists by business logic)</param>
        /// <param name="itemDesc">new item description</param>
        /// <param name="cost">new item cost</param>
        /// <returns></returns>
        public string AddItem(string itemID, string itemDesc, int cost)
        {
            try
            {
                string sSQL = "INSERT INTO ItemDesc " +
                              "VALUES ('" + itemID + "', '" + itemDesc + "', " + cost + ");";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        /// <summary>
        /// Updates an existing item in the ItemDesc table
        /// </summary>
        /// <param name="itemID">itemCode of item to be updated</param>
        /// <param name="itemDesc">updated description</param>
        /// <param name="cost">updated cost</param>
        /// <returns></returns>
        public string UpdateItem(string itemID, string itemDesc, int cost)
        {
            try
            {
                string sSQL = "UPDATE ItemDesc "+
                              "SET ItemDesc = '" + itemDesc + "', Cost = " + cost +
                              " WHERE ItemCode = '" + itemID + "'; ";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        /// <summary>
        /// Deletes the row in ItemDesc corresponding to itemID
        /// </summary>
        /// <param name="itemID">ItemCode of item to be deleted</param>
        /// <returns></returns>
        public string DeleteItem(string itemID)
        {
            try
            {
                string sSQL = "DELETE FROM ItemDesc " +
                              "WHERE ItemCode = '" + itemID + "';";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }
        /// <summary>
        /// Selects InvoiceNum for all invoices containing a desired ItemCode
        /// </summary>
        /// <param name="itemID">ItemCode of desired item</param>
        /// <returns></returns>
        public string FindItemsOnInvoices(string itemID)
        {
            try
            {
                string sSQL = "SELECT DISTINCT InvoiceNum " +
                              "FROM ItemDesc id INNER JOIN LineItems li " +
                              "ON id.ItemCode = li.ItemCode " +
                              "WHERE li.ItemCode = '" + itemID + "';";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        public string FindItemWithCode(string itemID)
        {
            try
            {
                string sSQL = "SELECT ItemCode " +
                              "FROM ItemDesc " +
                              "WHERE ItemCode = '" + itemID + "';";
                return sSQL;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }






    }
}
