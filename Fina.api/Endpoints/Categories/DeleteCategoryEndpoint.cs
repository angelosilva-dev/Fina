using Fina.api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.api.Endpoints.Categories
{
    public class DeleteCategoryEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
                .WithName("Categories: Delete")
                .WithSummary("Deleta uma categoria")
                .WithDescription("Deleta uma categoria")
                .WithOrder(3)
                .Produces<Response<Category?>>();



        private static async Task<IResult> HandleAsync([FromServices]ICategoryHandler handler, [FromRoute]long id)
        {
            var request = new DeleteCategoryRequest 
            {
                //Como nao temos autenticação, estamos fixando um usuario
                UserId = ApiConfiguration.UserId,
                Id = id   
            };

            var response = await handler.DeleteAsync(request);
            return response.IsSuccess 
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
