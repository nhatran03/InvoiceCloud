using InvoiceCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Core.Domain.Recipes
{
	public class RecipeBase: Entity<long>
	{
		public const int MaxDescriptionLength = 250;

		[MaxLength(MaxDescriptionLength)]
		[Required]
		public virtual string Description { get; set; }
	}
}
