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
using CS3280GroupProject.Main;

namespace CS3280GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItem.xaml
    /// </summary>
    public partial class wndItem : Window
    {

        public wndMain mainWindow;


        public wndItem(wndMain main)
        {
            try
            {
                InitializeComponent();
                mainWindow = main;

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
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
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            /*Deletes selected item (selected on the datagrid) from the ItemDesc table
             * 
             * Error checking to make sure a row is selected and selected item is not on any
             * existing invoice
             */
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
        }

        private void dgItems_CurrentCellChanged(object sender, EventArgs e)
        {
            /*When cell is changed, text boxes will fill with corresponding data from
             * selected row
             */
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mainWindow != null)
            {
                mainWindow.itemWindow = null;
                mainWindow.Show();
            }
        }
    }
}
