using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	public interface IDeletionAudited: IHasDeletionTime
	{
		long? DeleterUserId { get; set; }
	}

	public interface IDeletionAudited<TUser>: IDeletionAudited
		where TUser: IEntity<long>
	{
		TUser DeleterUser { get; set; }
	}
}
