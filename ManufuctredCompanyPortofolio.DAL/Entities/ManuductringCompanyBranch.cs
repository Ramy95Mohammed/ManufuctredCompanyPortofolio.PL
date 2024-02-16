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
    public class ManuductringCompanyBranch
    {
        string str = "";
        [Key]
        public int KeyID { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string ArName { get; set; } = string.Empty;
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string EnName { get; set; } = string.Empty;
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "lbl_ThisIsMustBeumber", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string Mobile { get; set; } = string.Empty;
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "lbl_ThisIsMustBeumber", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string GroundTel { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        [ForeignKey("ManufcturingCompany")]
        public int? ManufcturingCompanyId { get; set; } = 0;
        public virtual ManufcturingCompany? ManufcturingCompany { get; set; }
        [NotMapped]
        public bool IsCompanyBranchDeleted { get; set; } = false;
        public virtual List<CompanyBranchesResponsiblePerson> CompanyBranchesResponsiblePeople { get; set; }
    }
}
