using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Uow
{
	public class DataFilterConfiguration
	{
		public string FilterName { get; }
		public bool	IsEnable{ get; }
		public IDictionary<string, object> FilterParameters { get; }

		public DataFilterConfiguration(string filterName, bool isEnable)
		{
			FilterName = filterName;
			IsEnable = IsEnable;
			FilterParameters = new Dictionary<string, object>();
		}

		internal DataFilterConfiguration(DataFilterConfiguration filterToClone, bool? isEnable = null)
			: this(filterToClone.FilterName, isEnable?? filterToClone.IsEnable)
		{
			foreach(var filterParameter in filterToClone.FilterParameters)
			{
				FilterParameters[filterParameter.Key] = filterParameter.Value;
			}
		}
	}
}
