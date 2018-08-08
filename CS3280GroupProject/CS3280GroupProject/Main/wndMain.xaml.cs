using System;
using System.Collections.Generic;
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
        #endregion

        #region Class Methods

        public wndMain()
        {
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

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
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
