using AutoMapper;
using InvoiceCloud.Domain.Repositories;
using InvoiceCloud.Events.Bus.Entities;
using InvoiceCloud.Events.Bus.Handlers;
using InvoiceCloud.ObjectMapping;
using InvoiceCloud.Runtime.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Domain.Entities.Caching
{
	public class EntityCache<TEntity, TCacheItem>:
		EntityCache<TEntity, TCacheItem, int>,IEntityCache<TCacheItem>
		where TEntity: class, IEntity<int>
	{
		public EntityCache(
			ICacheManager cacheManager,
			IRepository<TEntity, int> repository,
			string cacheName = null):base(
				cacheManager,
				repository,
				cacheName)
		{

		}
	}

	public class EntityCache<TEntity, TCacheItem, TPrimaryKey> :
		IEventHandler<EntityChangedEventData<TEntity>>, IEntityCache<TCacheItem, TPrimaryKey>
		where TEntity : class, IEntity<TPrimaryKey>
	{
		public TCacheItem this[TPrimaryKey id] => Get(id);

		public string CacheName { get; private set; }

		public ITypeCache<TPrimaryKey, TCacheItem> InternalCache => CacheManager.GetCache<TPrimaryKey, TCacheItem>(CacheName);

		public ObjectMapping.IObjectMapper ObjectMapper { get; private set; }

		protected ICacheManager CacheManager { get; private set; }

		protected IRepository<TEntity, TPrimaryKey> Repository { get; private set; }

		public EntityCache(ICacheManager cacheManager,
			IRepository<TEntity, TPrimaryKey> repository,
			string cacheName = null)
		{
			Repository = repository;
			CacheManager = cacheManager;
			cacheName = cacheName ?? GenerateDefaultCacheName();
			ObjectMapper = NullObjectMapper.Instance;
		}

		public TCacheItem Get(TPrimaryKey id)
		{
			return InternalCache.Get(id, () => GetCacheItemFromDataSource(id));
		}

		public Task<TCacheItem> GetAsync(TPrimaryKey id)
		{
			return InternalCache.GetAsync(id, () => GetCacheItemFromDataSourceAsync(id));
		}

		public void HandleEvent(EntityChangedEventData<TEntity> eventData)
		{
			InternalCache.Remove(eventData.Entity.Id);
		}

		protected virtual TCacheItem GetCacheItemFromDataSource(TPrimaryKey id)
		{
			return MapToCacheItem(GetEntityFromDataSource(id));
		}

		protected virtual async Task<TCacheItem> GetCacheItemFromDataSourceAsync(TPrimaryKey id)
		{
			return MapToCacheItem(await GetEntityFromDataSourceAsync(id));
		}

		public virtual TEntity GetEntityFromDataSource(TPrimaryKey id)
		{
			return Repository.FirstOrDefault(id);
		}

		public virtual Task<TEntity> GetEntityFromDataSourceAsync(TPrimaryKey id)
		{
			return Repository.FirstOrDefaultAsync(id);
		}

		protected virtual string GenerateDefaultCacheName()
		{
			return GetType().FullName;
		}

		protected virtual TCacheItem MapToCacheItem(TEntity entity)
		{
			if(ObjectMapper is NullObjectMapper)
			{
				throw new InvoiceCloudException(
					$"MapToCacheItem method should be override or IObjectMapper should be implemented in order to map {typeof(TEntity)} to {typeof(TCacheItem)}"
					);
			}

			return ObjectMapper.Map<TCacheItem>(entity);
		}

		public override string ToString()
		{
			return string.Format("EntityCache {0}",CacheName);
		}
	}
}
