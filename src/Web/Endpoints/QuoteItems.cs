using PulseApi.Application.Common.Models;
using PulseApi.Application.QuoteItems.Commands.CreateQuoteItem;
using PulseApi.Application.QuoteItems.Commands.DeleteQuoteItem;
using PulseApi.Application.QuoteItems.Commands.UpdateQuoteItem;
using PulseApi.Application.QuoteItems.Queries.GetQuoteItemsWithPagination;


namespace PulseApi.Web.Endpoints;

public class QuoteItems : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
           .RequireAuthorization()
           .MapGet(GetQuoteItemsWithPagination)
           .MapPost(CreateQuoteItem)
           .MapPut(UpdateQuoteItem, "{id}")
           .MapDelete(DeleteQuoteItem, "{id}");
    }
  
    public Task<PaginatedList<QuoteItemDto>> GetQuoteItemsWithPagination(ISender sender, [AsParameters] GetQuoteItemsWithPaginationQuery query)
    {
        return sender.Send(query);
    }

    public Task<int> CreateQuoteItem(ISender sender, CreateQuoteItemCommand command)
    {
        return sender.Send(command);
    }

    public async Task<IResult> UpdateQuoteItem(ISender sender, int id, UpdateQuoteItemCommand command)
    {
        if (id != command.Id) return Results.BadRequest();
        await sender.Send(command);
        return Results.NoContent();
    }

    public async Task<IResult> DeleteQuoteItem(ISender sender, int id)
    {
        await sender.Send(new DeleteQuoteItemCommand(id));
        return Results.NoContent();
    }
}
