using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Runtime.Caching
{
	public static class CacheManagerExtensions
	{
		public static ITypeCache<TKey, TValue> GetCache<TKey, TValue>(this ICacheManager cacheManager, string name)
		{
			return cacheManager.GetCache(name).AsTyped<TKey, TValue>();
		}
	}
}
