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

namespace Invoice.Main
{


    /// <summary>
    /// 
    /// </summary>
    public class clsMainLogic
    {
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

        /// <summary>
        /// 
        /// </summary>
        clsMainSQL MainSQL;

        /// <summary>
        /// 
        /// </summary>
        public clsMainLogic()
        {

            MainSQL = new clsMainSQL();

            ds = new DataSet();

            db = new clsDataAccess();

            iRet = 0;

        }

        //UdateInvoice()
        //DeleteInvoice()
        //NewInvoice()

        public int NewInvoice(string sDate, int iCost)
        {
            
            return db.ExecuteNonQuery(MainSQL.NewInvoice(sDate,iCost));
            
        }

        //SaveItem()
        //DeleteItem()
        //GetItem()
    }
}
