using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufuctredCompanyPortofolio.DAL.Resources;


namespace ManufuctredCompanyPortofolio.DAL.Entities
{
    public class ManufcturingCompanyPhone
    {
        [Key]
        public int KeyID { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "lbl_ThisIsMustBeumber", ErrorMessageResourceType = typeof(Resource))]
        public string? GroundTel { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]        
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "lbl_ThisIsMustBeumber", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string Mobile { get; set; } = string.Empty;
        [DataType(DataType.Text, ErrorMessageResourceName = "lbl_ThisIsMustBeumber", ErrorMessageResourceType = typeof(Resource))]
        public string? Fax { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        //[DataType(DataType.EmailAddress,ErrorMessageResourceName = "lbl_ThisIsMustBeumber", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string Email { get; set; } = string.Empty;
        [ForeignKey("ManufcturingCompany")]
        public int? ManufcturingCompanyId { get; set; } = 0;
        public virtual ManufcturingCompany? ManufcturingCompany { get; set; }
        [NotMapped]
        public bool IsCompanyCommuncationDeleted { get; set; } = false;
    }
}
