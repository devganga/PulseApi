namespace PulseApi.Domain.Events;
public class QuoteItemCreatedEvent : BaseEvent
{
    public QuoteItemCreatedEvent(QuoteItem item)
    {
        Item = item;
    }
    public QuoteItem Item { get; }
}
