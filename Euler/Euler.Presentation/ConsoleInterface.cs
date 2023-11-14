using Euler.Domain;

namespace Euler.Presentation
{
    public class ConsoleInterface : IInterface
    {
        public ConsoleInterface() { }

        public void DisplayProblem(string message)
        {
            try
            {
                Console.WriteLine(message);
                Console.WriteLine();
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
                throw;
            }
        }

        public IDictionary<string, int> PromptInput(string message, IDictionary<string, int?> input)
        {
            Dictionary<string, int> inputFilled = new();
            try
            {
                Console.WriteLine(message);
                Console.WriteLine();
                foreach (string key in input.Keys)
                {
                    inputFilled[key] = PromptInput(key);
                }
                return inputFilled;
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
                throw;
            }
        }

        public void DisplayOutput(string message, IDictionary<string, int> output)
        {
            try
            {
                Console.WriteLine(message);
                Console.WriteLine();
                foreach (string key in output.Keys)
                {
                    Console.WriteLine($"{key}: {output[key]}");
                }
            }
            catch (Exception exception)
            {
                DisplayError(exception.Message);
                throw;
            }
        }

        private static void DisplayError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("An error occurred while displaying the problem.");
            Console.WriteLine(message);
            Console.ReadKey();
            Console.ResetColor();
        }

        private static int PromptInput(string key)
        {
            Console.Write($"Choose a value for [{key}]: ");
            string? value = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(key, "Input cannot be null.");
            if (!int.TryParse(value, out int result)) throw new ArgumentException("Input must be an integer.", key);
            return result;
        }
    }
}