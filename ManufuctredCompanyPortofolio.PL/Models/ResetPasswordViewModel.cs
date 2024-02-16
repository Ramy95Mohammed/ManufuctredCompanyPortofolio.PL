using ManufuctredCompanyPortofolio.DAL.Resources;
using System.ComponentModel.DataAnnotations;

namespace ManufuctredCompanyPortofolio.PL.Models
{
	public class ResetPasswordViewModel
	{
		public string Email { get; set; }
		public string Token { get; set; }
		[Required(ErrorMessageResourceName = "lbl_RequiredPassword", ErrorMessageResourceType = typeof(Resource))]
		[MinLength(5, ErrorMessageResourceName = "lbl_MinLengthMustBeFive", ErrorMessageResourceType = typeof(Resource))]
		public string NewPassword { get; set; }
		[Required(ErrorMessageResourceName = "lbl_RequiredPassword", ErrorMessageResourceType = typeof(Resource))]
		[Compare("NewPassword", ErrorMessageResourceName = "lbl_PasswordDontMatch", ErrorMessageResourceType = typeof(Resource))]
		public string ConfirmPassword { get; set; }
	}
}
