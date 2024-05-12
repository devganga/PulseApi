using PulseApi.Application.Common.Interfaces;
using PulseApi.Application.Common.Mappings;
using PulseApi.Application.Common.Models;

namespace PulseApi.Application.QuoteItems.Queries.GetQuoteItemsWithPagination;

public record GetQuoteItemsWithPaginationQuery : IRequest<PaginatedList<QuoteItemDto>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetQuoteItemsWithPaginationQueryHandler : IRequestHandler<GetQuoteItemsWithPaginationQuery, PaginatedList<QuoteItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetQuoteItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<PaginatedList<QuoteItemDto>> Handle(GetQuoteItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {

        return await _context.QuoteItems
            .OrderBy(x => x.Id)
            //.Where(x=> x.Title == "Test")
            //.ProjectTo<QuoteItemDto>(_ma)
            //.Where(x=>x.id)
            .ProjectTo<QuoteItemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
        //throw new NotImplementedException();
        //await Task.CompletedTask;
    }
}
