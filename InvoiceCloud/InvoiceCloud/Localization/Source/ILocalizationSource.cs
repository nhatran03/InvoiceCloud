using InvoiceCloud.Configuration.Startup;
using InvoiceCloud.Dependency;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Localization.Source
{
	public interface ILocalizationSource
	{
		string Name { get; }
		void Initialize(ILocalizationConfiguration configuration, IIocResolver iiocResolver);
		string GetString(string name);
		string GetString(string name,CultureInfo cultureInfo);
		string GetStringOrNull(string name, bool tryDefaults = true);
		string GetStringOrNull(string name, CultureInfo cultureInfo, bool tryDefaults = true);
		IReadOnlyList<LocalizedString> GetAllStrings(bool includeDefaults = true);
		IReadOnlyList<LocalizedString> GetAllStrings(CultureInfo cultureInfo, bool includeDefaults = true);
	}
}
