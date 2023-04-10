using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppMVP.Interfaces;

namespace WindowsFormsAppMVP.Views
{
    public interface ICustomerTypeView : IGenericView
    {
        //Properties - Fields
        string Id { get; set; }
        string Description { get; set; }
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
    }
}
