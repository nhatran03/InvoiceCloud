using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Runtime.Caching
{
	public static class TypedCacheExtensions
	{
		public static TValue Get<TKey, TValue>(this ITypeCache<TKey, TValue> cache, TKey key, Func<TValue> factory)
		{
			return cache.Get(key, k => factory());
		}

		public static Task<TValue> GetAsync<TKey, TValue>(this ITypeCache<TKey,TValue> cache, TKey key, Func<Task<TValue>> factory)
		{
			return cache.GetAsync(key, k => factory());
		}
	}
}
