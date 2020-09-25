using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Timing.Timezone
{
	public interface ITimeZoneConverter
	{
		DateTime? Convert(DateTime? date, long userId);

		DateTime? Convert(DateTime? date);
	}
}
