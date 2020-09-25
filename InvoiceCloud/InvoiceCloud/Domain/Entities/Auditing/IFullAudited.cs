using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	public interface IFullAudited: IAudited,IDeletionAudited
	{

	}

	public interface IFullAudited<TUser>: IAudited<TUser>,IFullAudited,IDeletionAudited<TUser>
		where TUser : IEntity<long>
	{

	}
}
