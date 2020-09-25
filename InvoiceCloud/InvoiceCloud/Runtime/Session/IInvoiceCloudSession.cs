using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Runtime.Session
{
	public interface IInvoiceCloudSession
	{
		long? UserId { get; }

		long? ImpersonatorUserId { get; }
		
	}
}
