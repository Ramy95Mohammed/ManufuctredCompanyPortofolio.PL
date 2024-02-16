using ManufuctredCompanyPortofolio.DAL.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManufuctredCompanyPortofolio.DAL.Entities
{
	public class CompanyBranchesResponsiblePerson 
	{
		[Key]
		public int KeyID { get; set; }
		[Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
		[RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
		public string PersonArName { get; set; }
		[Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
		[RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
		public string PersonEnName { get; set; }
		[Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
		[DataType(DataType.PhoneNumber, ErrorMessageResourceName = "lbl_ThisIsMustBeumber", ErrorMessageResourceType = typeof(Resource))]
		[RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
		public string Mobile { get; set; }
		[Required(ErrorMessageResourceName = "lbl_RequiredMessage", ErrorMessageResourceType = typeof(Resource), AllowEmptyStrings = false)]
		[DataType(DataType.EmailAddress, ErrorMessageResourceName = "lbl_ThisIsMustBeumber", ErrorMessageResourceType = typeof(Resource))]
		[RegularExpression(pattern: @"^(?!\s*$).+", ErrorMessageResourceName = "lbl_EmptyString", ErrorMessageResourceType = typeof(Resource))]
		public string Email { get; set; }
		[ForeignKey("ManufcturingCompany")]
		public int ManufcturingCompanyId { get; set; }
		public virtual ManufcturingCompany ManufcturingCompany{get; set;}

		[ForeignKey("ManuductringCompanyBranch")]
		public int ManuductringCompanyBranchId { get; set; }
		public virtual ManuductringCompanyBranch ManuductringCompanyBranch { get; set; }
		[NotMapped]
		public bool IsCompanyBranchesResponsiblePersonDeleted { get; set; }

    }
}
