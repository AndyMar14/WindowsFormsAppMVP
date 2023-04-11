using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppMVP.Models
{
    public class InvoiceDetailModel
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
        public string CustomerType { get; set; }

        public string TotalItbis { get; set; }
        public string SubTotal { get; set; }
        public string Total { get; set; }

    }
}
