using PulseApi.Application.Common.Interfaces;

namespace PulseApi.Application.QuoteItems.Commands.UpdateQuoteItem;

public record UpdateQuoteItemCommand : IRequest
{
    public int Id { get; init; }
    public string? Title { get; init; }
    public string? Note { get; init; }
    public string? Author { get; init; }
    public string? Tags { get; init; }
    public string? Source { get; init; }
}

public class UpdateQuoteItemCommandValidator : AbstractValidator<UpdateQuoteItemCommand>
{
    public UpdateQuoteItemCommandValidator()
    {
        RuleFor(v => v.Title)
          .MaximumLength(1024)
          .NotEmpty();
        RuleFor(v => v.Source)
          .MaximumLength(10)
          .NotEmpty();
    }
}

public class UpdateQuoteItemCommandHandler : IRequestHandler<UpdateQuoteItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateQuoteItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateQuoteItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.QuoteItems
             .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        entity.Title = request.Title;
        entity.Note = request.Note;
        entity.Author = request.Author;
        entity.Tags = request.Tags;
        entity.Source = request.Source;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
