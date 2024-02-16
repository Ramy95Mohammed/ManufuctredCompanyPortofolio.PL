using ManufuctredCompanyPortofolio.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Text;


namespace ManufuctredCompanyPortofolio.PL.Controllers
{
//	[Authorize]
	public class MyController : Controller
    {
        private readonly IProgramLanguage language;
        public MyController()
        {

        }
        public MyController(IProgramLanguage language)
        {
            this.language = language;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            if (context.HttpContext.Request.Cookies["lang"] == null)
            {
                language.SetLanguageCulture("ar-EG");               
            }
            else
            language.SetLanguageCulture(context.HttpContext.Request.Cookies["lang"]);
            
            base.OnActionExecuting(context);
        }
    }
}
