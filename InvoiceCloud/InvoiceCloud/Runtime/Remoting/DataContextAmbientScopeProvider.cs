using Castle.Core.Logging;
using InvoiceCloud.Collections.Extensions;
using JetBrains.Annotations;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Runtime.Remoting
{
	public class DataContextAmbientScopeProvider<T> : IAmbientScopeProvider<T>
	{

		public ILogger Logger { get; set; }

		private static readonly ConcurrentDictionary<string, ScopeItem> ScopeDictionary = new ConcurrentDictionary<string, ScopeItem>();

		private readonly IAmbientDataContext dataContext;

		public DataContextAmbientScopeProvider([NotNull] IAmbientDataContext dataContext)
		{
			Check.NotNull(dataContext, nameof(dataContext));
			this.dataContext = dataContext;

			Logger = NullLogger.Instance;
		}
		public IDisposable BeginScope(string contextKey, T value)
		{
			var item = new ScopeItem(value, GetCurrentItem(contextKey));

			if (!ScopeDictionary.TryAdd(item.Id, item))
			{
				throw new InvoiceCloudException("Can not set unit of work! ScopeDictionary.TryAdd returns false!");
			}

			dataContext.SetData(contextKey, item.Id);

			return new DisposeAction(() =>
			{
				ScopeDictionary.TryRemove(item.Id, out item);

				if (item.Outer == null)
				{
					dataContext.SetData(contextKey, null);
					return;
				}

				dataContext.SetData(contextKey, item.Outer.Id);
			});
		}

		public T GetValue(string contextKey)
		{
			var item = GetCurrentItem(contextKey);
			if(item == null)
			{
				return default(T);
			}

			return item.Value;
		}

		private ScopeItem GetCurrentItem(string contextKey)
		{
			var objKey = dataContext.GetData(contextKey) as string;
			return objKey != null ? ScopeDictionary.GetOrDefault(objKey) : null;
		}

		private class ScopeItem
		{
			public string Id { get; }
			public ScopeItem Outer { get; }
			public T Value { get; }
			public ScopeItem(T value, ScopeItem outer = null)
			{
				Id = Guid.NewGuid().ToString();

				Value = value;
				Outer = outer;
			}
		}
	}	
}
