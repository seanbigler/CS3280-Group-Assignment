using CS3280GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Items
{

    class clsItemsLogic
    {
        clsItemsSQL clsSQL;
        clsDataAccess clsDA;
        public DataSet ds;

        public clsItemsLogic()
        {
            clsSQL = new clsItemsSQL();
            clsDA = new clsDataAccess();

        }
        /*
        public DataSet getItems()
        {
            string sSQL = clsSQL.GetAllItems();
            int iRet = 0;

            ds = clsDA.ExecuteSQLStatement(sSQL, ref iRet);

            return ds;
        }
        */
        public ObservableCollection<clsItem> getItems()
        {
            string sSQL = clsSQL.GetAllItems();
            int iRet = 0;

            ds = clsDA.ExecuteSQLStatement(sSQL, ref iRet);

            ObservableCollection<clsItem> ItemList = new ObservableCollection<clsItem>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                ItemList.Add(new clsItem { sItemCode = dr[0].ToString(), sItemDesc = dr[1].ToString(), sCost = dr[2].ToString() });
            }

            return ItemList;
        }

        //Function to Update item
        public bool updateItem(string sCode, string sDesc, string sCost)
        {
            int iCost;
            int iRet;
            bool validCost = false;

            validCost = Int32.TryParse(sCost, out iCost);

            if(validCost)
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

        //Function to Add Item
        public bool addItem(string sCode, string sDesc, string sCost)
        {
            int iCost;
            int iRet = 1;
            bool validCost = false;

            validCost = Int32.TryParse(sCost, out iCost);

            if(validCost)
            {
                //Check if sCode is already used
                string sSQL = clsSQL.FindItemWithCode(sCode);
                clsDA.ExecuteSQLStatement(sSQL, ref iRet);
                if(iRet == 0)
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

        //Function to Delete Item
        public bool deleteItem(string sCode, ref List<string> invoices)
        {
            int iRet = 1;

            string sSQL = clsSQL.FindItemsOnInvoices(sCode);

            ds = clsDA.ExecuteSQLStatement(sSQL, ref iRet);

            //If not on invoice
            if(iRet == 0)
            {
                sSQL = clsSQL.DeleteItem(sCode);
                clsDA.ExecuteNonQuery(sSQL);

                return false;
            }
            else
            {
                //Pass List of invoices back go window
                List<string> invoiceList = new List<string>();
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    invoiceList.Add(dr[0].ToString());
                }

                invoices = invoiceList;

                return true;
            }
        }
    }


}
