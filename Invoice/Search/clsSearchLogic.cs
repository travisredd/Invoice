/**********
Travis Redd
12/21/2018
**********/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace Invoice.Search
{
    /// <summary>
    /// SearchLogic class
    /// </summary>
    public class clsSearchLogic
    {
        /// <summary>
        /// Create clsSearchSQL object reference
        /// </summary>
        clsSearchSQL SearchSQL;

        /**********************DataBase Objects************************/
        /// <summary>                                               /**/
        /// Create clsDataAccess object reference                   /**/
        /// </summary>                                              /**/
        clsDataAccess db;                                           /**/
        /// <summary>                                               /**/
        /// Create DataSet object reference to hold the data        /**/
        /// </summary>                                              /**/
        public DataSet ds;                                          /**/
        /// <summary>                                               /**/
        /// Create var named iRet, returns the number of values     /**/
        /// </summary>                                              /**/
        public int iRet;                                            /**/
        /**************************************************************/

        /***************************Default List************************/
        /// <summary>                                                /**/
        /// List to hold invoice number from the database            /**/
        /// </summary>                                               /**/
        public List<clsInvoice> lstInvoiceNum;                       /**/
        /// <summary>                                                /**/
        /// list to hold the invoice date from the database          /**/
        /// </summary>                                               /**/
        public List<clsInvoice> lstInvoiceDate;                      /**/
        /// <summary>                                                /**/
        /// List to hold the invoice cost from the database          /**/
        /// </summary>                                               /**/
        public List<clsInvoice> lstInvoiceCost;                      /**/
        /// <summary>                                                /**/
        /// List to hold the invoice from the database               /**/
        /// </summary>                                               /**/
        public List<clsInvoice> lstInvoice;                          /**/
        /***************************************************************/
        /// <summary>
        /// list to hold invoice by invoice num
        /// </summary>
        public List<clsInvoice> lstInvoiceByNum;
        /// <summary>
        /// list to hold invoice by date
        /// </summary>
        public List<clsInvoice> lstInvoiceByDate;
        /// <summary>
        /// list to hold invoice by cost
        /// </summary>
        public List<clsInvoice> lstInvoiceByCost;

        /// <summary>
        /// Constructor
        /// </summary>
        public clsSearchLogic()
        {
            SearchSQL = new clsSearchSQL();

            ds = new DataSet();

            iRet = 0;
        }

        /*********************************************Default List Method********************************************/                                                                                                              /**/
        /// <summary>                                                                                             /**/
        /// Get invoice data                                                                                      /**/
        /// </summary>                                                                                            /**/
        /// <returns></returns>                                                                                   /**/
        public List<clsInvoice> GetInvoice()                                                                      /**/
        {                                                                                                         /**/
            string sSub;                                                                                          /**/
                                                                                                                  /**/
            lstInvoice = new List<clsInvoice>();                                                                  /**/
                                                                                                                  /**/
            db = new clsDataAccess();                                                                             /**/
                                                                                                                  /**/
            ds = db.ExecuteSQLStatement(SearchSQL.AllInvoiceSQL(), ref iRet);                                     /**/
                                                                                                                  /**/
            for (int i = 0; i < iRet; i++)                                                                        /**/
            {                                                                                                     /**/
                sSub = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();                                            /**/
                                                                                                                  /**/
                lstInvoice.Add(new clsInvoice { iInvoiceNum = (int)ds.Tables[0].Rows[i]["InvoiceNum"],            /**/
                    sInvoiceDate = sSub.Substring(0,10),                                                          /**/
                    iInvoiceCost = (int)ds.Tables[0].Rows[i]["TotalCost"]});                                      /**/
            }                                                                                                     /**/
                                                                                                                  /**/
            return lstInvoice;                                                                                    /**/
        }                                                                                                         /**/
        /************************************************************************************************************/

        /// <summary>
        /// Get invoice data by invoice num
        /// </summary>
        /// <returns></returns>
        public List<clsInvoice> GetInvoiceByNum(int iNum)
        {
            string sSub;

            lstInvoiceByNum = new List<clsInvoice>();

            db = new clsDataAccess();

            ds = db.ExecuteSQLStatement(SearchSQL.GetInvoiceByNum(iNum), ref iRet);

            for (int i = 0; i < iRet; i++)
            {
                sSub = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                lstInvoiceByNum.Add(new clsInvoice
                {
                    iInvoiceNum = (int)ds.Tables[0].Rows[i]["InvoiceNum"],
                    sInvoiceDate = sSub.Substring(0,10),
                    iInvoiceCost = (int)ds.Tables[0].Rows[i]["TotalCost"]
                });
            }

            return lstInvoiceByNum;
        }

        /// <summary>
        /// Get invoice data by invoice date
        /// </summary>
        /// <returns></returns>
        public List<clsInvoice> GetInvoiceByDate(string sDate)
        {
            string sSub;

            lstInvoiceByDate = new List<clsInvoice>();

            db = new clsDataAccess();

            ds = db.ExecuteSQLStatement(SearchSQL.GetInvoiceByDate(sDate), ref iRet);

            for (int i = 0; i < iRet; i++)
            {
                sSub = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();

                lstInvoiceByDate.Add(new clsInvoice
                {
                    iInvoiceNum = (int)ds.Tables[0].Rows[i]["InvoiceNum"],
                    sInvoiceDate = sSub.Substring(0,10),
                    iInvoiceCost = (int)ds.Tables[0].Rows[i]["TotalCost"]
                });
            }

            return lstInvoiceByDate;
        }

        /// <summary>
        /// Get invoice data by invoice cost
        /// </summary>
        /// <returns></returns>
        public List<clsInvoice> GetInvoiceByCost(int iCost)
        {
            string sSub;

            lstInvoiceByCost = new List<clsInvoice>();

            db = new clsDataAccess();

            ds = db.ExecuteSQLStatement(SearchSQL.GetInvoiceByCost(iCost), ref iRet);

            for (int i = 0; i < iRet; i++)
            {
                sSub = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();
                lstInvoiceByCost.Add(new clsInvoice
                {
                    iInvoiceNum = (int)ds.Tables[0].Rows[i]["InvoiceNum"],
                    sInvoiceDate = sSub.Substring(0,10),
                    iInvoiceCost = (int)ds.Tables[0].Rows[i]["TotalCost"]
                });
            }

            return lstInvoiceByCost;
        }
    }
}
