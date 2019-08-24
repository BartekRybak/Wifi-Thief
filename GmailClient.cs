using System;
using System.Net.Mail;
using System.Net;

namespace ShadePT
{
	public class GmailClient
	{
		NetworkCredential LoginCredential;
		SmtpClient Client;

		int gmail_port = 587;
		string gmail_host = "smtp.gmail.com";

		public GmailClient(string login, string password)
		{
			LoginCredential = new NetworkCredential(login, password);
		}

		public void Send(MailMessage mail)
		{
			Client = new SmtpClient
			{
				Host = gmail_host,
				Port = gmail_port,
				UseDefaultCredentials = false,
				Credentials = LoginCredential,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network
			};

		//	try
			//{
				Client.Send(mail);
			//}
		//	catch (Exception e)
		//	{
				//Console.WriteLine(e.Message);
		//	}
		}
	}
}