using System;
using System.Collections.Generic;
using System.Data;
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
using CS3280GroupProject.Main;
using CS3280GroupProject.Search;

namespace CS3280GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItem.xaml
    /// </summary>
    public partial class wndItem : Window
    {

        public wndMain mainWindow;
        clsItemsLogic clsIL;


        public wndItem(wndMain main)
        {
            try
            {
                InitializeComponent();
                mainWindow = main;
                clsIL = new clsItemsLogic();

                dgItems.ItemsSource = clsIL.getItems();

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            /*Take contents of txtCode, txtDescription, and txtCost and insert it into the
             * ItemDesc table.
             * 
             * Error checking to make sure all boxes have input, all inputs are valid, and that
             * contents of txtCode does not already exist as a key in ItemDesc
             */
             try
            {
                if(txtCode.Text == "" || txtDescription.Text == "" || txtCost.Text == "")
                {
                    MessageBox.Show("Please enter text in all boxes.");
                }
                else
                {
                    bool valid = clsIL.addItem(txtCode.Text, txtDescription.Text, txtCost.Text);
                    
                    if(!valid)
                    {
                        MessageBox.Show("Please enter unique item code and valid cost");
                    }
                    else
                    {
                        dgItems.ItemsSource = null;
                        dgItems.ItemsSource = clsIL.getItems();
                        txtCode.Text = "";
                        txtDescription.Text = "";
                        txtCost.Text = "";
                    }
                }

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            /*Deletes selected item (selected on the datagrid) from the ItemDesc table
             * 
             * Error checking to make sure a row is selected and selected item is not on any
             * existing invoice
             */
             try
            {
                //Make sure an index is selected
                if(dgItems.SelectedIndex != -1)
                {
                    //Call function to make sure item is not on an invoice
                    List<string> invoiceList = new List<string>();

                    bool onInvoice = clsIL.deleteItem(((clsItem)dgItems.SelectedItem).sItemCode.ToString(), ref invoiceList);

                    if(!onInvoice)
                    {
                        dgItems.ItemsSource = null;
                        dgItems.ItemsSource = clsIL.getItems();
                    }
                    else
                    {
                        string sError = "Failed to delete. Item found on following Invoices: \n";
                        for(int i = 0; i < invoiceList.Count; i++)
                        {
                            sError += (invoiceList[i] + "\n");
                        }

                        MessageBox.Show(sError);
                    }

                }
                else
                {
                    MessageBox.Show("Select an item to delete");
                }

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            /*Updates selected item (selected on the datagrid) in the ItemDesc table
             * based on contents of txtDescription and txtCost
             * 
             * Will only update Description and Cost. Values in txtCode will be ignored
             * 
             * Error checking to make sure a valid row is selected, all boxes (txtDescription and txtCost) 
             * have input, and that all inputs are valid
             */
            try
            {
                if (txtDescription.Text == "" || txtCost.Text == "")
                {
                    //Invalid input
                    MessageBox.Show("Please enter text in both Item Description and Cost boxes.");

                }
                else
                {
                    //Call function to check if cost is valid number
                    bool valid = clsIL.updateItem(((clsItem)dgItems.SelectedItem).sItemCode.ToString(), txtDescription.Text, txtCost.Text);
                    if(!valid)
                    {
                        //Cost not a number
                        MessageBox.Show("Invalid value for Cost. Try again.");
                    }
                    else
                    {
                        dgItems.ItemsSource = null;
                        dgItems.ItemsSource = clsIL.getItems();
                    }

                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void dgItems_SelectionChanged(object sender, EventArgs e)
        {
            /*When cell is changed, text boxes will fill with corresponding data from
             * selected row
             */
             try
            {
                //int iRowNum = dgItems.SelectedCells[0].Column.DisplayIndex;


                //txtCode.Text = dgItems.SelectedItem.ToString();
                if (dgItems.SelectedItem != null)
                {
                    txtCode.Text = ((clsItem)dgItems.SelectedItem).sItemCode.ToString();
                    txtDescription.Text = ((clsItem)dgItems.SelectedItem).sItemDesc.ToString();
                    txtCost.Text = ((clsItem)dgItems.SelectedItem).sCost.ToString();
                }

                //txtCode.Text = ((clsItem)dgItems.SelectedItem).sItemCode.ToString();


            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {


                if (mainWindow != null)
                {
                    mainWindow.itemWindow = null;
                    mainWindow.Show();
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Displays errors in Message Box
        /// </summary>
        /// <param name="sClass">Class name</param>
        /// <param name="sMethod">Method name</param>
        /// <param name="sMessage">Error Message</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
    }
}
