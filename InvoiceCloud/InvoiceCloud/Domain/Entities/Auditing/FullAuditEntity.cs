using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	[Serializable]
	public class FullAuditEntity : FullAuditedEntity<int>
	{

	}

	[Serializable]
	public abstract class FullAuditedEntity<TPrimaryKey> : AuditedEntity<TPrimaryKey>, IFullAudited
	{
		public virtual bool IsDeleted { get; set; }
		public virtual long? DeleterUserId { get; set ; }
		public virtual DateTime? DeletionTime { get ; set ; }
	}

	[Serializable]
	public abstract class FullAuditedEntity<TPrimaryKey, TUser> : AuditedEntity<TPrimaryKey>, IFullAudited<TUser>
		where TUser : IEntity<long>
	{
		public virtual bool IsDeleted { get; set; }		
		[ForeignKey("DeleterUserId")]
		public virtual TUser DeleterUser { get; set; }
		public virtual long? DeleterUserId { get ; set; }
		public virtual DateTime? DeletionTime { get ; set; }
		[ForeignKey("CreatorUserId")]
		public virtual TUser CreatorUser { get; set; }
		[ForeignKey("LastModifierUserId")]
		public virtual TUser LastModifierUser { get; set; }
	}
}
