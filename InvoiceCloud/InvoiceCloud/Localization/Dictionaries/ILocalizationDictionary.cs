using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Localization.Dictionaries
{
	public interface ILocalizationDictionary
	{
		CultureInfo cultureInfo { get; }

		string this[string name] { get;set; }

		LocalizedString GetOrNull(string name);

		IReadOnlyList<LocalizedString> GetAllStrings();
	}
}
