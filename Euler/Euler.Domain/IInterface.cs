namespace Euler.Domain
{
    public interface IInterface
    {
        void DisplayProblem(string message);
        IDictionary<string, int> PromptInput(string prompt, IDictionary<string, int?> input);
        void DisplayOutput(string message, IDictionary<string, int> output);
    }
}
