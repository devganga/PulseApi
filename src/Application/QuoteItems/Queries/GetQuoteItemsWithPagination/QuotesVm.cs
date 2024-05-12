using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PulseApi.Application.TodoLists.Queries.GetTodos;

namespace PulseApi.Application.QuoteItems.Queries.GetQuoteItemsWithPagination;
public class QuotesVm
{
    public IReadOnlyCollection<QuoteItemDto> Lists { get; init; } = Array.Empty<QuoteItemDto>();
}
