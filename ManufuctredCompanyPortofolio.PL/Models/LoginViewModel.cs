using ManufuctredCompanyPortofolio.DAL.Resources;
using System.ComponentModel.DataAnnotations;

namespace ManufuctredCompanyPortofolio.PL.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessageResourceName = "lbl_RequiredEmail", ErrorMessageResourceType = typeof(Resource))]
		[EmailAddress(ErrorMessageResourceName = "lbl_InvalidMail", ErrorMessageResourceType = typeof(Resource))]
		public string Email { get; set; }
		[Required(ErrorMessageResourceName = "lbl_RequiredPassword", ErrorMessageResourceType = typeof(Resource))]
		[MinLength(5, ErrorMessageResourceName = "lbl_MinLengthMustBeFive", ErrorMessageResourceType = typeof(Resource))]
		public string Password { get; set; }				
		public bool RememberMe { get; set; }

	}
}
