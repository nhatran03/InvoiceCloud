using InvoiceCloud.Localization.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceCloud.Localization
{
	public class NullLocaizationManager: ILocalizationManager
	{
		public static NullLocaizationManager Instance => SingletonInstance;
		private static readonly NullLocaizationManager SingletonInstance = new NullLocaizationManager();
		public LanguageInfo CurrentLanguage => new LanguageInfo(Thread.CurrentThread.CurrentUICulture.Name, Thread.CurrentThread.CurrentUICulture.DisplayName);
		private readonly IReadOnlyList<LanguageInfo> emptyLanguageArray = new LanguageInfo[0];
		private readonly IReadOnlyList<ILocalizationSource> emptyLocalizationSourceArray = new ILocalizationSource[0];

		private NullLocaizationManager()
		{

		}

		public IReadOnlyList<LanguageInfo> GetAllLanguages()
		{
			return emptyLanguageArray;
		}

		public ILocalizationSource GetSource(string name)
		{
			return NullLocaizationSource.Instance;
		}

		public IReadOnlyList<ILocalizationSource> GetAllSources()
		{
			return emptyLocalizationSourceArray;
		}
	}
}
