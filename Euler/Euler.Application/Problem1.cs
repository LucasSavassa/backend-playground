using Euler.Domain;

namespace Euler.Application
{
    internal class Problem1 : IProblem
    {
        public string ProblemMessage =>
            "If we list all the natural numbers below 10 that are multiples of 3 or 5, " +
            "we get 3, 5, 6 and 9. The sum of these multiples is 23." + Environment.NewLine +
            Environment.NewLine +
            "Find the sum of all the multiples of two numbers below a given upper limit.";
        public string InputMessage => "Choose a value for the variables below:";

        public string OutputMessage => $"The sum of all the multiples of {Input["First Multiple"]} or {Input["Second Multiple"]} below {Input["Upper Limit"]} is:";

        public IDictionary<string, int?> Input => new Dictionary<string, int?>()
        {
            { "First Multiple", null },
            { "Second Multiple", null },
            { "Upper Limit", null}
        };

        public IDictionary<string, int> Output { get; private set; } = new Dictionary<string, int>();

        public IDictionary<string, int> Solve(IDictionary<string, int> input)
        {
            int firstMultiple = input["First Multiple"];
            int secondMultiple = input["Second Multiple"];
            int upperLimit = input["Upper Limit"];
            int sum = 0;

            for (int number = 1; number < upperLimit; number++)
            {
                if (number % firstMultiple == 0 || number % secondMultiple == 0)
                {
                    sum += number;
                }
            }

            Output["Sum"] = sum;
            return Output;
        }
    }
}
