using Company.Services.Application.Interfaces;
using Company.Services.Shared.Contracts.ViewModels.Transactions;
using Company.Services.Transaction.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Company.Services.Transaction.Api;

public class TransactionEndpoints : IEndpointRouteDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var group = app.MapGroup("")
            .WithTags("Transactions");

        group.MapPost("transactions",
        async ([FromBody] TransactionRequestViewModel request, [FromServices] ITransactionService productService) =>
        {
            var createdTransaction = await productService.CreateTransactionAsync(request);
            return Results.Created($"/transactions", createdTransaction);
        })
        .Accepts<bool>(MediaTypeNames.Application.Json)
        .Produces<bool>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        group.MapGet("transactions/{id:guid}",
        async (Guid id, [FromServices] ITransactionService productService) =>
        {
            var product = await productService.GetTransactionAsync(id);
            return product != null ? Results.Ok(product) : Results.NotFound("Transaction not found");
        })
        .Produces<TransactionViewModel>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
