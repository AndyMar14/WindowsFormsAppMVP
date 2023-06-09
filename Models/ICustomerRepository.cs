﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsAppMVP.Interfaces;

namespace WindowsFormsAppMVP.Models
{
    public interface ICustomerRepository : IGenericRepository<CustomerModel>
    {
        IEnumerable<CustomerTypeModel> GetAllTypes();
    }
}
