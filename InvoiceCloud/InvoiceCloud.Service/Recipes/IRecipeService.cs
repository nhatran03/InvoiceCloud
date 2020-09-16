using InvoiceCloud.Domain.Dtos;
using InvoiceCloud.Service.Recipes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceCloud.Service.Recipes
{
	public interface IRecipeService
	{
        Task<ListResultDto<RecipeDto>> GetAll();

        Task<ListResultDto<RecipeDto>> GetVersions(long id);

        RecipeDto Get(long id);

        Task<RecipeDto> Create(CreateRecipeInput input);

        Task<RecipeDto> Update(UpdateRecipeInput input);
        Task<int> diagonalDifference(List<List<int>> arr);
    }
}
