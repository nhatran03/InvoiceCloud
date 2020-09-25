using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Localization
{
	public class LocalizedString
	{
		public CultureInfo CultureInfo { get; set; }
		public string Name { get; private set; }
		public string Value { get; private set; }
		public LocalizedString(string name, string value,CultureInfo cultureInfo)
		{
			Name = name;
			Value = value;
			CultureInfo = cultureInfo;
		}
	}
}
