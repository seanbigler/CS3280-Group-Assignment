using CS3280GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Items
{
    /// <summary>
    /// Items Logic Class
    /// </summary>
    class clsItemsLogic
    {
        #region Attributes

        /// <summary>
        /// SQL statements class
        /// </summary>
        clsItemsSQL clsSQL;
        /// <summary>
        /// Data Access Class
        /// </summary>
        clsDataAccess clsDA;
        /// <summary>
        /// DataSet to hold returned datasets from Queries
        /// </summary>
        public DataSet ds;

        #endregion

        #region Methods

        /// <summary>
        /// Instantiates classes
        /// </summary>
        public clsItemsLogic()
        {
            clsSQL = new clsItemsSQL();
            clsDA = new clsDataAccess();

        }

        /// <summary>
        /// Method for getting all Items in ItemsDesc table
        /// </summary>
        /// <returns>Observable Collection of Item objects</returns>
        public ObservableCollection<clsItem> getItems()
        {
            try
            {


                string sSQL = clsSQL.GetAllItems();
                int iRet = 0;

                ds = clsDA.ExecuteSQLStatement(sSQL, ref iRet);

                ObservableCollection<clsItem> ItemList = new ObservableCollection<clsItem>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ItemList.Add(new clsItem { sItemCode = dr[0].ToString(), sItemDesc = dr[1].ToString(), sCost = dr[2].ToString() });
                }

                return ItemList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Method to update an Item
        /// </summary>
        /// <param name="sCode">Item Code of Item to be updated</param>
        /// <param name="sDesc">New Item Description</param>
        /// <param name="sCost">New Item Cost</param>
        /// <returns>Bool; True if cost is valid, false otherwise</returns>
        public bool updateItem(string sCode, string sDesc, string sCost)
        {
            try
            {
                int iCost;
                int iRet;
                bool validCost = false;

                validCost = Int32.TryParse(sCost, out iCost);

                if (validCost)
                {
                    string sSQL = clsSQL.UpdateItem(sCode, sDesc, iCost);
                    iRet = clsDA.ExecuteNonQuery(sSQL);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }

        }

        /// <summary>
        /// Method to add item to database
        /// </summary>
        /// <param name="sCode">Item Code of Item to be added</param>
        /// <param name="sDesc">Item Description of Item to be added</param>
        /// <param name="sCost">Item Cost of Item to be added</param>
        /// <returns>Bool; True if valid cost, false otherwise</returns>
        public bool addItem(string sCode, string sDesc, string sCost)
        {
            try
            {
                int iCost;
                int iRet = 1;
                bool validCost = false;

                validCost = Int32.TryParse(sCost, out iCost);

                if (validCost)
                {
                    //Check if sCode is already used
                    string sSQL = clsSQL.FindItemWithCode(sCode);
                    clsDA.ExecuteSQLStatement(sSQL, ref iRet);
                    if (iRet == 0)
                    {
                        sSQL = clsSQL.AddItem(sCode, sDesc, iCost);
                        clsDA.ExecuteNonQuery(sSQL);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Method to delete Item from database
        /// </summary>
        /// <param name="sCode">Item Code of Item to be deleted</param>
        /// <param name="invoices">List of invoices to be set if item is on invoice</param>
        /// <returns>Bool; True if on an invoice, false otherwise</returns>
        public bool deleteItem(string sCode, ref List<string> invoices)
        {
            try
            {
                int iRet = 1;

                string sSQL = clsSQL.FindItemsOnInvoices(sCode);

                ds = clsDA.ExecuteSQLStatement(sSQL, ref iRet);

                //If not on invoice
                if (iRet == 0)
                {
                    sSQL = clsSQL.DeleteItem(sCode);
                    clsDA.ExecuteNonQuery(sSQL);

                    return false;
                }
                else
                {
                    //Pass List of invoices back go window
                    List<string> invoiceList = new List<string>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        invoiceList.Add(dr[0].ToString());
                    }

                    invoices = invoiceList;

                    return true;
                }
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
