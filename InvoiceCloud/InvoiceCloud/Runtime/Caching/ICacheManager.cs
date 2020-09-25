using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Runtime.Caching
{
	public interface ICacheManager: IDisposable
	{
		IReadOnlyList<ICache> GetAllCaches();

		ICache GetCache(string name);
	}
}
