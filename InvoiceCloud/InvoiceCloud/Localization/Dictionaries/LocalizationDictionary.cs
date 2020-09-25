using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Localization.Dictionaries
{
	public class LocalizationDictionary : ILocalizationDictionary, IEnumerable<LocalizedString>
	{
		public string this[string name] { 
			get {
				var localizedString = GetOrNull(name);
				return localizedString?.Value;
			}
			set {
				dictionary[name] = new LocalizedString(name, value,cultureInfo);
			}
		}

		private readonly Dictionary<string, LocalizedString> dictionary;

		public LocalizationDictionary(CultureInfo cultureInfo)
		{
			this.cultureInfo = cultureInfo;
		}

		public CultureInfo cultureInfo { get; set; }

		public virtual IReadOnlyList<LocalizedString> GetAllStrings()
		{
			return dictionary.Values.ToImmutableList();
		}

		public virtual IEnumerator<LocalizedString> GetEnumerator()
		{
			return GetAllStrings().GetEnumerator();
		}

		public virtual LocalizedString GetOrNull(string name)
		{
			LocalizedString localizedString;
			return dictionary.TryGetValue(name, out localizedString) ? localizedString : null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		protected bool Contains(string name)
		{
			return dictionary.ContainsKey(name);
		}
	}
}
