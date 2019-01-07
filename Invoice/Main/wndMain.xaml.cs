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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Invoice
{
    /// <summary>
    /// Interaction logic for wndMain.xaml
    /// </summary>
    public partial class wndMain : Window
    {
        /// <summary>
        /// 
        /// </summary>
        Main.clsMainLogic MainLogic;
        /// <summary>
        /// Create wndSearch object
        /// </summary>
        Search.wndSearch wndSearch;
        /// <summary>
        /// List to hold invoices from wndSearch - maybe I dont need
        /// </summary>
        List<clsInvoice> lstInvoice;
        /// <summary>
        /// Constructor
        /// </summary>
        public wndMain()
        {
            InitializeComponent();

            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

            saveInvoice_btn.Visibility = Visibility.Hidden;
            editInvoice_btn.Visibility = Visibility.Hidden;

            deleteInvoice_btn.Visibility = Visibility.Hidden;
            newInvoice_btn.Visibility = Visibility.Visible;

            lstInvoice = new List<clsInvoice>();

            MainLogic = new Main.clsMainLogic();

        }

        /// <summary>
        /// Displays the current invoice in the textboxes is called from wndSearch
        /// </summary>
        public void DisplayInvoiceInfo()
        {
            invoiceId_txtbox.Text = "";
            invoiceDate_txtbox.Text = "";
            invoiceCost_txtbox.Text = "";

            if(wndSearch.bReturn == true)
            {
                editInvoice_btn.Visibility = Visibility.Visible;

                deleteInvoice_btn.Visibility = Visibility.Visible;
                newInvoice_btn.Visibility = Visibility.Hidden;
                saveInvoice_btn.Visibility = Visibility.Hidden;

                invoiceId_txtbox.Text = wndSearch.lstInvoice[wndSearch.dataGrid.SelectedIndex].iInvoiceNum.ToString();
                invoiceDate_txtbox.Text = wndSearch.lstInvoice[wndSearch.dataGrid.SelectedIndex].sInvoiceDate.ToString();
                invoiceCost_txtbox.Text = wndSearch.lstInvoice[wndSearch.dataGrid.SelectedIndex].iInvoiceCost.ToString();
            }
        }

        /// <summary>
        /// Button that opens the wndSearch window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            wndSearch = new Invoice.Search.wndSearch();

            wndSearch.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewInvoice_btn_Click(object sender, RoutedEventArgs e)
        {

            saveInvoice_btn.Visibility = Visibility.Visible;

            invoiceId_txtbox.Text = "";
            invoiceDate_txtbox.Text = "";
            invoiceCost_txtbox.Text = "";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditInvoice_btn_Click(object sender, RoutedEventArgs e)
        {

            saveInvoice_btn.Visibility = Visibility.Visible;
            //call method in MainLogic that edits invoice passing the num, date and cost into the update sql 

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveInvoice_btn_Click(object sender, RoutedEventArgs e)
        {

            int iCost;
            iCost = Convert.ToInt32(invoiceCost_txtbox.Text);

            deleteInvoice_btn.Visibility = Visibility.Hidden;
            editInvoice_btn.Visibility = Visibility.Hidden;
            saveInvoice_btn.Visibility = Visibility.Hidden;
            newInvoice_btn.Visibility = Visibility.Visible;
            
            MainLogic.NewInvoice(invoiceDate_txtbox.Text, iCost);

        }
    }
}
