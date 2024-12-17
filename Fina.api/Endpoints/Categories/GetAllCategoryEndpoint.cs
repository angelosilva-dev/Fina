using Fina.api.Common.Api;
using Fina.Core;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.api.Endpoints.Categories
{
    public class GetAllCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/", HandleAsync)
                .WithName("Categories: Get all categories")
                .WithSummary("Recupera todas as categoria")
                .WithDescription("Recupera todas as categoria")
                .WithOrder(3)
                .Produces<PagedResponse<Category?>>();

        private static async Task<IResult> HandleAsync(
            [FromServices] ICategoryHandler handler,
            [FromQuery] int pageNumber = Configuration.DefaultPageNumber,
            [FromQuery] int pageSize = Configuration.DefaultPageSize)
        {
            var request = new GetAllCategoriesRequest
            {
                //Como nao temos autenticação, estamos fixando um usuario
                UserId = ApiConfiguration.UserId,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var response = await handler.GetAllAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
