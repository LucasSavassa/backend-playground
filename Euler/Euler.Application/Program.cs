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
            userInterface.DisplayProblem(problem.ProblemMessage);
            IDictionary<string, int> input = userInterface.PromptInput(problem.InputMessage, problem.Input);
            IDictionary<string, int> output = problem.Solve(input);
            userInterface.DisplayOutput(problem.OutputMessage, output);
        }
    }
}