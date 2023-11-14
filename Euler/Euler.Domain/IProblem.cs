namespace Euler.Domain
{
    public interface IProblem
    {
        string ProblemMessage { get; }
        string InputMessage { get; }
        string OutputMessage { get; }
        IDictionary<string, int?> Input { get; }
        IDictionary<string, int> Output { get; }
        IDictionary<string, int> Solve(IDictionary<string, int> input);
    }
}
