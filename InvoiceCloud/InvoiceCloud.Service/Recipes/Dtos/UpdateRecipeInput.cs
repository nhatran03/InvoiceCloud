using InvoiceCloud.Core.Domain.Recipes;
using InvoiceCloud.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Service.Recipes.Dtos
{
	public class UpdateRecipeInput : EntityDto<long>
	{
		[StringLength(RecipeBase.MaxDescriptionLength)]
		[Required]
		public string Description { get; set; }
	}
}
