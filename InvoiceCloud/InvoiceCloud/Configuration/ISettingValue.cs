using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Configuration
{
	public interface ISettingValue
	{
		string Name { get; }
		string Value { get; }
	}
}
