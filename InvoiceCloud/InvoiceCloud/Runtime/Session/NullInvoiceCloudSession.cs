using InvoiceCloud.Runtime.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Runtime.Session
{
	public class NullInvoiceCloudSession : InvoiceCloudSessionBase
	{
		public static NullInvoiceCloudSession Instance { get; } = new NullInvoiceCloudSession();

		public override long? UserId => null;

		public override long? ImpersonatorUserId => null;
		private NullInvoiceCloudSession()
			:base(new DataContextAmbientScopeProvider<SessionOverride>(new CallContextAmbientDataContext()))
		{

		}
	}
}
