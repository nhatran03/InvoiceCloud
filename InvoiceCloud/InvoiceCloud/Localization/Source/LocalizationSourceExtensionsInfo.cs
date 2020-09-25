using InvoiceCloud.Localization.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Localization.Source
{
	public class LocalizationSourceExtensionsInfo
	{
		public string SourceName { get; set; }

		public ILocalizationDictionaryProvider DictionaryProvider { get; private set; }

		public LocalizationSourceExtensionsInfo(string sourceName, ILocalizationDictionaryProvider dictionaryProvider)
		{
			SourceName = SourceName;
			DictionaryProvider = dictionaryProvider;
		}
	}
}
