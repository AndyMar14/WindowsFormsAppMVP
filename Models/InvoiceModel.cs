using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppMVP.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string TotalItbis { get; set; }
        public string SubTotal { get; set; }
        public string Total { get; set; }
    }
}
