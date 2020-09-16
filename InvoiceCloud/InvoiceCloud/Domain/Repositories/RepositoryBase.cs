using InvoiceCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Repositories
{
	/// <summary>
	///		Base class to implement <see cref="T:Smartwebs.EfCore.Repositories.IRepository`2" />.
	///     It implements some methods in most simple way.
	/// </summary>
	/// <typeparam name="TEntity">Type of the Entity for this repository</typeparam>
	/// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
	public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
		where TEntity : class, IEntity<TPrimaryKey>
	{
		public virtual TEntity FirstOrDefault(TPrimaryKey id)
		{
			return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
		}
		public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().FirstOrDefault(predicate);
		}

		public virtual TEntity Get(TPrimaryKey id)
		{
			var entity = FirstOrDefault(id);
			if (entity == null)
				throw new ArgumentNullException("entity");

			return entity;
		}

		public abstract IQueryable<TEntity> GetAll();

		public virtual List<TEntity> GetAllList()
		{
			return GetAll().ToList();
		}

		public abstract TEntity Insert(TEntity entity);

		public virtual Task<TEntity> InsertAsync(TEntity entity)
		{
			return Task.FromResult(Insert(entity));
		}

		public abstract Task SaveChangeAsync();

		public abstract TEntity Update(TEntity entity);

		public virtual Task<TEntity> UpdateAsync(TEntity entity)
		{
			return Task.FromResult(Update(entity));
		}

		protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
		{
			var lamdaParam = Expression.Parameter(typeof(TEntity));

			var lamdaBody = Expression.Equal(Expression.PropertyOrField(lamdaParam, "Id"),
				Expression.Constant(id, typeof(TPrimaryKey)));

			return Expression.Lambda<Func<TEntity, bool>>(lamdaBody, lamdaParam);
		}
	}
}
