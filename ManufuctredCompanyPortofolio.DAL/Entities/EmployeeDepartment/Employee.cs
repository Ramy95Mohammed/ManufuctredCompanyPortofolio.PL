using ManufuctredCompanyPortofolio.DAL.Resources;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ManufuctredCompanyPortofolio.DAL.Entities
{
    public class Employee
    {
        [Key]
        public int KeyID { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string Name { get; set; }
        public string? Address { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string Mobile { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource))]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource))]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
