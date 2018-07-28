using System;
using System.Collections.Generic;
using System.Linq;
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
        public wndSearch searchWindow;

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
        }

        /// <summary>
        /// This click event will handle the openning and closing of the Search window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
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
        }

        }
    }
}
