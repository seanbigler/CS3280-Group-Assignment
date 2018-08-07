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

        //Function to Delete Item
    }


}
