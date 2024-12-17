using Fina.api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.api.Endpoints.Transactions
{
    public class UpdateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPut("/{id}", HandleAsync)
                .WithName("Transaction: Update")
                .WithSummary("Atualiza uma transação")
                .WithDescription("Atualiza uma transação")
                .WithOrder(2)
                .Produces<Response<Transaction?>>();



        private static async Task<IResult> HandleAsync([FromServices]ITransactionHandler handler, [FromBody]UpdateTransactionRequest request, [FromRoute]long id)
        {
            request.UserId = ApiConfiguration.UserId;
            request.Id = id;

            var response = await handler.UpdateAsync(request);
            return response.IsSuccess
                ? TypedResults.Ok(response)
                : TypedResults.BadRequest(response);
        }
    }
}
