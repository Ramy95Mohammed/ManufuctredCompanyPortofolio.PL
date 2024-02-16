using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManufuctredCompanyPortofolio.DAL.Resources;



namespace ManufuctredCompanyPortofolio.DAL.Entities
{
    public class ManufcturingCompany
    {
        [Key]
        public int KeyID { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource),AllowEmptyStrings =false)]
        [StringLength(maximumLength: 30, MinimumLength = 3, ErrorMessageResourceName = "lbl_CodeMustBeBetwwen30And3", ErrorMessageResourceType = typeof(Resource))]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string Code { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string ArName { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string EnName { get; set; }
        public string? Details { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public string CurrentAddress { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
        [RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
        public int CountryId { get; set; }

        public List<ManuductringCompanyBranch> ManuductringCompanyBranches { get; set; } = new List<ManuductringCompanyBranch>();

        public List<ManufcturingCompanyPhone> ManufcturingCompanyPhones { get; set; } = new List<ManufcturingCompanyPhone>();
    }
}
