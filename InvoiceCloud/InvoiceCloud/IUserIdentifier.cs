using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud
{
	public interface IUserIdentifier
	{
		long UserId { get; }
	}
}
