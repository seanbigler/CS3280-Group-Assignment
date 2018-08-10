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

namespace CS3280GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        #region Attributes
        /// <summary>
        /// The invoice num that is selected from the search
        /// </summary>
        private string sSelectedInvoiceNum;
        /// <summary>
        /// Reference to the main window
        /// </summary>
        public wndMain mainWindow;
        /// <summary>
        /// Contains the logic for the search window
        /// </summary>
        private clsSearchLogic searchLogic;
        /// <summary>
        /// Boolean to show if an invoiceNum is selected
        /// </summary>
        private bool isNumFiltered;
        /// <summary>
        /// Boolean to show if an invoiceDate is selected
        /// </summary>
        private bool isDateFiltered;
        /// <summary>
        /// Boolean to show if an invoiceTotal is selected
        /// </summary>
        private bool isTotalFiltered;
        /// <summary>
        /// Boolean to show if an invoiceDate and invoiceTotal is selected
        /// </summary>
        private bool isDateTotalFiltered;
        /// <summary>
        /// Boolean to show if the window is in the process of reseting to initial state
        /// </summary>
        private bool isClearing;

        /// <summary>
        /// Used to get and set sSelectedInvoiceNum
        /// </summary>
        public string SelectedInvoiceNum
        {
            get
            {
                return sSelectedInvoiceNum;
            }
            /*set
            {
                sSelectedInvoiceNum = value;
            }*/
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initializes wndSearch
        /// </summary>
        public wndSearch(wndMain main)
        {
            try
            {
                InitializeComponent();
                mainWindow = main;
                searchLogic = new clsSearchLogic();
                Start();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " ->" + ex.Message);
            }
        }

        /// <summary>
        /// Initializes all comboboxes and the datagrid
        /// </summary>
        private void Start()
        {
            try
            {
                isClearing = true;
                isNumFiltered = false;
                isDateFiltered = false;
                isTotalFiltered = false;
                isDateTotalFiltered = false;

                CBInvoiceNum.Items.Clear();
                CBInvoiceDate.Items.Clear();
                CBTotal.Items.Clear();

                List<string> tempNums = searchLogic.GetAllInvoiceNums();
                foreach (string item in tempNums)
                {
                    CBInvoiceNum.Items.Add(item);
                }

                List<string> tempDates = searchLogic.GetAllInvoiceDates();
                foreach (string item in tempDates)
                {
                    CBInvoiceDate.Items.Add(item);
                }

                List<string> tempTotals = searchLogic.GetAllInvoiceTotals();
                foreach (string item in tempTotals)
                {
                    CBTotal.Items.Add(item);
                }

                DataSet tempDataSet = searchLogic.GetAllInvoices();
                DGInvoices.ItemsSource = tempDataSet.Tables[0].DefaultView;
                isClearing = false;
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
            try
            {
                if (!isClearing)
                {
                    isNumFiltered = true;
                    isDateFiltered = false;
                    isTotalFiltered = false;

                    CBInvoiceDate.Items.Clear();
                    CBTotal.Items.Clear();

                    List<string> tempDates = searchLogic.GetInvoiceDateWithNum(CBInvoiceNum.SelectedItem.ToString());
                    foreach (string item in tempDates)
                    {
                        CBInvoiceDate.Items.Add(item);
                    }

                    List<string> tempTotals = searchLogic.GetInvoiceTotalWithNum(CBInvoiceNum.SelectedItem.ToString());
                    foreach (string item in tempTotals)
                    {
                        CBTotal.Items.Add(item);
                    }

                    DataSet tempDataSet = searchLogic.GetAllInvoicesWithNum(CBInvoiceNum.SelectedItem.ToString());
                    DGInvoices.ItemsSource = tempDataSet.Tables[0].DefaultView;
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called when CBInvoiceDate's selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBInvoiceDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!isClearing && !isNumFiltered)
                {
                    if (isTotalFiltered)//filtered by date and total
                    {
                        isDateFiltered = true;

                        CBInvoiceNum.Items.Clear();

                        List<string> tempNums = searchLogic.GetInvoiceNumsWithDateTotal(CBInvoiceDate.SelectedItem.ToString(), CBTotal.SelectedItem.ToString());
                        foreach (string item in tempNums)
                        {
                            CBInvoiceNum.Items.Add(item);
                        }

                        DataSet tempDataSet = searchLogic.GetAllInvoicesWithDateTotal(CBInvoiceDate.SelectedItem.ToString(), CBTotal.SelectedItem.ToString());
                        DGInvoices.ItemsSource = tempDataSet.Tables[0].DefaultView;

                        if (!isDateTotalFiltered) {
                            isClearing = true;
                            isDateTotalFiltered = true;

                            string tempTotal = CBTotal.SelectedItem.ToString();

                            CBTotal.Items.Clear();

                            List<string> tempTotals = searchLogic.GetInvoiceTotalWithDate(CBInvoiceDate.SelectedItem.ToString());
                            foreach (string item in tempTotals)
                            {
                                CBTotal.Items.Add(item);
                            }

                            CBTotal.SelectedItem = tempTotal;
                            isClearing = false;
                        }
                    }
                    else//Filtered by date
                    {
                        isDateFiltered = true;

                        CBInvoiceNum.Items.Clear();
                        CBTotal.Items.Clear();

                        List<string> tempNums = searchLogic.GetInvoiceNumsWithDate(CBInvoiceDate.SelectedItem.ToString());
                        foreach (string item in tempNums)
                        {
                            CBInvoiceNum.Items.Add(item);
                        }

                        List<string> tempTotals = searchLogic.GetInvoiceTotalWithDate(CBInvoiceDate.SelectedItem.ToString());
                        foreach (string item in tempTotals)
                        {
                            CBTotal.Items.Add(item);
                        }

                        DataSet tempDataSet = searchLogic.GetAllInvoicesWithDate(CBInvoiceDate.SelectedItem.ToString());
                        DGInvoices.ItemsSource = tempDataSet.Tables[0].DefaultView;
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called when CBInvoiceTotal's selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CBTotal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!isClearing && !isNumFiltered)
                {
                    if (isDateFiltered)//filtered by date and total
                    {
                        isTotalFiltered = true;

                        CBInvoiceNum.Items.Clear();

                        List<string> tempNums = searchLogic.GetInvoiceNumsWithDateTotal(CBInvoiceDate.SelectedItem.ToString(), CBTotal.SelectedItem.ToString());
                        foreach (string item in tempNums)
                        {
                            CBInvoiceNum.Items.Add(item);
                        }

                        DataSet tempDataSet = searchLogic.GetAllInvoicesWithDateTotal(CBInvoiceDate.SelectedItem.ToString(), CBTotal.SelectedItem.ToString());
                        DGInvoices.ItemsSource = tempDataSet.Tables[0].DefaultView;

                        if (!isDateTotalFiltered)
                        {
                            isClearing = true;
                            isDateTotalFiltered = true;

                            string tempDate = CBInvoiceDate.SelectedItem.ToString();

                            CBInvoiceDate.Items.Clear();

                            List<string> tempDates = searchLogic.GetInvoiceDateWithTotal(CBTotal.SelectedItem.ToString());
                            foreach (string item in tempDates)
                            {
                                CBInvoiceDate.Items.Add(item);
                            }

                            CBInvoiceDate.SelectedItem = tempDate;
                            isClearing = false;
                        }
                    }
                    else//Filtered by total
                    {
                        isTotalFiltered = true;

                        CBInvoiceNum.Items.Clear();
                        CBInvoiceDate.Items.Clear();

                        List<string> tempNums = searchLogic.GetInvoiceNumsWithTotal(CBTotal.SelectedItem.ToString());
                        foreach (string item in tempNums)
                        {
                            CBInvoiceNum.Items.Add(item);
                        }

                        List<string> tempDates = searchLogic.GetInvoiceDateWithTotal(CBTotal.SelectedItem.ToString());
                        foreach (string item in tempDates)
                        {
                            CBInvoiceDate.Items.Add(item);
                        }

                        DataSet tempDataSet = searchLogic.GetAllInvoicesWithTotal(CBTotal.SelectedItem.ToString());
                        DGInvoices.ItemsSource = tempDataSet.Tables[0].DefaultView;
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called when DGInvoices' selection is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGInvoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Possibly not needed
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called when BtnSelect is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((DataRowView)DGInvoices.SelectedValue != null) {
                    //System.Windows.MessageBox.Show(((DataRowView)DGInvoices.SelectedValue).Row[0].ToString());
                    sSelectedInvoiceNum = ((DataRowView)DGInvoices.SelectedValue).Row[0].ToString();

                    Start();
                    this.Hide();
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Please select an invoice");
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called when BtnClear is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Start();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Called when BtnCancel is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sSelectedInvoiceNum = "";
                Start();
                this.Hide();
                mainWindow.Show();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Opens the main window back up after closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (mainWindow != null)
                {
                    mainWindow.searchWindow = null;
                    mainWindow.Show();
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// exception handler that shows the error
        /// </summary>
        /// <param name="sClass">the class</param>
        /// <param name="sMethod">the method</param>
        /// <param name="sMessage">the error message</param>
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
