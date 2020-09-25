﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	public interface ICreationAudited : IHasCreationTime
	{
		long? CreatorUserId { get; set; }
	}

	public interface ICreationAudited<TUser> : ICreationAudited
		where TUser : IEntity<long>
	{
		TUser CreatorUser { get; set; }
	}
}
