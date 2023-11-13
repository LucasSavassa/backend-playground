namespace Euler.Domain
{
    public interface IProblem
    {
        string InputMessage { get; }
        string OutputMessage { get; }
        IInput Input { get; }
        IOutput Output { get; }
        IOutput Solve(IInput input);
    }
}
