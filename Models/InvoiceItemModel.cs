using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppMVP.Models
{
    public class InvoiceItemModel
    {
        public int Id { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string TotalItbis { get; set; }
        public string SubTotal { get; set; }
        public string Total { get; set; }
    }
}
