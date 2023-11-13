namespace Euler.Domain
{
    public interface IInterface
    {
        IInput PromptInput(string prompt, IInput input);
        void DisplayOutput(string message, IOutput output);
    }
}
