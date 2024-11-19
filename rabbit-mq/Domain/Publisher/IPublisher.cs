namespace Domain
{
    public interface IPublisher : IDisposable
    {
        string Name { get; }
        Task Publish(string message);
    }
}
