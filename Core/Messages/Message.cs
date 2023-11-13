namespace Core.Messages
{
  public abstract class Message
  {
    protected string MessageType { get; set; }

    protected Guid AggregateId { get; set; }

    protected Message()
    {
      MessageType = GetType().Name;
    }
  }
}
