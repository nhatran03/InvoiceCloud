using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Uow
{
	public interface IActiveUnitOfWork
	{
		event EventHandler Completed;

		event EventHandler<UnitOfWorkFailedEventArgs> Failed;

		event EventHandler Disposed;

		UnitOfWorkOptions Options { get; }

		IReadOnlyList<DataFilterConfiguration> Filters { get; }
		
		bool IsDiposed { get; }
		void SaveChange();
		Task SaveChangeAsync();
		IDisposable DisableFilter(params string[] filterNames);
		IDisposable EnableFilter(params string[] filterNames);
		bool IsFilterEnabled(string filterName);
		IDisposable SetFilterParameter(string filterName, string parameterName, object value);
		
	}
}
