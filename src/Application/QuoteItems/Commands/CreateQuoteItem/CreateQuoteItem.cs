using PulseApi.Application.Common.Interfaces;
using PulseApi.Domain.Entities;
using PulseApi.Domain.Events;

namespace PulseApi.Application.QuoteItems.Commands.CreateQuoteItem;

public record CreateQuoteItemCommand : IRequest<int>
{
    public string? Title { get; init; }
    public string? Note { get; init; }
    public string? Author { get; init; }
    public string? Tags { get; init; }
    public string? Source { get; init; }
}

public class CreateQuoteItemCommandValidator : AbstractValidator<CreateQuoteItemCommand>
{
    public CreateQuoteItemCommandValidator()
    {
        RuleFor(v => v.Title)
           .MaximumLength(1024)
           .NotEmpty();
        RuleFor(v => v.Source)
          .MaximumLength(1024)
          .NotEmpty();
    }
}

public class CreateQuoteItemCommandHandler : IRequestHandler<CreateQuoteItemCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateQuoteItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateQuoteItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new QuoteItem
        {            
            Title = request.Title,
            Note = request.Note,
            Author = request.Author,
            Tags = request.Tags,
            Source = request.Source,
        };

        entity.AddDomainEvent(new QuoteItemCreatedEvent(entity));

        _context.QuoteItems.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;      
    }
}
