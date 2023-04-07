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
        }
        private void ShowCustomerView(object sender, EventArgs e)
        {
            ICustomerView view = CustomerView.GetInstace((MainView)mainView);
            ICustomerRepository repository = new CustomerRepository(sqlConnectionString);
            new CustomerPresentor(view, repository);
        }
    }
}
