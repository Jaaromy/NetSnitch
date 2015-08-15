using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using PerformanceModule;
using Utilities;

namespace ConsoleClient
{
	class Program
	{
		static void Main(string[] args)
		{
			//var currentProcess = Process.GetCurrentProcess();

			//currentProcess.Dump();

			Performance.Start();

			//ShowAllProcesses();


		}

		private static void ShowAllProcesses()
		{
			var allProcesses = Process.GetProcesses().OrderBy(p => p.ProcessName).ToList();

			var maxNameLength = allProcesses.OrderByDescending(ap => ap.ProcessName.Length).Select(ap => ap.ProcessName.Length).First();

			var header = $"Number  {"Name".PadRight(maxNameLength)} {"ID",-5} {"Memory",-6}";

			Console.WriteLine(header.UnderlineWith('='));


			for (var i = 0; i < allProcesses.Count; i++)
			{
				var name = allProcesses[i].ProcessName.PadRight(maxNameLength);

				Console.WriteLine($"{i + 1,-7} {name} {allProcesses[i].Id,-5} {allProcesses[i].NonpagedSystemMemorySize64,-6}");
			}
		}
	}
}
