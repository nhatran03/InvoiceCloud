using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Events.Bus.Handlers
{
	/// <summary>
	/// Defines an interface of a class that handles events of type <see cref="TEventData"/>
	/// </summary>
	/// <typeparam name="TEventData">Event type of handle</typeparam>
	public interface IEventHandler<in TEventData>: IEventHandler
	{
		/// <summary>
		/// Handler handles the event by implementing this method
		/// </summary>
		/// <param name="eventData"></param>
		void HandleEvent(TEventData eventData);
	}
}
