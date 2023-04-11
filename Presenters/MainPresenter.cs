using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppMVP._Repositories;
using WindowsFormsAppMVP.Models;
using WindowsFormsAppMVP.Views;

namespace WindowsFormsAppMVP.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;
        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowCustomerView += ShowCustomerView;
            this.mainView.ShowTypeView += ShowTypeView;
            this.mainView.ShowInvoiceView += ShowInvoiceView;
        }
        private void ShowCustomerView(object sender, EventArgs e)
        {
            ICustomerView view = CustomerView.GetInstace((MainView)mainView);
            ICustomerRepository repository = new CustomerRepository(sqlConnectionString);
            new CustomerPresentor(view, repository);
        }
        private void ShowTypeView(object sender, EventArgs e)
        {
            ICustomerTypeView view = CustomerTypeView.GetInstace((MainView)mainView);
            ICustomerTypeRepository repository = new CustomerTypeRepository(sqlConnectionString);
            new CustomerTypePresentor(view, repository);
        }

        private void ShowInvoiceView(object sender, EventArgs e)
        {
            IInvoiceView view = InvoiceView.GetInstace((MainView)mainView);
            IInvoiceRepository repository = new InvoiceRepository(sqlConnectionString);
            new InvoicePresentor(view, repository);
        }
    }
}
