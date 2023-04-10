using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppMVP.Dtos
{
    public class CustomerListResponse
    {
        public int Id { get; set; }
        public string CustName { get; set; }
        public string Adress { get; set; }
        public string Status { get; set; }
        public string CustomerType { get; set; }

    }
}

