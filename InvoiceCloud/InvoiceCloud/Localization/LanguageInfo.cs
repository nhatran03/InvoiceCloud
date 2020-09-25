using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Localization
{
	public class LanguageInfo
	{
		public string Name { get; set;}

		public string DisplayName { get; set; }
		public string Icon { get; set; }
		public bool IsDefault { get; set; }

		public LanguageInfo(string name, string displayName, string icon=null, bool isDefault=false)
		{
			Name = name;
			DisplayName = displayName;
			Icon = icon;
			IsDefault = isDefault;
		}
	}
}
