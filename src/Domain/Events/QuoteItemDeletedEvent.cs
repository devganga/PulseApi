namespace PulseApi.Domain.Events;
public class QuoteItemDeletedEvent : BaseEvent
{
    public QuoteItemDeletedEvent(QuoteItem item)
    {
        Item = item;
    }
    public QuoteItem Item { get; }
}
