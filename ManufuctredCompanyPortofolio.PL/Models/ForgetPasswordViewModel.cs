using ManufuctredCompanyPortofolio.DAL.Resources;
using System.ComponentModel.DataAnnotations;

namespace ManufuctredCompanyPortofolio.PL.Models
{
	public class ForgetPasswordViewModel
	{
		[Required(ErrorMessageResourceName = "lbl_RequiredEmail", ErrorMessageResourceType = typeof(Resource))]
		[EmailAddress(ErrorMessageResourceName = "lbl_InvalidMail", ErrorMessageResourceType = typeof(Resource))]
		public string Email { get; set; }
	}
}
