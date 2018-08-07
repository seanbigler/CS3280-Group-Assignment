using System;
using System.Collections.Generic;
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

        public DataSet getItems()
        {
            string sSQL = clsSQL.GetAllItems();
            int iRet = 0;

            ds = clsDA.ExecuteSQLStatement(sSQL, ref iRet);

            return ds;
        }
    }

    //Function to Update item

    //Function to Add Item

    //Function to Delete Item
}
