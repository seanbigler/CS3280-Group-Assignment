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

namespace CS3280GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        #region Methods
        /// <summary>
        /// Initializes wndSearch
        /// </summary>
        public wndSearch()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Called when CBInvoiceNum's selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBInvoiceNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * TODO: 
             * Filter DGInvoices per selection 
             * Filter other CB
             */
        }

        /// <summary>
        /// Called when CBInvoiceDate's selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * TODO: 
             * Filter DGInvoices per selection 
             * Filter other CB
             */
        }

        /// <summary>
        /// Called when CBInvoiceTotal's selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBTotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * TODO: 
             * Filter DGInvoices per selection 
             * Filter other CB
             */
        }

        /// <summary>
        /// Called when DGInvoices' selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGInvoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /// <summary>
        /// Called when BtnSelect is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            /*
             * TODO: 
             * Check for selected invoice
             * give wndMain the InvoiceNum
             * close this window
             */
            this.Close();
        }

        /// <summary>
        /// Called when BtnClear is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            /*
             * TODO: 
             * Clear CBInvoiceNum and refill options
             * Clear CBInvoiceDate and refill options
             * Clear CBTotal and refill options
             * Reset DGInvoices
             */
        }

        /// <summary>
        /// Called when BtnCancel is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
