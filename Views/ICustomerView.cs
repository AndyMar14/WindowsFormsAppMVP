using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppMVP.Views
{
    public interface ICustomerView
    {
        //Properties - Fields
        string Id { get; set; }
        string CustName { get; set; }
        string Adress { get; set; }
        int CustomerTypeId { get; set; }
        int Status { get; set; }
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        //Methods
        void SetCustomerListBindingSource(BindingSource petList);
        void Show();
    }
}
