using InvoiceCloud.Core.Domain.Recipes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Ef.Ef
{
	public class InvoiceCloudDbContext: DbContext
	{
		public InvoiceCloudDbContext() : base("InvoiceCloudDbContext")
		{ 

		}

		public InvoiceCloudDbContext(string connectionString): base(connectionString)
		{

		}

		public virtual DbSet<Recipe> Recipes { get; set; }

		public virtual DbSet<RecipeVersion> RecipeVersions { get; set; }
	}
}
