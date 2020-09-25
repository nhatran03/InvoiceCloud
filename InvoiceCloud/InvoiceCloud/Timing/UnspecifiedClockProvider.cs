﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Timing
{
	public class UnspecifiedClockProvider : IClockProvider
	{
		public DateTime Now => DateTime.Now;

		public DateTimeKind Kind => DateTimeKind.Unspecified;

		public bool SupportsMultipleTimezone => false;

		public DateTime Normalize(DateTime dateTime)
		{
			return dateTime;
		}

		internal UnspecifiedClockProvider()
		{

		}
	}
}
