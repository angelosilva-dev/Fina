using Fina.api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.api.Endpoints.Transactions
{
    public class GetTransactionsByIdEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapGet("/{id}", HandleAsync)
                .WithName("Transaction: Get by Id")
                .WithSummary("Recupera uma transação por Id")
                .WithDescription("Recupera uma transação por Id")
                .WithOrder(4)
                .Produces<Response<Transaction?>>();

        private static async Task<IResult> HandleAsync([FromServices]ITransactionHandler handler, [FromRoute]long id)
        {
            var request = new GetTransactionByIdRequest
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
