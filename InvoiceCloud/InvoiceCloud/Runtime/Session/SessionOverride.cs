using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Runtime.Session
{
	public class SessionOverride
	{
		public long? UserId { get; }

		public SessionOverride(long? userId)
		{
			UserId = userId;
		}
	}
}
