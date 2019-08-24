using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;

namespace ShadePT
{
	public class Netsh
	{
		private Process Netsh_Process;

		public Netsh()
		{
			Netsh_Process = new Process()
			{
				StartInfo = new ProcessStartInfo()
				{
					WorkingDirectory = @"C:\Windows\System32",
					FileName = "netsh.exe",
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardInput = false,
					RedirectStandardOutput = true
				}
			};
		}

		public string Run(string command)
		{
			Netsh_Process.StartInfo.Arguments = command;
			Netsh_Process.Start();
			Netsh_Process.WaitForExit();
			return Netsh_Process.StandardOutput.ReadToEnd();
		}

		public string[] GetProfilesNames()
		{
			List<string> done_splited = new List<string>();

			string response = Run("wlan show profile");
			string[] f_splited = response.Split(new string[] { "-------------" }, StringSplitOptions.RemoveEmptyEntries);
			string[] n_splited = f_splited[f_splited.Length - 1].Replace(" ", string.Empty).Split(':');

			foreach (string s in n_splited)
			{
				done_splited.Add(s.Replace("AllUserProfile", string.Empty).Trim());
			}

			return done_splited.ToArray();
		}

		public void ExportProfile(string name, string location)
		{
			string command = "wlan export profile " + name;
			command += " key=clear ";
			command += " folder=" + location;


			Console.WriteLine(command);

			string res = Run(command);
			Console.Write(res);
		}
	}
}
