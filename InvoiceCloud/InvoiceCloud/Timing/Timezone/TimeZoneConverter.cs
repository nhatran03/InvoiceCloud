using InvoiceCloud.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Timing.Timezone
{
	public class TimeZoneConverter : ITimeZoneConverter, ITransientDependency
	{
		public DateTime? Convert(DateTime? date, long userId)
		{
			throw new NotImplementedException();
		}

		public DateTime? Convert(DateTime? date)
		{
			throw new NotImplementedException();
		}
	}
}
