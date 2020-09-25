using InvoiceCloud.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Configuration.Startup
{
	public interface ILocalizationConfiguration
	{
		IList<LanguageInfo> Languages { get; }

		ILocalizationSourceList Sources { get; }

		bool IsEnable { get; set; }
		bool ReturnGivenTextIfNotFound { get; set; }

		bool WrapGivenTextIfNotFound { get; set; }
		bool HumanizeTextIfNotFound { get; set; }
	}
}
