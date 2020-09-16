using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Dtos
{
	public class ListResultDto<T> : IListResult<T>
	{
		/// <summary>
		///		List of items.
		/// </summary>
		public IReadOnlyList<T> Items
		{
			get => _items ?? (_items = new List<T>());
			set => _items = value;
		}

		private IReadOnlyList<T> _items;

		/// <summary>
		///		Creates a new <see cref="ListResultDto{T}" /> object.
		/// </summary>
		/// <param name="items"></param>
		public ListResultDto(IReadOnlyList<T> items)
		{
			Items = items;
		}
	}
}
