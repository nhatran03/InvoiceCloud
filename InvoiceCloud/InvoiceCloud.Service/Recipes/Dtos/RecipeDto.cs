using InvoiceCloud.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Service.Recipes.Dtos
{
	public class RecipeDto : EntityDto<long>
	{
		public virtual string Description { get; set; }
	}
}
