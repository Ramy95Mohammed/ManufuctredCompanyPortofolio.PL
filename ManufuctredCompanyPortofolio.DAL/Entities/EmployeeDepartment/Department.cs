using ManufuctredCompanyPortofolio.DAL.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufuctredCompanyPortofolio.DAL.Entities
{
    public class Department
    {
        [Key]
        public int KeyID { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
