using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppMVP.Models;
using WindowsFormsAppMVP.Views;

namespace WindowsFormsAppMVP.Presenters
{
    public class InvoicePresentor
    {
        //Fields
        private IInvoiceView view;
        private IInvoiceRepository repository;
        private BindingSource invoicesBindingSource;
        private BindingSource invoiceDetailBindingSource;
        private IEnumerable<InvoiceModel> invoiceList;
        // private IEnumerable<InvoiceDetailModel> invoiceDetailList;

        //Constructor
        public InvoicePresentor(IInvoiceView view, IInvoiceRepository repository)
        {
            this.invoicesBindingSource = new BindingSource();
            this.invoiceDetailBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchInvoice;
            this.view.ViewInvoice += LoadSelectedInvoice;
            //Set invoices bindind source
            this.view.SetInvoiceListBindingSource(invoicesBindingSource);
            this.view.SetInvoiceDetailListBindingSource(invoiceDetailBindingSource);
            //Load invoice list view
            LoadAllInvoiceList();
            //Show view
            this.view.Show();
        }
        //Methods
        private void LoadAllInvoiceList()
        {
            var invoices = repository.GetAll();
            invoicesBindingSource.DataSource = invoices;//Set data source.
        }
        private void SearchInvoice(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                invoiceList = repository.GetByValue(this.view.SearchValue);
            else invoiceList = repository.GetAll();

            invoicesBindingSource.DataSource = invoiceList;
        }
  
        private void LoadSelectedInvoice(object sender, EventArgs e)
        {
            var invoiceSelected = (InvoiceModel)invoicesBindingSource.Current;
            var invoiceData = repository.GetInvoiceDetail(invoiceSelected.Id.ToString());
            var invoiceItemsData = repository.GetInvoiceItems(invoiceSelected.Id.ToString());
            view.Id = invoiceData.First().Id.ToString();
            view.CustName = invoiceData.First().CustName;
            view.Adress = invoiceData.First().Adress;
            if (invoiceData.First().Status == "True")
            {
                view.Status = "Activo";
            }
            else
            {
                view.Status = "Inactivo";
            }
            view.CustomerType = invoiceData.First().CustomerType;

            view.Total = invoiceData.First().Total;
            view.SubTotal = invoiceData.First().SubTotal;
            view.Itbis = invoiceData.First().TotalItbis;
            invoiceDetailBindingSource.DataSource = invoiceItemsData;

        }
    }
}
