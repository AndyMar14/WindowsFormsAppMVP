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
    public class CustomerTypePresentor
    {
        //Fields
        private ICustomerTypeView view;
        private ICustomerTypeRepository repository;
        private BindingSource customersBindingSource;
        private IEnumerable<CustomerTypeModel> customerList;

        //Constructor
        public CustomerTypePresentor(ICustomerTypeView view, ICustomerTypeRepository repository)
        {
            this.customersBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchCustomerType;
            this.view.AddNewEvent += AddNewCustomerType;
            this.view.EditEvent += LoadSelectedCustomerTypeToEdit;
            this.view.DeleteEvent += DeleteSelectedCustomerType;
            this.view.SaveEvent += SaveCustomerType;
            this.view.CancelEvent += CancelAction;
            //Set customers bindind source
            this.view.SetCustomerListBindingSource(customersBindingSource);
            //Load customer list view
            LoadAllCustomerTypeList();
            //Show view
            this.view.Show();
        }
        //Methods
        private void LoadAllCustomerTypeList()
        {
            var customersList = repository.GetAll();
            customersBindingSource.DataSource = customersList;//Set data source.
        }
        private void SearchCustomerType(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                customerList = repository.GetByValue(this.view.SearchValue);
            else customerList = repository.GetAll();

            customersBindingSource.DataSource = customerList;
        }
        private void CleanviewFields()
        {
            view.Id = "0";
            view.Description = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }
        private void SaveCustomerType(object sender, EventArgs e)
        {
            var model = new CustomerTypeModel();
            model.Id = Convert.ToInt32(view.Id);
            model.Description = view.Description;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "CustomerType edited successfuly";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "CustomerType added sucessfully";
                }
                view.IsSuccessful = true;
                LoadAllCustomerTypeList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }
        private void DeleteSelectedCustomerType(object sender, EventArgs e)
        {
            try
            {
                var customer = (CustomerTypeModel)customersBindingSource.Current;
                repository.Delete(customer.Id);
                view.IsSuccessful = true;
                view.Message = "CustomerType deleted successfully";
                LoadAllCustomerTypeList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not delete customer";
            }
        }
        private void LoadSelectedCustomerTypeToEdit(object sender, EventArgs e)
        {
            var customerTypeSelected = (CustomerTypeModel)customersBindingSource.Current;
            var customerData = repository.GetByValue(customerTypeSelected.Id.ToString());
            view.Id = customerData.First().Id.ToString();
            view.Description = customerData.First().Description;
            view.IsEdit = true;
        }
        private void AddNewCustomerType(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }
    }
}
