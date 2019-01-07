/**********
Travis Redd
12/21/2018
**********/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Main
{
    /// <summary>
    /// 
    /// </summary>
    public class clsMainSQL
    {
        //get item info from invoice number display it in datagrid
        //connect new invoice to insert into 
        //delete invoice delete sql statement messagebox yes no delete
        //edit update sql
        //populate items combo box with items
        //add item inserts into items sql
        //delete item deletes item sql are you sure you want to delete messagebox yes or no
        //if wndMain text box text changes and save invoice button is true then update sql invoice messagebox are you sure you want to save yes or no

        /// <summary>
        /// 
        /// </summary>
        private string sUpdateInvoiceSQL;
        /// <summary>
        /// 
        /// </summary>
        private string sDeleteInvoiceSQL;
        /// <summary>
        /// 
        /// </summary>
        private string sNewInvoiceSQL;
        /// <summary>
        /// 
        /// </summary>
        private string sDeleteItemSQL;
        /// <summary>
        /// 
        /// </summary>
        private string sSaveItemSQL;
        /// <summary>
        /// 
        /// </summary>
        private string sGetItemSQL;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string UpdateInvoice(int iNum, string sDate, string sCost)
        {
            sUpdateInvoiceSQL = "";
            return sUpdateInvoiceSQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DeleteInvoice(int iNum)
        {
            sDeleteInvoiceSQL = "";
            return sDeleteInvoiceSQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string NewInvoice(string sDate, int iCost)
        {
            sNewInvoiceSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost) "
               + "VALUES ('" + sDate + "', '" + iCost + "')";
            return sNewInvoiceSQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string SaveItem()
        {
            sSaveItemSQL = "";
            return sSaveItemSQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DeleteItem()
        {
            sDeleteItemSQL = "";
            return sDeleteItemSQL;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetItems()
        {
            sGetItemSQL = "";
            return sGetItemSQL;
        }
    }
}
