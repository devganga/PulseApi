namespace PulseApi.Domain.Entities;
public class QuoteItem : BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? Note { get; set; }
    public string? Author { get; set; }
    public string? Tags { get; set; }
    public string? Source { get; set; }
}
