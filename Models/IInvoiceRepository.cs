using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppMVP.Models
{
    public interface IInvoiceRepository
    {
        IEnumerable<InvoiceModel> GetAll();
        IEnumerable<InvoiceModel> GetByValue(string searchValue);
         IEnumerable<InvoiceDetailModel> GetInvoiceDetail(string searchValue);
         IEnumerable<InvoiceItemModel> GetInvoiceItems(string searchValue);
    }
}
