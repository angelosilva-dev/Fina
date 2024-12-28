using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System.Net.Http.Json;

namespace Fina.Web.Handlers
{
    public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
    {
        private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest createCategoryRequest)
        {
            var result = await _httpClient.PostAsJsonAsync("v1/categories", createCategoryRequest);

            //TODO: No projeto real criar Try Catch
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                ?? new Response<Category?>(null, 400, "Falha ao cadastrar a categoria.");
        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest deleteCategoryRequest)
        {
            var result = await _httpClient.DeleteAsync($"v1/categories/{deleteCategoryRequest.Id}");

            //TODO: No projeto real criar Try Catch
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                ?? new Response<Category?>(null, 400, "Falha ao deletar a categoria.");
        }

        public async Task<PagedResponse<List<Category?>>> GetAllAsync(GetAllCategoriesRequest getAllCategoriesRequest)
            => await _httpClient.GetFromJsonAsync<PagedResponse<List<Category?>>>($"v1/categories")
                ?? new PagedResponse<List<Category?>>(null, 400, "Categoria não encontrada");

        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest getCategoryByIdRequest)
            => await _httpClient.GetFromJsonAsync<Response<Category?>>($"v1/categories/{getCategoryByIdRequest.Id}") 
                ?? new Response<Category?>(null, 400, "Categoria não encontrada");

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest updateCategoryRequest)
        {
            var result = await _httpClient.PutAsJsonAsync($"v1/categories/{updateCategoryRequest.Id}", updateCategoryRequest);

            //TODO: No projeto real criar Try Catch
            return await result.Content.ReadFromJsonAsync<Response<Category?>>()
                ?? new Response<Category?>(null, 400, "Falha ao atualizar a categoria.");
        }
    }
}
