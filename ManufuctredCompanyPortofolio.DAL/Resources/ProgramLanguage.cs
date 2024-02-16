using System.Diagnostics;
using System.Globalization;

namespace ManufuctredCompanyPortofolio.DAL
{
    public class ProgramLanguage : IProgramLanguage
    {
        public static string Language = "";
        public static string Arabic { get; set; } = "ar-EG";
        public static string English { get; set; } = "en-US";

        public ProgramLanguage(string strLang = "")
        {
            Language = strLang;
            string strLangFormat = "";

            if (Language == Arabic)
            {
                strLangFormat = "ar-EG";
            }
            else if (Language == English)
            {
                strLangFormat = "en-US";
            }             
        }

        public void SetLanguageCulture(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
            Language = culture;
        }
    }
}
