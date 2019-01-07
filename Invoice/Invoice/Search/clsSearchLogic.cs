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
        /**********************************************************Default List Methods********************************************/
        /// <summary>                                                                                                           /**/
        /// Get invoice number                                                                                                  /**/
        /// </summary>                                                                                                          /**/
        /// <returns></returns>                                                                                                 /**/
        public List<clsInvoice> GetInvoiceNum()                                                                                 /**/
        {                                                                                                                       /**/
            lstInvoiceNum = new List<clsInvoice>();                                                                             /**/
                                                                                                                                /**/
            db = new clsDataAccess();                                                                                           /**/
                                                                                                                                /**/
            ds = db.ExecuteSQLStatement(SearchSQL.AllInvoiceNumSQL(), ref iRet);                                                /**/
                                                                                                                                /**/
            for (int i = 0; i < iRet; i++)                                                                                      /**/
            {                                                                                                                   /**/
                lstInvoiceNum.Add(new clsInvoice{iInvoiceNum =  (int)ds.Tables[0].Rows[i]["InvoiceNum"]});                      /**/
            }                                                                                                                   /**/
                                                                                                                                /**/
            return lstInvoiceNum;                                                                                               /**/
        }                                                                                                                       /**/
        /// <summary>                                                                                                           /**/
        /// Get invoice date                                                                                                    /**/
        /// </summary>                                                                                                          /**/
        /// <returns></returns>                                                                                                 /**/
        public List<clsInvoice> GetInvoiceDate()                                                                                /**/
        {                                                                                                                       /**/
            string sSub;                                                                                                        /**/
                                                                                                                                /**/
            lstInvoiceDate = new List<clsInvoice>();                                                                            /**/
                                                                                                                                /**/
            db = new clsDataAccess();                                                                                           /**/
                                                                                                                                /**/
            ds = db.ExecuteSQLStatement(SearchSQL.AllInvoiceDateSQL(), ref iRet);                                               /**/
                                                                                                                                /**/
            for (int i = 0; i < iRet; i++)                                                                                      /**/
            {                                                                                                                   /**/
                sSub = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();                                                          /**/
                                                                                                                                /**/
                lstInvoiceDate.Add(new clsInvoice { sInvoiceDate = sSub.Substring(0,10) });                                     /**/
            }                                                                                                                   /**/
                                                                                                                                /**/
            return lstInvoiceDate;                                                                                              /**/
        }                                                                                                                       /**/
        /// <summary>                                                                                                           /**/
        /// Get invoice cost                                                                                                    /**/
        /// </summary>                                                                                                          /**/
        /// <returns></returns>                                                                                                 /**/
        public List<clsInvoice> GetInvoiceCost()                                                                                /**/
        {                                                                                                                       /**/
            lstInvoiceCost = new List<clsInvoice>();                                                                            /**/
                                                                                                                                /**/
            db = new clsDataAccess();                                                                                           /**/
                                                                                                                                /**/
            ds = db.ExecuteSQLStatement(SearchSQL.AllInvoiceCostSQL(), ref iRet);                                               /**/
                                                                                                                                /**/
            for (int i = 0; i < iRet; i++)                                                                                      /**/
            {                                                                                                                   /**/
                lstInvoiceCost.Add(new clsInvoice { iInvoiceCost = (int)ds.Tables[0].Rows[i]["TotalCost"] });                   /**/
            }                                                                                                                   /**/
                                                                                                                                /**/
            return lstInvoiceCost;                                                                                              /**/
        }                                                                                                                       /**/
        /// <summary>                                                                                                           /**/
        /// Get invoice data                                                                                                    /**/
        /// </summary>                                                                                                          /**/
        /// <returns></returns>                                                                                                 /**/
        public List<clsInvoice> GetInvoice()                                                                                    /**/
        {                                                                                                                       /**/
            string sSub;                                                                                                        /**/
                                                                                                                                /**/
            lstInvoice = new List<clsInvoice>();                                                                                /**/
                                                                                                                                /**/
            db = new clsDataAccess();                                                                                           /**/
                                                                                                                                /**/
            ds = db.ExecuteSQLStatement(SearchSQL.AllInvoiceSQL(), ref iRet);                                                   /**/
                                                                                                                                /**/
            for (int i = 0; i < iRet; i++)                                                                                      /**/
            {                                                                                                                   /**/
                sSub = ds.Tables[0].Rows[i]["InvoiceDate"].ToString();                                                          /**/
                                                                                                                                /**/
                lstInvoice.Add(new clsInvoice { iInvoiceNum = (int)ds.Tables[0].Rows[i]["InvoiceNum"],                          /**/
                    sInvoiceDate = sSub.Substring(0,10),                                                                        /**/
                    iInvoiceCost = (int)ds.Tables[0].Rows[i]["TotalCost"]});                                                    /**/
            }                                                                                                                   /**/
                                                                                                                                /**/
            return lstInvoice;                                                                                                  /**/
        }                                                                                                                       /**/
        /**************************************************************************************************************************/
        /// <summary>
        /// Get invoice data by invoice num
        /// </summary>
        /// <returns></returns>
        public List<clsInvoice> GetInvoiceByNum(int iNum)
        {
            lstInvoiceByNum = new List<clsInvoice>();

            db = new clsDataAccess();

            ds = db.ExecuteSQLStatement(SearchSQL.GetInvoiceByNum(iNum), ref iRet);

            for (int i = 0; i < iRet; i++)
            {
                lstInvoiceByNum.Add(new clsInvoice
                {
                    iInvoiceNum = (int)ds.Tables[0].Rows[i]["InvoiceNum"],
                    sInvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
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
            lstInvoiceByDate = new List<clsInvoice>();

            db = new clsDataAccess();

            ds = db.ExecuteSQLStatement(SearchSQL.GetInvoiceByDate(sDate), ref iRet);

            for (int i = 0; i < iRet; i++)
            {
                lstInvoiceByDate.Add(new clsInvoice
                {
                    iInvoiceNum = (int)ds.Tables[0].Rows[i]["InvoiceNum"],
                    sInvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
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
            lstInvoiceByCost = new List<clsInvoice>();

            db = new clsDataAccess();

            ds = db.ExecuteSQLStatement(SearchSQL.GetInvoiceByCost(iCost), ref iRet);

            for (int i = 0; i < iRet; i++)
            {
                lstInvoiceByCost.Add(new clsInvoice
                {
                    iInvoiceNum = (int)ds.Tables[0].Rows[i]["InvoiceNum"],
                    sInvoiceDate = ds.Tables[0].Rows[i]["InvoiceDate"].ToString(),
                    iInvoiceCost = (int)ds.Tables[0].Rows[i]["TotalCost"]
                });
            }

            return lstInvoiceByCost;
        }
    }
}
