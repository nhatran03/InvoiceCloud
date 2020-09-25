using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InvoiceCloud
{
	public class DisposeAction: IDisposable
	{
		public static readonly DisposeAction Empty = new DisposeAction(null);

		private Action action;
		private object p;

		public DisposeAction([CanBeNull] Action action)
		{
			this.action = action;
		}

		public void Dispose()
		{
			var exchangeAction = Interlocked.Exchange(ref action, null);
			exchangeAction?.Invoke();
		}
	}
}
