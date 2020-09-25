using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Localization.Source
{
	public static class LocalizationSourceExtensions
	{
		public static string GetString(this ILocalizationSource source, string name, object[] args)
		{
			if(source == null)
			{
				throw new ArgumentNullException("source");
			}

			return string.Format(source.GetString(name), args);
		}

		public static string GetString(this ILocalizationSource source, string name, CultureInfo cultureInfo, object[] args)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}

			return string.Format(source.GetString(name,cultureInfo), args);
		}
	}
}
