using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Search
{
    /// <summary>
    /// Invoice class
    /// </summary>
    public class clsInvoice
    {
        /// <summary>
        /// getter and setter of the iInvoiceNum
        /// </summary>
        public int iInvoiceNum { get; set; }
        /// <summary>
        /// getter and setter of the sInvoiceDate
        /// </summary>
        public string sInvoiceDate { get; set; }
        /// <summary>
        /// getter and setter of the sInvoiceCost
        /// </summary>
        public int iInvoiceCost { get; set; }
    }
}
