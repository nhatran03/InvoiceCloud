using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	public interface IAudited : ICreationAudited, IModificationAudited
	{

	}

	public interface IAudited<TUser>: IAudited, ICreationAudited<TUser>, IModificationAudited<TUser>
		where TUser: IEntity<long>
	{

	}
}
