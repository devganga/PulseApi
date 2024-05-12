using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PulseApi.Application.TodoItems.Queries.GetTodoItemsWithPagination;
using PulseApi.Domain.Entities;

namespace PulseApi.Application.QuoteItems.Queries.GetQuoteItemsWithPagination;
public class QuoteItemDto
{
    public int Id { get; set; }
    public string? Title { get; init; }

    //public bool Done { get; init; }

    //public int Priority { get; init; }

    public string? Note { get; init; }

    public string? Author { get; set; }
    public string? Tags { get; set; }
    public string? Source { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<QuoteItem, QuoteItemDto>();
        }
    }
}
