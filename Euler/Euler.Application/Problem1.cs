using Euler.Domain;

namespace Euler.Application
{
    internal class Problem1 : IProblem
    {
        public string? ProblemMessage =>
            "If we list all the natural numbers below 10 that are multiples of 3 or 5, " +
            "we get 3, 5, 6 and 9. The sum of these multiples is 23." + Environment.NewLine +
            Environment.NewLine +
            "Find the sum of all the multiples of two numbers below a given upper limit.";
        public string? InputMessage => null;

        public string? OutputMessage => $"The sum of all the multiples is:";

        public IDictionary<string, string?> Input => new Dictionary<string, string?>()
        {
            { "First Multiple", null },
            { "Second Multiple", null },
            { "Upper Limit", null}
        };

        public IDictionary<string, int> Output { get; private set; } = new Dictionary<string, int>();

        public Stamp ValidateInput(IDictionary<string, string?> input)
        {
            if (!int.TryParse(input["First Multiple"], out int firstMultiple))
            {
                return new Stamp(false, "First Multiple must be a number.");
            }

            if (firstMultiple <= 1)
            {
                return new Stamp(false, "First Multiple must be greater than 1.");
            }

            if (!int.TryParse(input["Second Multiple"], out int secondMultiple))
            {
                return new Stamp(false, "Second Multiple must be a number.");
            }

            if (secondMultiple <= 1)
            {
                return new Stamp(false, "Second Multiple must be greater than 1.");
            }

            if (!int.TryParse(input["Upper Limit"], out int upperLimit))
            {
                return new Stamp(false, "Upper Limit must be a number.");
            }

            if (upperLimit <= firstMultiple || upperLimit <= secondMultiple)
            {
                return new Stamp(false, "Upper Limit must be greater than both multiples.");
            }

            return new Stamp(true, "Input is valid.");
        }

        public IDictionary<string, int> Solve(IDictionary<string, string?> input)
        {
            int firstMultiple = int.Parse(input["First Multiple"]!);
            int secondMultiple = int.Parse(input["Second Multiple"]!);
            int upperLimit = int.Parse(input["Upper Limit"]!) - 1;
            int commonMultiple = firstMultiple * secondMultiple;

            int firstMax = upperLimit - (upperLimit % firstMultiple);
            int firstCount = (firstMax / firstMultiple) + 1;
            int firstSum = (firstCount * firstMax) / 2;

            int secondMax = upperLimit - (upperLimit % secondMultiple);
            int secondCount = (secondMax / secondMultiple) + 1;
            int secondSum = (secondCount * secondMax) / 2;

            int commonMax = upperLimit - (upperLimit % commonMultiple);
            int commonCount = (commonMax / commonMultiple) + 1;
            int commonSum = (commonCount * commonMax) / 2;

            int sum = firstSum + secondSum - commonSum;
            Output["Sum"] = sum;

            return Output;
        }
    }
}
