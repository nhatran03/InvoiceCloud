using AutoMapper;
using InvoiceCloud.Core.Domain.Recipes;
using InvoiceCloud.Service.Recipes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Service.Recipes.MapperProfiles
{
	public class RecipeMapperProfile : Profile
	{
		public RecipeMapperProfile()
		{
			CreateMap<Recipe, RecipeVersion>();

			CreateMap<Recipe, RecipeDto>();
			CreateMap<CreateRecipeInput, Recipe>();
			CreateMap<UpdateRecipeInput, Recipe>();

			CreateMap<RecipeVersion, RecipeDto>();
			CreateMap<CreateRecipeInput, RecipeVersion>();
			CreateMap<UpdateRecipeInput, RecipeVersion>();
		}
	}
}
