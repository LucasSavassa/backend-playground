namespace Euler.Domain
{
    public interface IProblem
    {
        string? ProblemMessage { get; }
        string? InputMessage { get; }
        string? OutputMessage { get; }
        IDictionary<string, string?> Input { get; }
        IDictionary<string, int> Output { get; }
        Stamp ValidateInput(IDictionary<string, string?> input);
        IDictionary<string, int> Solve(IDictionary<string, string?> input);
    }
}
