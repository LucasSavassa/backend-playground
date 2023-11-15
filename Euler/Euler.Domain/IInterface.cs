namespace Euler.Domain
{
    public interface IInterface
    {
        void DisplayProblem(string? message);
        IDictionary<string, string?> PromptInput(string? prompt, IDictionary<string, string?> input);
        void DisplayOutput(string? message, IDictionary<string, int> output);
        void DisplayError(string? message);
        bool PromptContinue();
    }
}
