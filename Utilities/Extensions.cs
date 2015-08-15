using System;
using System.ComponentModel;
using System.Text;

namespace Utilities
{
	public static class Extensions
	{
		public static void Dump(this object obj)
		{
			foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
			{
				var name = descriptor.Name;

				object value;

				try
				{
					value = descriptor.GetValue(obj);

				}
				catch (Exception exception)
				{
					value = exception.GetType();
				}
				Console.WriteLine($"{name}={value}");
			}

		}

		public static string UnderlineWith(this string str, char underlineChar)
		{
			var retVal = new StringBuilder();
			retVal.Append(str);
			retVal.Append(Environment.NewLine);
			retVal.Append(new string(underlineChar, str.Length));

			return retVal.ToString();
		}
	}
}
