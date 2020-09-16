
using AutoMapper;
using InvoiceCloud.Core.Domain.Recipes;
using InvoiceCloud.Domain.Dtos;
using InvoiceCloud.Domain.Repositories;
using InvoiceCloud.Service.Recipes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Service.Recipes
{
	public class RecipeService : IRecipeService
	{
		private readonly IRepository<Recipe,long> _recipeRepository;
		private readonly IRepository<RecipeVersion,long> _recipeVersionRepository;

		public RecipeService(IRepository<Recipe,long> recipeRepository,
			IRepository<RecipeVersion,long> recipeVersionRepository)
		{
			_recipeRepository = recipeRepository;
			_recipeVersionRepository = recipeVersionRepository;
		}
		public async Task<RecipeDto> Create(CreateRecipeInput input)
		{
			var recipe = Mapper.Map<Recipe>(input);

			await _recipeRepository.InsertAsync(recipe);
			await _recipeRepository.SaveChangeAsync();

			await MakeVersion(recipe, null);

			return Mapper.Map<RecipeDto>(recipe);
		}

		public Task<int> diagonalDifference(List<List<int>> arr)
		{
			throw new NotImplementedException();
		}

		public RecipeDto Get(long id)
		{
			var result = _recipeRepository.Get(id);

			return Mapper.Map<RecipeDto>(result);
		}

		public Task<ListResultDto<RecipeDto>> GetAll()
		{
			var results = _recipeRepository.GetAllList();

			return Task.FromResult(new ListResultDto<RecipeDto>(
				Mapper.Map<List<RecipeDto>>(results)
			));
		}

		public Task<ListResultDto<RecipeDto>> GetVersions(long id)
		{
			var results = _recipeVersionRepository.Get(id);

			return Task.FromResult(new ListResultDto<RecipeDto>(
				Mapper.Map<List<RecipeDto>>(results)
				));
		}

		public async Task<RecipeDto> Update(UpdateRecipeInput input)
		{
			var recipe = _recipeRepository.Get(input.Id);

			if(recipe != null)
			{
				await MakeVersion(recipe, input.Id);

				var mapped = Mapper.Map(input, recipe);
				await _recipeRepository.UpdateAsync(mapped);
				await _recipeRepository.SaveChangeAsync();
			}

			return Mapper.Map<RecipeDto>(recipe);
		}

		private async Task MakeVersion(Recipe recipe, long? recipeId)
		{
			var recipeVersion = Mapper.Map<RecipeVersion>(recipe);
			recipeVersion.RecipeId = recipeId;

			await _recipeVersionRepository.InsertAsync(recipeVersion);
			await _recipeVersionRepository.SaveChangeAsync();
		}
	}
}
