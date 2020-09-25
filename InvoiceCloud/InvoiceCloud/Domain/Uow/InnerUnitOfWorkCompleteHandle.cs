using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Uow
{
	public class InnerUnitOfWorkCompleteHandle : IUnitOfWorkCompleteHandle
	{

		public const string DidNotCallCompleteMethodExceptionMessage = "Did not call Complete method of a unit of work.";
		private volatile bool isCompleteCalled;
		private volatile bool isDisposed;

		public void Complete()
		{
			isCompleteCalled = true;
		}

		public async Task CompleteAsync()
		{
			isCompleteCalled = true;
		}

		public void Dispose()
		{
			if (isDisposed)
			{
				return;
			}

			isDisposed = true;

			if (!isCompleteCalled)
			{
				if (HasException())
				{
					return;
				}

				throw new InvoiceCloudException(DidNotCallCompleteMethodExceptionMessage);
			}
		}

		private static bool HasException()
		{
			try
			{
				return Marshal.GetExceptionCode() != 0;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
