using CS3280GroupProject.Search;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS3280GroupProject.Main
{
    class clsInvoice
    {
        /// <summary>
        /// invoice number
        /// </summary>
        private int invoiceNumber{ get; set; }
        /// <summary>
        /// invoice date
        /// </summary>
        private string invoiceDate { get; set; }
        /// <summary>
        /// line items collection
        /// </summary>
        private ObservableCollection<clsItem> lineItemList { get; set; }
        /// <summary>
        /// getter for invoice number
        /// </summary>
        /// <returns></returns>
        public int getInvoiceNumber() {
            return this.invoiceNumber;
        }
        /// <summary>
        /// getter for invoice date
        /// </summary>
        /// <returns></returns>
        public string getInvoiceDate() {
            return this.invoiceDate;
        }
        /// <summary>
        /// getter for line items list
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<clsItem> getLineItemList() {
            return this.lineItemList;
        }
        /// <summary>
        /// setter for invoice number
        /// </summary>
        /// <param name="num"></param>
        public void setInvoiceNumber(int num) {
            this.invoiceNumber = num;
        }
        /// <summary>
        /// setter for invoice date
        /// </summary>
        /// <param name="date"></param>
        public void setInvoiceDate(string date) {
            this.invoiceDate = date;
        }
        /// <summary>
        /// setter for line items list
        /// </summary>
        /// <param name="list"></param>
        public void setLineItemList(ObservableCollection<clsItem> list) {
            this.lineItemList = list;
        }
    }
}
