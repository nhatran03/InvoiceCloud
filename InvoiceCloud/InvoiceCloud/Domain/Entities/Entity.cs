﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities
{
	/// <summary>
	///		A shortcut of <see cref="Entity{TPrimaryKey}" /> for most used primary key type (<see cref="int" />).
	/// </summary>
	public abstract class Entity : Entity<int>, IEntity
	{
	}

	/// <summary>
	///		Basic implementation of IEntity interface.
	///     An entity can inherit this class of directly implement to IEntity interface.
	/// </summary>
	/// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
	public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
	{
		/// <summary>
		/// Unique identifier for this entity.
		/// </summary>
		public virtual TPrimaryKey Id { get; set; }

		/// <summary>
		///		Checks if this entity is transient (it has not an Id).
		/// </summary>
		/// <returns>True, if this entity is transient</returns>
		public virtual bool IsTransient()
		{
			if (EqualityComparer<TPrimaryKey>.Default.Equals(Id, default(TPrimaryKey)))
			{
				return true;
			}

			//Workaround for EF Core since it sets int/long to min value when attaching to dbcontext
			if (typeof(TPrimaryKey) == typeof(int))
			{
				return Convert.ToInt32(Id) <= 0;
			}

			if (typeof(TPrimaryKey) == typeof(long))
			{
				return Convert.ToInt64(Id) <= 0;
			}

			return false;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is Entity<TPrimaryKey>))
			{
				return false;
			}

			//Same instances must be considered as equal
			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			//Transient objects are not considered as equal
			var other = (Entity<TPrimaryKey>)obj;

			//Must have a IS-A relation of types or must be same type
			var typeOfThis = GetType();
			var typeOfOther = obj.GetType();
			if (!typeOfThis.GetTypeInfo().IsAssignableFrom(typeOfOther) &&
				!typeOfOther.GetTypeInfo().IsAssignableFrom(typeOfThis))
			{
				return false;
			}

			return Id.Equals(other.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public static bool operator ==(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
		{
			if (Equals(left, null))
			{
				return Equals(right, null);
			}

			return left.Equals(right);
		}

		public static bool operator !=(Entity<TPrimaryKey> left, Entity<TPrimaryKey> right)
		{
			return !(left == right);
		}

		public override string ToString()
		{
			return $"[{GetType().Name} {Id}]";
		}
	}
}
