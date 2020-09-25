using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	[Serializable]
	public class AuditedEntity: AuditedEntity<int>
	{

	}

	[Serializable]
	public abstract class AuditedEntity<TPrimaryKey> : CreationAuditedEntity<TPrimaryKey>, IAudited
	{
		public virtual long? LastModifierUserId { get; set; }
		public virtual DateTime? LastModificationTime { get; set; }
	}

	[Serializable]
	public abstract class AuditEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey>, IAudited<TUser>
		where TUser : IEntity<long>
	{
		[ForeignKey("CreatorUserId")]
		public TUser CreatorUser { get ; set ; }
		
		[ForeignKey("LastModifierUserId")]
		public TUser LastModifierUser { get ; set ; }
		
	}
}
