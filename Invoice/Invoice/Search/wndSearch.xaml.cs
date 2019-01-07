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

        public wndSearch()
        {
            InitializeComponent();
            //instantiate the clsSearchLogic object
            SearchLogic = new clsSearchLogic();

            //call getInvoiceNum method
            SearchLogic.GetInvoiceNum();
            //call getInvoiceDate method
            SearchLogic.GetInvoiceDate();
            //call getInvoiceCost method
            SearchLogic.GetInvoiceCost();
            //call getInvoice method
            SearchLogic.GetInvoice();

            //fill combo box invoice id with data
            for(int i = 0; i < SearchLogic.lstInvoiceNum.Count; i++)
            {
                invoiceId_cbobox.Items.Add(SearchLogic.lstInvoiceNum[i].iInvoiceNum);
            }
            //fill combo box invoice date with data
            for (int i = 0; i < SearchLogic.lstInvoiceDate.Count; i++)
            {
                invoiceDate_cbobox.Items.Add(SearchLogic.lstInvoiceDate[i].sInvoiceDate);
            }
            //fill combo box invoice cost with data
            for (int i = 0; i < SearchLogic.lstInvoiceCost.Count; i++)
            {
                invoiceCost_cbobox.Items.Add(SearchLogic.lstInvoiceCost[i].iInvoiceCost);
            }
            //fill dataGrid with all invoice data
            dataGrid.ItemsSource = SearchLogic.lstInvoice;
        }
        /// <summary>
        /// checks to see which invoice is selected then populates dataGrid with new invoice data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoiceId_cbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            dataGrid.ItemsSource = "";

            SearchLogic.GetInvoiceByNum((int)invoiceId_cbobox.SelectedValue);
            
            dataGrid.ItemsSource = SearchLogic.lstInvoiceByNum;

        }
        /// <summary>
        /// checks to see which date is selected then populates dataGrid with new invoice data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoiceDate_cbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sDate;

            sDate = invoiceDate_cbobox.SelectedValue.ToString();
            string sub = sDate.Substring(0, 10);

            dataGrid.ItemsSource = "";

            SearchLogic.GetInvoiceByDate(sub);
            
            dataGrid.ItemsSource = SearchLogic.lstInvoiceByDate;

        }
        /// <summary>
        /// checks to see which cost is selected then populates dataGrid with new invoice data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void invoiceCost_cbobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            dataGrid.ItemsSource = "";

            SearchLogic.GetInvoiceByCost((int)invoiceCost_cbobox.SelectedValue);

            dataGrid.ItemsSource = SearchLogic.lstInvoiceByCost;
        }
    }
}
