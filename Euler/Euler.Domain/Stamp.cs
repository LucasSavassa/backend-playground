namespace Euler.Domain
{
    public record struct Stamp
    {
        public bool Approved { get; set; }
        public string? Message { get; set; }

        public Stamp(bool approved, string? message)
        {
            Approved = approved;
            Message = message;
        }
    }
}
