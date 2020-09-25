using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Timing
{
	public static class Clock
	{
		public static IClockProvider Provider
		{
			get { return provider; }
			set
			{
				if(value == null)
				{
					throw new ArgumentNullException(nameof(value), "Can not set Clock.Provider to null");
				}
				provider = value;
			}
		}

		private static IClockProvider provider;

		static Clock()
		{
			Provider = ClockProviders.Unspecified;
		}

		public static DateTime Now => Provider.Now;

		public static DateTimeKind Kind => Provider.Kind;

		public static bool SupportsMultipleTimezone => Provider.SupportsMultipleTimezone;

		public static DateTime Normalize(DateTime dateTime)
		{
			return Provider.Normalize(dateTime);
		}
	}
}
