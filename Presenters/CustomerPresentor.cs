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
    public class CustomerPresentor
    {
        //Fields
        private ICustomerView view;
        private ICustomerRepository repository;
        private BindingSource customersBindingSource;
        private IEnumerable<CustomerModel> customerList;
        //Constructor
        public CustomerPresentor(ICustomerView view, ICustomerRepository repository)
        {
            this.customersBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchCustomer;
            this.view.AddNewEvent += AddNewCustomer;
            this.view.EditEvent += LoadSelectedCustomerToEdit;
            this.view.DeleteEvent += DeleteSelectedCustomer;
            this.view.SaveEvent += SaveCustomer;
            this.view.CancelEvent += CancelAction;
            //Set customers bindind source
            this.view.SetCustomerListBindingSource(customersBindingSource);
            //Load customer list view
            LoadAllCustomerList();
            //Show view
            this.view.Show();
        }
        //Methods
        private void LoadAllCustomerList()
        {
            customerList = repository.GetAll();
            customersBindingSource.DataSource = customerList;//Set data source.
        }
        private void SearchCustomer(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                customerList = repository.GetByValue(this.view.SearchValue);
            else customerList = repository.GetAll();
            customersBindingSource.DataSource = customerList;
        }
        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void SaveCustomer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void DeleteSelectedCustomer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void LoadSelectedCustomerToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddNewCustomer(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
