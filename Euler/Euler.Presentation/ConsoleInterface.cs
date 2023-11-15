using Euler.Domain;

namespace Euler.Presentation
{
    public class ConsoleInterface : IInterface
    {
        public ConsoleInterface() { }

        public void DisplayProblem(string? message)
        {
            Console.Clear();
            try
            {
                DisplayMessage(message);
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
                throw;
            }
        }

        public IDictionary<string, string?> PromptInput(string? message, IDictionary<string, string?> input)
        {
            Dictionary<string, string?> inputFilled = new();

            try
            {
                DisplayMessage(message);

                foreach (string key in input.Keys)
                {
                    inputFilled[key] = PromptInput(key);
                }

                Console.WriteLine();

                return inputFilled;
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
                throw;
            }
        }

        public void DisplayOutput(string? message, IDictionary<string, int> output)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                DisplayMessage(message);

                foreach (string key in output.Keys)
                {
                    Console.WriteLine($"{key}: {output[key]}");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
                throw;
            }
        }

        public void DisplayError(string? message)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred while displaying the problem.");
            Console.WriteLine(message);
            Console.Write("Type any key to continue...");
            Console.ReadKey();
            Console.ResetColor();
        }

        public bool PromptContinue()
        {
            Console.Write("Would you like to continue? [Y/N]: ");
            string? input = Console.ReadLine()?.Trim().ToLower();
            return string.IsNullOrWhiteSpace(input) || input == "y" || input == "yes";
        }

        private static void DisplayMessage(string? message)
        {
            if (message is not null)
            {
                Console.WriteLine(message);
                Console.WriteLine();
            }
        }

        private static string? PromptInput(string key)
        {
            Console.Write($"Choose a value for [{key}]: ");
            string? value = Console.ReadLine()?.Trim();
            return value;
        }
    }
}