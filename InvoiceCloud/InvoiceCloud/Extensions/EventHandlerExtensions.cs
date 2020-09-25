using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Extensions
{
	public static class EventHandlerExtensions
	{
		public static void InvokeSafely(this EventHandler eventHandler, object sender)
		{
			eventHandler.InvokeSafely(sender, EventArgs.Empty);
		}

		public static void InvokeSafely(this EventHandler eventHandler, object sender, EventArgs e)
		{
			eventHandler?.Invoke(sender, e);
		}

		public static void InvokeSafely<TEvenArgs>(this EventHandler<TEvenArgs> eventHandler, object sender, TEvenArgs e)
			where TEvenArgs:EventArgs
		{
			eventHandler?.Invoke(sender, e);
		}
	}
}
