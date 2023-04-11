using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppMVP.Views
{
    public interface IInvoiceView
    {
        string Id { get; set; }
        string CustName { get; set; }
        string Adress { get; set; }
        string CustomerType { get; set; }
        string Status { get; set; }
        string SearchValue { get; set; }
        string Total { get; set; }
        string Itbis { get; set; }
        string SubTotal { get; set; }
        string Message { get; set; }

        event EventHandler ViewInvoice;
        event EventHandler SearchEvent;

        //Methods
        void SetInvoiceListBindingSource(BindingSource invoiceList);
        void SetInvoiceDetailListBindingSource(BindingSource invoiceDetailList);
        void Show();
    }
}
