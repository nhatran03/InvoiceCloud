﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Uow
{
	public interface ICurrentUnitOfWorkProvider
	{
		IUnitOfWork Current { get; set; }
	}
}
