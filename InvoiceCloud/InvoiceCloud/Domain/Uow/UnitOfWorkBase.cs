using Castle.Core;
using InvoiceCloud.Extensions;
using InvoiceCloud.Runtime.Session;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Uow
{
	public abstract class UnitOfWorkBase: IUnitOfWork
	{
		public string Id { get; private set; }
		[DoNotWire]
		public IUnitOfWork Outer { get; set ; }

		public UnitOfWorkOptions Options { get; private set; }

		public IReadOnlyList<DataFilterConfiguration> Filters => filters.ToImmutableList();
		private readonly List<DataFilterConfiguration> filters;

		protected IUnitOfWorkDefaultOptions DefaultOptions { get; }

		protected IConnectionStringResolver ConnectionStringResolver { get; }
		public bool IsDiposed { get; private set; }

		public IInvoiceCloudSession InvoiceCloudSession { protected get; set; }

		protected IUnitOfWorkFilterExecuter FilterExecuter { get; }

		public event EventHandler Completed;
		public event EventHandler<UnitOfWorkFailedEventArgs> Failed;
		public event EventHandler Disposed;

		private bool isBeginCalledBefore;
		public void Begin(UnitOfWorkOptions options)
		{
			if(options == null)
			{
				throw new ArgumentNullException("options");
			}

			PreventMultipleBegin();

			Options = options;
			SetFilters(options.FilterOverrides);
			BeginUow();
		}

		private bool isCompleteCalledBefore;

		public virtual void OnCompleted()
		{
			Completed.InvokeSafely(this);
		}
		public void Complete()
		{
			PreventMultipleComplete();
			try
			{
				CompleteUow();
				succeed = true;
				OnCompleted();
			}
			catch(Exception ex)
			{
				exception = ex;
				throw;
			}
		}

		public async Task CompleteAsync()
		{
			PreventMultipleComplete();
			try
			{
				await CompleteUowAsync();
				succeed = true;
				OnCompleted();
			}
			catch (Exception ex)
			{
				exception = ex;
				throw;
			}
		}

		public IDisposable DisableFilter(params string[] filterNames)
		{
			var disabledFilter = new List<string>();
			foreach(var filterName in filterNames)
			{
				var filterIndex = GetFilterIndex(filterName);
				if (filters[filterIndex].IsEnable)
				{
					disabledFilter.Add(filterName);
					filters[filterIndex] = new DataFilterConfiguration(filters[filterIndex], false);
				}
			}

			disabledFilter.ForEach(ApplyDisableFilter);
			return new DisposeAction(() => EnableFilter(disabledFilter.ToArray()));
		}

		public void Dispose()
		{
			if (IsDiposed)
			{
				return;
			}

			IsDiposed = true;
			if (!succeed)
			{
				OnFailed(exception);
			}

			DisposeUow();
			OnDisposed();
		}

		protected virtual void OnFailed(Exception exception)
		{
			Failed.InvokeSafely(this, new UnitOfWorkFailedEventArgs(exception));
		}

		protected virtual void OnDisposed()
		{
			Disposed.InvokeSafely(this);
		}
		public IDisposable EnableFilter(params string[] filterNames)
		{
			var enableFilters = new List<string>();
			foreach(var filterName in filterNames)
			{
				var filterIndex = GetFilterIndex(filterName);
				if (!filters[filterIndex].IsEnable)
				{
					enableFilters.Add(filterName);
					filters[filterIndex] = new DataFilterConfiguration(filters[filterIndex], true);
				}
			}

			enableFilters.ForEach(ApplyEnableFilter);
			return new DisposeAction(() => DisableFilter(enableFilters.ToArray()));
		}

		public bool IsFilterEnabled(string filterName)
		{
			return GetFilter(filterName).IsEnable;
		}

		public abstract void SaveChange();

		public abstract Task SaveChangeAsync();

		public IDisposable SetFilterParameter(string filterName, string parameterName, object value)
		{
			var filterIndex = GetFilterIndex(filterName);
			var newFilter = new DataFilterConfiguration(filters[filterIndex]);
			object oldValue = null;
			var hasOldValue = newFilter.FilterParameters.ContainsKey(parameterName);

			if (hasOldValue)
			{
				oldValue = newFilter.FilterParameters[parameterName];
			}

			newFilter.FilterParameters[parameterName] = value;
			filters[filterIndex] = newFilter;
			ApplyFilterParameterValue(filterName, parameterName, value);

			return new DisposeAction(() =>
			{
				if (hasOldValue)
				{
					SetFilterParameter(filterName, parameterName, value);
				}
			});
		}

		private bool succeed;
		private Exception exception;

		protected UnitOfWorkBase(
			IConnectionStringResolver connectionStringResolver,
			IUnitOfWorkDefaultOptions defaultOptions,
			IUnitOfWorkFilterExecuter filterExecuter)
		{
			FilterExecuter = filterExecuter;
			DefaultOptions = defaultOptions;
			ConnectionStringResolver = connectionStringResolver;

			Id = Guid.NewGuid().ToString("N");
			filters = defaultOptions.Filters.ToList();

			InvoiceCloudSession = NullInvoiceCloudSession.Instance;
		}

		protected virtual void BeginUow()
		{

		}

		protected abstract void CompleteUow();

		protected abstract Task CompleteUowAsync();

		protected abstract void DisposeUow();
		protected virtual void ApplyDisableFilter(string filterName)
		{
			FilterExecuter.ApplyDisableFilter(this,filterName);
		}

		protected virtual void ApplyEnableFilter(string filterName)
		{
			FilterExecuter.ApplyEnableFilter(this, filterName);
		}

		private void PreventMultipleBegin()
		{
			if (isBeginCalledBefore)
			{
				throw new InvoiceCloudException("This unit of work has started before. Can not call Start method more than once.");
			}

			isBeginCalledBefore = true;
		}

		private void PreventMultipleComplete()
		{
			if (isCompleteCalledBefore)
			{
				throw new InvoiceCloudException("Complete is called before!");
			}

			isCompleteCalledBefore = true;
		}

		private void SetFilters(List<DataFilterConfiguration> filterOverrides)
		{
			for(var i=0; i< filterOverrides.Count; i++)
			{
				var filterOverride = filterOverrides.FirstOrDefault(f => f.FilterName == filters[i].FilterName);
				if(filterOverride != null)
				{
					filters[i] = filterOverride;
				}
			}			
		}

		private void ChangeFilterIsEnabledIfNotOverrided(List<DataFilterConfiguration> filterOverrides, string filterName, bool isEnable)
		{
			if(filterOverrides.Any(f => f.FilterName == filterName))
			{
				return;
			}

			var index = filters.FindIndex(f => f.FilterName == filterName);
			if(index < 0)
			{
				return;
			}

			if(filters[index].IsEnable == isEnable)
			{
				return;
			}

			filters[index] = new DataFilterConfiguration(filterName, isEnable);
		}

		private DataFilterConfiguration GetFilter(string filterName)
		{
			var filter = filters.FirstOrDefault(f => f.FilterName == filterName);
			if(filter == null)
			{
				throw new InvoiceCloudException("Unknown filter name: " + filterName + ". Be sure this filter is registered before.");
			}

			return filter;
		}

		private int GetFilterIndex(string filterName)
		{
			var filterIndex = filters.FindIndex(f => f.FilterName == filterName);
			if (filterIndex < 0)
			{
				throw new InvoiceCloudException("Unknown filter name: " + filterName + ". Be sure this filter is registered before.");
			}

			return filterIndex;
		}

		protected virtual void ApplyFilterParameterValue(string filterName, string parameterName,object value)
		{
			FilterExecuter.ApplyFilterParameterValue(this, filterName, parameterName, value);
		}
	}
}
