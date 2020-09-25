using InvoiceCloud.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Caching
{
	public interface IEntityCache<TCacheItem> : IEntityCache<TCacheItem, int>
	{

	}

	public interface IEntityCache<TCacheItem, TPrimaryKey>
	{
		TCacheItem this[TPrimaryKey id] { get; }

		string CacheName { get; }

		ITypeCache<TPrimaryKey, TCacheItem> InternalCache { get; }

		TCacheItem Get(TPrimaryKey id);
		Task<TCacheItem> GetAsync(TPrimaryKey id);
	}
}
