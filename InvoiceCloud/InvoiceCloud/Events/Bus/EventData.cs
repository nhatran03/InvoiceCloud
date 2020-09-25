using InvoiceCloud.Timing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Events.Bus
{
	[Serializable]
	public class EventData : IEventData
	{
		public DateTime EventTime { get; set ; }
		public object EventSource { get; set; }

		protected EventData()
		{
			EventTime = Clock.Now;
		}
	}
}
