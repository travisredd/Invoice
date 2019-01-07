/**********
Travis Redd
12/21/2018
**********/
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
