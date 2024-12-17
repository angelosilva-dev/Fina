using Fina.api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.api.Endpoints.Transactions
{
    public class DeleteTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapDelete("/{id}", HandleAsync)
                .WithName("Transaction: Delete")
                .WithSummary("Deleta uma transação")
                .WithDescription("Deleta uma transação")
                .WithOrder(3)
                .Produces<Response<Transaction?>>();



        private static async Task<IResult> HandleAsync([FromServices]ITransactionHandler handler, [FromRoute]long id)
        {
            var request = new DeleteTransactionRequest
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
