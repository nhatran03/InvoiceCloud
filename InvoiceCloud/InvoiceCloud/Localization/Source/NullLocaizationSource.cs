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
	internal class NullLocaizationSource : ILocalizationSource
	{
		public static NullLocaizationSource Instance = SingletonInstance;
		private static readonly NullLocaizationSource SingletonInstance = new NullLocaizationSource();
		public string Name => null;
		private readonly IReadOnlyList<LocalizedString> emptyStringArray = new LocalizedString[0];

		private NullLocaizationSource()
		{

		}
		public IReadOnlyList<LocalizedString> GetAllStrings(bool includeDefaults = true)
		{
			return emptyStringArray;
		}

		public IReadOnlyList<LocalizedString> GetAllStrings(CultureInfo cultureInfo, bool includeDefaults = true)
		{
			return emptyStringArray;
		}

		public string GetString(string name)
		{
			return name;
		}

		public string GetString(string name, CultureInfo cultureInfo)
		{
			return name;
		}

		public string GetStringOrNull(string name, bool tryDefaults = true)
		{
			return null;
		}

		public string GetStringOrNull(string name, CultureInfo cultureInfo, bool tryDefaults = true)
		{
			return null;
		}

		public void Initialize(ILocalizationConfiguration configuration, IIocResolver iiocResolver)
		{
			
		}
	}
}
