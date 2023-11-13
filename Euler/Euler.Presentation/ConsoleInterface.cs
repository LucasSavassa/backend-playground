using Euler.Domain;
using System.Text;

namespace Euler.Presentation
{
    public class ConsoleInterface : IInterface
    {
        public ConsoleInterface()
        {
        }

        public IInput PromptInput(string message, IInput input)
        {
            Console.WriteLine(message);
            Console.WriteLine();
            foreach (string key in input.Keys)
            {
                Console.Write($"What is {key}: ");
                string? value = Console.ReadLine()?.Trim();
                input[key] = value;
            }
            return input;
        }

        public void DisplayOutput(string message, IOutput output)
        {
            Console.WriteLine(message);
            Console.WriteLine();
            foreach (string key in output.Keys)
            {
                Console.WriteLine($"{key}: {output[key]}");
            }
        }
    }
}