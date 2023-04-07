﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsAppMVP._Repositories;
using WindowsFormsAppMVP.Models;
using WindowsFormsAppMVP.Presenters;
using WindowsFormsAppMVP.Views;

namespace WindowsFormsAppMVP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sqlConnectionString = "";
            ICustomerView view = new CustomerView();
            ICustomerRepository repository = new CustomerRepository(sqlConnectionString);
            new CustomerPresentor(view, repository);
            Application.Run((Form)view);
        }
    }
}