using ManufuctredCompanyPortofolio.DAL.Entities.Account;
using System.Net;
using System.Net.Mail;

namespace ManufuctredCompanyPortofolio.PL.Helper
{
	public class EmailSettings
	{
		public static void SendEmail(Email email)
		{
			var Client = new SmtpClient("smtp-mail.outlook.com", 587);//port
			Client.EnableSsl = true;//Email sended should be encrypted
			Client.Credentials = new NetworkCredential("rami95mohammed@outlook.com", "Romiormasy0102457966");
			Client.Send("rami95mohammed@outlook.com", email.To, email.Title, email.Body);

		}
	}
}
