using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WindowsFormsAppMVP.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        [DisplayName("Nombre Del Cliente")]
        [Required(ErrorMessage ="Escriba el nombre del cliente")]
        public string CustName { get; set; }
        [DisplayName("Direccion Del Cliente")]
        public string Adress { get; set; }
        public string Status { get; set; }
        public string CustomerType { get; set; }
    }
}
