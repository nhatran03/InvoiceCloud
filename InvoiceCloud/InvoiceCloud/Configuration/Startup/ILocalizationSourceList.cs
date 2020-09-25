using InvoiceCloud.Localization.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Configuration.Startup
{
	public interface ILocalizationSourceList: IList<ILocalizationSource>
	{
		IList<LocalizationSourceExtensionsInfo> Extensions { get; }
	}
}
