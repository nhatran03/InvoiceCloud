using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Dtos
{
	/// <summary>
	///		A shortcut of <see cref="IEntityDto{TPrimaryKey}" /> for most used primary key type (<see cref="int" />).
	/// </summary>
	public interface IEntityDto : IEntityDto<int>
	{
	}
}
