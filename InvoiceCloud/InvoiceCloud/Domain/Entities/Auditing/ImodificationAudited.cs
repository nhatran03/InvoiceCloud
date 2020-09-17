using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	public interface IModificationAudited : IHasModificationTime
	{
		long? LastModifierUserId { get; set; }
	}

	public interface IModificationAudited<TUser> : IModificationAudited
		where TUser: IEntity<long>
	{
		TUser LastModifierUser { get; set; }
	}
}
