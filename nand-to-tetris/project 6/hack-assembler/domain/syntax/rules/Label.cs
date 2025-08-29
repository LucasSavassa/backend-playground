using System.Text.RegularExpressions;

namespace Assembler.Syntax;

class Label : IRule
{
    const string pattern = @"^\((?'label'\w+)\)$";

    public bool IsMatch(string line)
    {
        return Regex.IsMatch(line, pattern);
    }

    public string Parse(string line)
    {
        return string.Empty;
    }
    
    public string GetLabel(string line)
    {
        Match match = Regex.Match(line, pattern);

        if (!match.Success)
        {
            throw new ArgumentException($"line is not a label: {line}");
        }

        if (!match.Groups.ContainsKey("label"))
        {
            throw new ArgumentException($"the label is empty: {line}");
        }

        return match.Groups["label"].Value;
    }
}