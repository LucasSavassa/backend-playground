using Euler.Domain;
using Euler.Presentation;

namespace Euler.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IProblem problem = new Problem1();
            IInterface userInterface = new ConsoleInterface();

            do
            {
                userInterface.DisplayProblem(problem.ProblemMessage);
                IDictionary<string, string?> input = userInterface.PromptInput(problem.InputMessage, problem.Input);
                Stamp stamp = problem.ValidateInput(input);

                if (!stamp.Approved)
                {
                    userInterface.DisplayError(stamp.Message);
                    continue;
                }

                IDictionary<string, int> output = problem.Solve(input);
                userInterface.DisplayOutput(problem.OutputMessage, output);
            } while (userInterface.PromptContinue());
        }
    }
}