using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CS3280GroupProject.Items;
using CS3280GroupProject.Search;

namespace CS3280GroupProject.Main
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        #region Class Attributes
        public wndSearch searchWindow;
        public wndItem itemWindow;
        ObservableCollection<clsItem> itemList;
        ObservableCollection<clsItem> lineItemList;
        clsItemsLogic item;
        public string selectedItem;
        clsItem currItem;

        #endregion

        #region Class Methods

        public wndMain()
        {

            itemList = new ObservableCollection<clsItem>();
            item = new clsItemsLogic();
            lineItemList = new ObservableCollection<clsItem>();
            currItem = new clsItem();
            InitializeComponent();
        }

        /// <summary>
        /// This click event will handle the openning and closing of the Update window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (itemWindow == null)
                {
                    itemWindow = new wndItem(this);
                }
                this.Hide();
                itemWindow.Show();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            //Simple .Hide() and .ShowDialog() methods
           
        }

        /// <summary>
        /// This click event will handle the openning and closing of the Search window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchWindow == null)
                {
                    searchWindow = new wndSearch(this);
                }
                this.Hide();
                searchWindow.Show();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
           
        }

        /// <summary>
        /// This click event will allow user to enter invoice information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            /* The text boxes and drop box will need to be enabled in the information section
             * allowing users to edit set values, add and remove line items and save.
             * 
             * Datagrid also will be updated as items are added and removed.
             * NOTE: edit and delete buttons remain disabled.
             */
            try
            {
                //enable controls
                dpInvoiceDate.IsEnabled = true;
                tbItemCost.IsEnabled = true;
                cbLineItem.IsEnabled = true;
                dgMain.IsEnabled = true;
                btnAddItem.IsEnabled = true;
                btnRemoveItem.IsEnabled = true;
                btnSaveInvoice.IsEnabled = true;

                //set placeholder to TBD 
                tbInvoiceNumber.Text = "TBD";

                //get list of items from clsItemsLogic
                itemList = item.getItems();

                //populate item list dropdown
                foreach (clsItem item in itemList) {
                    cbLineItem.Items.Add(item.sItemDesc);
                }

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Line Item combo box selection change handler method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbLineItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            //get value of selected item
            selectedItem = cb.SelectedItem.ToString();

            //find cost of selected item
            foreach (clsItem item in itemList)
            {
                if (item.sItemDesc.ToString() == selectedItem)
                {
                    //fill cost text box with selected item price
                    tbItemCost.Text = "$" + item.sCost.ToString();
                }
            } 
        }

        /// <summary>
        /// This click event will allow the user to edit line items. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            /* Once a user has saved the invoice. 
             * The necessary textbox's and combobox will be enabled for editing. 
             * 
             * Datagrid also will be updated as necessary.
             */
            try
            {

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This click event will allow user to delete new invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            /* This button will take SQL statement for deletingInvoice() 
             * to delete all rows in invoice and lineitems tables.
             * 
             * It will disable all user controls in information section other than the add button. 
             */
            try
            {
              
                //delete invoice from tables
                clsMainSQL.deleteInvoice(Int32.Parse(tbInvoiceNumber.Text));

                //reset all to default
                tbInvoiceNumber.IsEnabled = false;
                tbInvoiceNumber.Text = "TBD";
                dpInvoiceDate.IsEnabled = true;
                dpInvoiceDate.DisplayDate = DateTime.Today;
                dpInvoiceDate.IsEnabled = false;
                tbItemCost.Text = "";
                tbItemCost.IsEnabled = false;
                tbItemCost.IsReadOnly = true;
                cbLineItem.IsEnabled = false;
                btnAddItem.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnRemoveItem.IsEnabled = false;
                btnSaveInvoice.IsEnabled = false;
                tbInvoiceNumber.IsReadOnly = true;
                btnAdd.IsEnabled = true;
                tbTotal.Content = "$0";

                //clear line item list
                foreach (clsItem item in lineItemList)
                {
                    dgMain.Items.Remove(item);
                }
                lineItemList.Clear();

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This click event will allow users to add line items to invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            /* This will use SQL addLineItem to insert new line item from combobox into database.
             * 
             * Refresh dataGrid with updated items.
             */
            try
            {
                
                 foreach (clsItem item in itemList)
                {
                    if (item.sItemDesc.ToString() == selectedItem)
                    {
                        //fill cost text box with selected item price
                        currItem.sItemCode = item.sItemCode.ToString();
                        currItem.sCost = item.sCost.ToString();
                        currItem.sItemDesc = item.sItemDesc.ToString();
                    }
                }

                 //temp sum variable
                double sum = 0;

                //add item to line item list
                lineItemList.Add(currItem);
                //add item to data grid
                dgMain.Items.Add(currItem);

                foreach (clsItem item in lineItemList) {
                    sum += double.Parse(item.sCost);
                }
                tbTotal.Content = "$" + sum.ToString();
               
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// This click event will allow user to remove line items from invoice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            /* This will use SQL removeLineItem to delete line item from database.
             * 
             * Refresh dataGrid to update items list.
             */
            try
            {
                double sum2 = 0;

                if (lineItemList.Count != 0) {
                    //remove item from datagrid
                    dgMain.Items.Remove(currItem);

                    //remove from list
                    lineItemList.Remove(currItem);

                    //repopulate total count based on lineitemslist
                    foreach (clsItem item in lineItemList)
                    {
                        sum2 += double.Parse(item.sCost);
                    }
                    tbTotal.Content = "$" + sum2.ToString();
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// This click event will save invoice to database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            /* This button will check all user input to make sure date and invoice number is there
             * NOTE: if adding invoice then TBD is valid.
             * If not valid or entered, messagebox will inform user.
             * 
             * All information controls are set to read only except for edit and delete.
             * Edit and delete button become enabled.
             * 
             * All invoice and line items are added to database or updated line items in database.
             */
            try
            {
                if (tbInvoiceNumber.Text != "TBD") { //exists update
                    clsMainSQL.updateInvoice(Int32.Parse(tbInvoiceNumber.Text), dpInvoiceDate.Text);
                    foreach (clsItem item in lineItemList)
                    {
                        clsMainSQL.updateLineItem(clsMainSQL.getNewInvoiceNumber(), (lineItemList.IndexOf(item) + 1), item.sItemCode);
                    }
                }
                else {// add new
                    int count = 1;
                    clsMainSQL.addInvoice(dpInvoiceDate.Text);
                    //look up last entry and add lineitems to table
                    foreach (clsItem item in lineItemList) {
                        clsMainSQL.addInvoiceLineItem(clsMainSQL.getNewInvoiceNumber(),count,item.sItemCode);
                        count++;
                    }

                    //set everything to read only 
                    tbInvoiceNumber.Text = clsMainSQL.getNewInvoiceNumber().ToString();
                    tbInvoiceNumber.IsEnabled = false;
                    dpInvoiceDate.IsEnabled = false;
                    btnAdd.IsEnabled = false;
                    tbItemCost.IsEnabled = false;
                    tbItemCost.IsReadOnly = true;
                    cbLineItem.IsEnabled = false;
                    btnAddItem.IsEnabled = false;
                    btnRemoveItem.IsEnabled = false;
                    btnSaveInvoice.IsEnabled = false;
                    tbInvoiceNumber.IsReadOnly = true;
                    btnEdit.IsEnabled = true;
                    btnDelete.IsEnabled = true;

                   
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// This load event will create dataset with necessary values for dropbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            /* Upon load updated datasource objects will be loaded and read into combobox.
             * 
             * Controls except for update search and add will be disabled.
             */
            try
            {
                tbInvoiceNumber.IsEnabled = false;
                dpInvoiceDate.IsEnabled = false;
                dpInvoiceDate.DisplayDate = DateTime.Today;
                tbItemCost.IsEnabled = false;
                tbItemCost.IsReadOnly = true;
                cbLineItem.IsEnabled = false;
                btnAddItem.IsEnabled = false;
                btnRemoveItem.IsEnabled = false;
                btnSaveInvoice.IsEnabled = false;
                tbInvoiceNumber.IsReadOnly = true;
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Closes all other windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (searchWindow != null)
                {
                    searchWindow.mainWindow = null;
                    searchWindow.Close();
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        
        }
        /// <summary>
        /// Top level error handler to catch thrown exceptions
        /// </summary>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
        #endregion

    }
}
