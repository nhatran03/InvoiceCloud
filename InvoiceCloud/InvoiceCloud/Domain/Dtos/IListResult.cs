using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Dtos
{
	public interface IListResult<T>
	{
		/// <summary>
		///		List of items.
		/// </summary>
		IReadOnlyList<T> Items { get; set; }
	}
}
