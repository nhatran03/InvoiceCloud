using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Events.Bus.Entities
{
	[Serializable]
	public class EntityEventData<TEntity> : EventData, IEventDataWithInheritableGenericArgument
	{
		/// <summary>
		/// Related entity with this event
		/// </summary>
		public TEntity Entity { get; private set; }

		public EntityEventData(TEntity entity)
		{
			Entity = entity;
		}

		public object[] GetConstructorArgs()
		{
			return new object[] { Entity };
		}
	}
}
