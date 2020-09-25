using InvoiceCloud.Timing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Auditing
{
	[Serializable]
	class CreationAuditedEntity : CreationAuditedEntity<int>
	{

	}

	[Serializable]
	public abstract class CreationAuditedEntity<TPrimaryKey> : Entity<TPrimaryKey>,ICreationAudited
	{
		public virtual long? CreatorUserId { get ; set ; }
		public virtual DateTime CreationTime { get ; set ; }

		protected CreationAuditedEntity()
		{
			CreationTime = Clock.Now;
		}
	}

	[Serializable]
	public abstract class CreationAuditedEntity<TTPrimaryKey, TUser>: CreationAuditedEntity<TTPrimaryKey>,ICreationAudited<TUser>
		where TUser: IEntity<long>
	{

		[ForeignKey("CreatorUserId")]
		public virtual TUser CreatorUser { get; set; }
	}
}
