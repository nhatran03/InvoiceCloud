﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Events.Bus
{
	public interface IEventDataWithInheritableGenericArgument
	{
		object[] GetConstructorArgs();
	}
}
