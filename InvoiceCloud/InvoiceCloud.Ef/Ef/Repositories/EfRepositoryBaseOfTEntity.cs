using InvoiceCloud.Domain.Entities;
using InvoiceCloud.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Ef.Ef.Repositories
{
	public class EfRepositoryBase<TEntity> : EfRepositoryBase<TEntity, int>,
		IRepository<TEntity>
		where TEntity: class, IEntity<int>
	{
		public EfRepositoryBase(InvoiceCloudDbContext invoiceCloudDbContext): base(invoiceCloudDbContext)
		{

		}
	}
}
