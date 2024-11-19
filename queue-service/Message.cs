namespace QueueService
{
    public record class Message
    {
        Guid Guid { get; set; }
        DateTimeOffset TimeStamp { get; set; }
        string Content { get; set; } = string.Empty;
    }
}