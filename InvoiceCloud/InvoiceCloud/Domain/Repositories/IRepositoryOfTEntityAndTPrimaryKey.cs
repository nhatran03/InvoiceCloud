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
	/// This interface is implemented by all repositories to ensure implementation of fixed methods.
	/// </summary>
	/// <typeparam name="TEntity">Main Entity type this repository works on</typeparam>
	/// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
	public interface IRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
	{
		/// <summary>
		/// Used to get a IQueryable that is used to retrieve entities from entire table.
		/// </summary>
		/// <returns>IQueryable to be used to select entities from database</returns>
		IQueryable<TEntity> GetAll();

		/// <summary>
		/// Used to get all entities.
		/// </summary>
		/// <returns>List of all entities</returns>
		List<TEntity> GetAllList();

		/// <summary>
		/// Gets an entity with given primary key.
		/// </summary>
		/// <param name="id">Primary key of the entity to get</param>
		/// <returns>Entity</returns>
		TEntity Get(TPrimaryKey id);

		/// <summary>
		/// Gets an entity with given given predicate or null if not found.
		/// </summary>
		/// <param name="predicate">Predicate to filter entities</param>
		TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

		/// <summary>
		/// Inserts a new entity.
		/// </summary>
		/// <param name="entity">Inserted entity</param>
		Task<TEntity> InsertAsync(TEntity entity);

		/// <summary>
		/// Updates an existing entity. 
		/// </summary>
		/// <param name="entity">Entity</param>
		Task<TEntity> UpdateAsync(TEntity entity);

		Task SaveChangeAsync();
	}
}
