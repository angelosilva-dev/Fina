using Fina.api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.api.Endpoints.Categories
{
    public class GetCategoryByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Categories: Get by Id")
                .WithSummary("Recupera uma categoria por Id")
                .WithDescription("Recupera uma categoria por Id")
                .WithOrder(4)
                .Produces<Response<Category?>>();

        private static async Task<IResult> HandleAsync([FromServices]ICategoryHandler handler, [FromRoute]long id)
        {
            var request = new GetCategoryByIdRequest
            {
                Id = id,
                UserId = ApiConfiguration.UserId

            };

            var response = await handler.GetByIdAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);                
        }
    }
}
