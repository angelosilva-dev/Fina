using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Handlers
{
    public interface ICategoryHandler
    {
        Task<PagedResponse<List<Category?>>> GetAllAsync(GetAllCategoriesRequest getAllCategoriesRequest);
        Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest getCategoryByIdRequest);
        Task<Response<Category?>> CreateAsync(CreateCategoryRequest createCategoryRequest);
        Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest updateCategoryRequest);
        Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest deleteCategoryRequest);
    }
}
