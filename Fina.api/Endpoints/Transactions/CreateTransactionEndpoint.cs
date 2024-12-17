using Fina.api.Common.Api;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Transactions;
using Fina.Core.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Fina.api.Endpoints.Transactions
{
    public class CreateTransactionEndpoint : IEndpoint
    {
        public static void Map(IEndpointRouteBuilder app)
            => app.MapPost("/", HandleAsync)
                .WithName("Transaction: Create")
                .WithSummary("Cria uma nova transação")
                .WithDescription("Cria uma nova transação")
                .WithOrder(1)
                .Produces<Response<Transaction?>>();



        private static async Task<IResult> HandleAsync([FromServices]ITransactionHandler handler, [FromBody]CreateTransactionRequest request)
        {
            //Como nao temos autenticação, estamos fixando um usuario
            request.UserId = ApiConfiguration.UserId;

            var response = await handler.CreateAsync(request);
            return response.IsSuccess ? TypedResults.Created($"/{response.Data?.Id}", response)
                                      : TypedResults.BadRequest(response);
        }
    }
}
