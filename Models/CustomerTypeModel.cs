using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppMVP.Models
{
    public class CustomerTypeModel
    {
        public int Id { get; set; }
        [DisplayName("Descripcion del tipo")]
        [Required(ErrorMessage = "Escriba la descripcion del tipo")]
        public string Description { get; set; }
    }
}
