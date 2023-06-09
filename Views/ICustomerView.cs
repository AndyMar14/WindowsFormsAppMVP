﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppMVP.Interfaces;
using WindowsFormsAppMVP.Models;

namespace WindowsFormsAppMVP.Views
{
    public interface ICustomerView : IGenericView
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
        IEnumerable<CustomerTypeModel> CustomerTypeList { get; set; }

    }
}
