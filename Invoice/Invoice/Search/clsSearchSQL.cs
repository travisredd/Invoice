using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Search
{
    /// <summary>
    /// SearchSQL class
    /// </summary>
    public class clsSearchSQL
    {
        /// <summary>
        /// String to get AllInvoiceNums
        /// </summary>
        private string sAllInvoiceNumSQL;
        /// <summary>
        /// String to get AllInvoiceDates
        /// </summary>
        private string sAllInvoiceDateSQL;
        /// <summary>
        /// String to get AllInvoiceCosts
        /// </summary>
        private string sAllInvoiceCostSQL;
        /// <summary>
        /// String to get AllInvoices
        /// </summary>
        private string sAllInvoiceSQL;
        /// <summary>
        /// String to get Invoices By num
        /// </summary>
        private string sGetInvoiceByNum;
        /// <summary>
        /// String to get Invoices by date
        /// </summary>
        private string sGetInvoiceyByDate;
        /// <summary>
        /// String to get Invoices by cost
        /// </summary>
        private string sGetInvoiceByCost;
        /// <summary>
        /// Method to get ALLInvoiceNums
        /// </summary>
        /// <returns></returns>
        public string AllInvoiceNumSQL()
        {
            sAllInvoiceNumSQL = "SELECT InvoiceNum FROM Invoices";
            return sAllInvoiceNumSQL;
        }
        /// <summary>
        /// Method to get AllInvoicesDate
        /// </summary>
        /// <returns></returns>
        public string AllInvoiceDateSQL()
        {
            sAllInvoiceDateSQL = "SELECT InvoiceDate FROM Invoices";
            return sAllInvoiceDateSQL;
        }
        /// <summary>
        /// Method to get AllInvoiceCost
        /// </summary>
        /// <returns></returns>
        public string AllInvoiceCostSQL()
        {
            sAllInvoiceCostSQL = "SELECT TotalCost FROM Invoices";
            return sAllInvoiceCostSQL;
        }
        /// <summary>
        /// Method to get ALLInvoices
        /// </summary>
        /// <returns></returns>
        public string AllInvoiceSQL()
        {
            sAllInvoiceSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices";
            return sAllInvoiceSQL;
        }
        /// <summary>
        /// Method to get all invoices by num
        /// </summary>
        /// <param name="iNum"></param>
        /// <returns></returns>
        public string GetInvoiceByNum(int iNum)
        {
            sGetInvoiceByNum = "SELECT * FROM Invoices WHERE InvoiceNum = " + iNum ;
            return sGetInvoiceByNum;
        }
        /// <summary>
        /// Method to get all invoices by date
        /// </summary>
        /// <param name="sDate"></param>
        /// <returns></returns>
        public string GetInvoiceByDate(string sDate)
        {
            sGetInvoiceyByDate = "SELECT * FROM Invoices WHERE InvoiceDate = " + "#"+sDate+"#";
            return sGetInvoiceyByDate;
        }
        /// <summary>
        /// Method to get all invoices by cost
        /// </summary>
        /// <param name="iCost"></param>
        /// <returns></returns>
        public string GetInvoiceByCost(int iCost)
        {
            sGetInvoiceByCost = "SELECT * FROM Invoices WHERE TotalCost = " + iCost;
            return sGetInvoiceByCost;
        }
    }
}
