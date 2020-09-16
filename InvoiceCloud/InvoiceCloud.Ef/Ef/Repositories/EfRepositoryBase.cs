using InvoiceCloud.Domain.Entities;
using InvoiceCloud.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Ef.Ef.Repositories
{
	/// <summary>
	///     Implements IRepository for Entity Framework.
	/// </summary>
	/// <typeparam name="TEntity">Type of the Entity for this repository</typeparam>
	/// <typeparam name="TPrimaryKey">Primary key of the entity</typeparam>
	public class EfRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
		where TEntity : class, IEntity<TPrimaryKey>
	{
		/// <summary>
		///     Gets EF DbContext object.
		/// </summary>
		private InvoiceCloudDbContext _dbContext;

		/// <summary>
		/// Gets DbSet for given entity.
		/// </summary>
		public virtual DbSet<TEntity> Table => _dbContext.Set<TEntity>();

		public EfRepositoryBase(InvoiceCloudDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public override IQueryable<TEntity> GetAll()
		{
			return Table;
		}

		public override TEntity Insert(TEntity entity)
		{
			return Table.Add(entity);
		}

		public override Task<TEntity> InsertAsync(TEntity entity)
		{
			return Task.FromResult(Insert(entity));
		}

		public override async Task SaveChangeAsync()
		{
			await _dbContext.SaveChangesAsync();
		}

		public override TEntity Update(TEntity entity)
		{
			AttachIfNot(entity);
			_dbContext.Entry(entity).State = EntityState.Modified;
			return entity;
		}

		public override Task<TEntity> UpdateAsync(TEntity entity)
		{
			return Task.FromResult(Update(entity));
		}

		protected virtual void AttachIfNot(TEntity entity)
		{
			if (Table.Local.Contains(entity))
			{
				Table.Attach(entity);
			}
		}
	}
}
