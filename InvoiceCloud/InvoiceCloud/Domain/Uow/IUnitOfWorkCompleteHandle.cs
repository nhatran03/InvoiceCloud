using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Uow
{
	public interface IUnitOfWorkCompleteHandle: IDisposable
	{
		void Complete();
		Task CompleteAsync();
	}
}
