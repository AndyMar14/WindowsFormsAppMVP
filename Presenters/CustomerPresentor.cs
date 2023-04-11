using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppMVP.Models;
using WindowsFormsAppMVP.Views;
using System.Data;
using WindowsFormsAppMVP.Dtos;

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
            this.view.ViewLoad += ViewLoadAction;
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
            var customers = repository.GetAll();
            List<CustomerListResponse> customersList = customers.Select(x => new CustomerListResponse() { Id = x.Id, CustName = x.CustName, Adress = x.Adress,CustomerType = x.CustomerType,Status = x.Status }).ToList();
            customersBindingSource.DataSource = customersList;//Set data source.
        }
        private void SearchCustomer(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                customerList = repository.GetByValue(this.view.SearchValue);
            else customerList = repository.GetAll();

            List<CustomerListResponse> customersList = customerList.Select(x => new CustomerListResponse() { Id = x.Id, CustName = x.CustName, Adress = x.Adress, CustomerType = x.CustomerType, Status = x.Status }).ToList();
            customersBindingSource.DataSource = customersList;
        }
        private void CleanviewFields()
        {
            view.Id = "0";
            view.CustName = "";
            view.Adress = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();  
        }
        private void ViewLoadAction(object sender, EventArgs e)
        {
            var customerTypeList = repository.GetAllTypes();
            view.CustomerTypeList = customerTypeList;
        }
        private void SaveCustomer(object sender, EventArgs e)
        {
            var model = new CustomerModel();
            model.Id = Convert.ToInt32(view.Id);
            model.CustName = view.CustName;
            model.Adress = view.Adress;
            model.CustomerType = view.CustomerTypeId.ToString();
            if (view.Status == 1)
            {
                model.Status = "0";
            }
            else
            {
                model.Status = "1";
            }
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "Customer edited successfuly";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "Customer added sucessfully";
                }
                view.IsSuccessful = true;
                LoadAllCustomerList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void DeleteSelectedCustomer(object sender, EventArgs e)
        {
            try
        {
            var customer = (CustomerListResponse)customersBindingSource.Current;
            repository.Delete(customer.Id);
            view.IsSuccessful = true;
            view.Message = "Customer deleted successfully";
            LoadAllCustomerList();
        }
        catch (Exception ex)
        {
            view.IsSuccessful = false;
            view.Message = "An error ocurred, could not delete customer";
        }
        }
        private void LoadSelectedCustomerToEdit(object sender, EventArgs e)
        {
            var customerSelected = (CustomerListResponse)customersBindingSource.Current;
            var customerData = repository.GetByValue(customerSelected.Id.ToString());
            view.Id = customerData.First().Id.ToString();
            view.CustName = customerData.First().CustName;
            view.Adress = customerData.First().Adress;
            view.CustomerTypeId = Int32.Parse(customerData.First().CustomerTypeId);
            if (customerData.First().Status == "Activo")
            {
                view.Status = 0;
            }
            else
            {
                view.Status = 1;
            }
            view.IsEdit = true;
        }
        private void AddNewCustomer(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }
    }
}
