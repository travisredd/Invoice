/**********
Travis Redd
12/21/2018
**********/
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

namespace Invoice.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// Create object reference to SearchLogic class
        /// </summary>
        clsSearchLogic SearchLogic;
        /// <summary>
        /// wnd List to hold invoice
        /// </summary>
        public List<clsInvoice> lstInvoice;
        /// <summary>
        /// boolean is true if returning value
        /// </summary>
        public bool bReturn;
        /// <summary>
        /// boolean is true if combo box is triggered
        /// </summary>
        public bool bComboBoxTriggered;
        /// <summary>
        /// boolean is true if datagrid is triggered
        /// </summary>
        public bool bDataGridTriggered;
        /// <summary>
        /// Constructor
        /// </summary>
        public wndSearch()
        {
            InitializeComponent();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            //instantiate the clsSearchLogic object
            SearchLogic = new clsSearchLogic();

            //call getInvoice method
            SearchLogic.GetInvoice();

            FillComboBoxes();

            lstInvoice = SearchLogic.lstInvoice;

            //fill dataGrid with all invoice data
            dataGrid.ItemsSource = lstInvoice;

            bReturn = false;

            bComboBoxTriggered = false;

            bDataGridTriggered = false;
        }

        /// <summary>
        /// Fills the combo boxes with data
        /// </summary>
        private void FillComboBoxes()
        {
            //fill combo box invoice id with data
            for (int i = 0; i < SearchLogic.lstInvoice.Count; i++)
            {
                invoiceId_cbobox.Items.Add(SearchLogic.lstInvoice[i].iInvoiceNum);
            }
            //fill combo box invoice date with data
            for (int i = 0; i < SearchLogic.lstInvoice.Count; i++)
            {
                invoiceDate_cbobox.Items.Add(SearchLogic.lstInvoice[i].sInvoiceDate);
            }
            //fill combo box invoice cost with data
            for (int i = 0; i < SearchLogic.lstInvoice.Count; i++)
            {
                invoiceCost_cbobox.Items.Add(SearchLogic.lstInvoice[i].iInvoiceCost);
            }
        }

        /// <summary>
        /// Loads the selected invoice to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceId_cbobox_DropDownClosed(object sender, EventArgs e)
        {
            bDataGridTriggered = false;

            bComboBoxTriggered = true;

            int iIndex = invoiceId_cbobox.SelectedIndex;
            invoiceDate_cbobox.Text = SearchLogic.lstInvoice[iIndex].sInvoiceDate.ToString();
            invoiceCost_cbobox.Text = SearchLogic.lstInvoice[iIndex].iInvoiceCost.ToString();

            int iNum = (int)invoiceId_cbobox.SelectedValue;

            dataGrid.ItemsSource = "";

            SearchLogic.GetInvoiceByNum(iNum);

            lstInvoice = SearchLogic.lstInvoiceByNum;

            dataGrid.ItemsSource = lstInvoice;

            bComboBoxTriggered = false;

        }

        /// <summary>
        /// Loads the selected invoice to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceDate_cbobox_DropDownClosed(object sender, EventArgs e)
        {
            bDataGridTriggered = false;

            bComboBoxTriggered = true;

            int iIndex = invoiceDate_cbobox.SelectedIndex;
            invoiceId_cbobox.Text = SearchLogic.lstInvoice[iIndex].iInvoiceNum.ToString();
            invoiceCost_cbobox.Text = SearchLogic.lstInvoice[iIndex].iInvoiceCost.ToString();

            string sDate;

            sDate = invoiceDate_cbobox.SelectedValue.ToString();
            string sub = sDate.Substring(0, 10);

            dataGrid.ItemsSource = "";

            SearchLogic.GetInvoiceByDate(sub);

            lstInvoice = SearchLogic.lstInvoiceByDate;

            dataGrid.ItemsSource = lstInvoice;

            bComboBoxTriggered = false;

        }

        /// <summary>
        /// Loads the selected invoice to datagrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InvoiceCost_cbobox_DropDownClosed(object sender, EventArgs e)
        {
            bDataGridTriggered = false;

            bComboBoxTriggered = true;

            int iIndex = invoiceCost_cbobox.SelectedIndex;
            invoiceId_cbobox.Text = SearchLogic.lstInvoice[iIndex].iInvoiceNum.ToString();
            invoiceDate_cbobox.Text = SearchLogic.lstInvoice[iIndex].sInvoiceDate.ToString();

            int iCost = (int)invoiceCost_cbobox.SelectedValue;

            dataGrid.ItemsSource = "";

            SearchLogic.GetInvoiceByCost(iCost);

            lstInvoice = SearchLogic.lstInvoiceByCost;

            dataGrid.ItemsSource = lstInvoice;

            bComboBoxTriggered = false;
        }

        /// <summary>
        /// Select button sends invoice to wndMain
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Select_btn_Click(object sender, RoutedEventArgs e)
        {
            if(bDataGridTriggered == true)
            {
                bReturn = true;
                int iNum = lstInvoice[dataGrid.SelectedIndex].iInvoiceNum;

                ((wndMain)Application.Current.MainWindow).DisplayInvoiceInfo();

                this.Close();

                bReturn = false;
            }

        }

        /// <summary>
        /// Datagrid selection changed update textbox with invoice info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (bComboBoxTriggered == false && dataGrid.SelectedItem.ToString() != "{NewItemPlaceholder}")
            {
                bDataGridTriggered = true;

                invoiceId_cbobox.Text = lstInvoice[dataGrid.SelectedIndex].iInvoiceNum.ToString();
                invoiceDate_cbobox.Text = lstInvoice[dataGrid.SelectedIndex].sInvoiceDate.ToString();
                invoiceCost_cbobox.Text = lstInvoice[dataGrid.SelectedIndex].iInvoiceCost.ToString();
            }
            
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {

            this.Close();    

        }
    }
}
