using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Dtos
{
	/// <summary>
	///		Defines interface for base entity dto type. All entity dtos in the system must implement this interface.
	/// </summary>
	/// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
	public interface IEntityDto<TPrimaryKey>
	{
		/// <summary>
		///		Unique identifier for this entity.
		/// </summary>
		TPrimaryKey Id { get; set; }
	}
}
