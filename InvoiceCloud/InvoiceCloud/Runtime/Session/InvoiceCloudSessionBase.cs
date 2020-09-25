using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Runtime.Session
{
	public class InvoiceCloudSessionBase: IInvoiceCloudSession
	{
		public const string SessionOverrideContextKey = "InvoiceCloude.Runtime.Session.Override";

		public virtual long? UserId { get; }

		public virtual long? ImpersonatorUserId { get; }

		protected SessionOverride OverridedValue => SessionOverrideScopeProvider.GetValue(SessionOverrideContextKey);
		protected IAmbientScopeProvider<SessionOverride> SessionOverrideScopeProvider { get; }

		protected InvoiceCloudSessionBase(IAmbientScopeProvider<SessionOverride> sessionOverridedScopeProvider)
		{
			SessionOverrideScopeProvider = sessionOverridedScopeProvider;
		}

		public IDisposable Use(long? userId)
		{
			return SessionOverrideScopeProvider.BeginScope(SessionOverrideContextKey, new SessionOverride(userId));
		}
	}
}
