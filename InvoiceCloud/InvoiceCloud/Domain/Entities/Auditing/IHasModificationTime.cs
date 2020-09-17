using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	public interface IHasModificationTime
	{
		DateTime? LastModificationTime { get; set; }
	}
}
