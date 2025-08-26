namespace Assembler.Syntax;

class Destination : IRule
{
    private readonly Dictionary<string, string> rules;

    public Destination()
    {
        rules = new Dictionary<string, string>
        {
            { "ADM" , "111" },
            { "AD"  , "110" },
            { "AM"  , "101" },
            { "DM"  , "011" },
            { "A"   , "100" },
            { "M"   , "001" },
            { "D"   , "010" },
        };
    }

    public bool IsMatch(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            return true;
        }

        return rules.ContainsKey(line);
    }

    public string Parse(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            return "000";
        }

        if (!rules.TryGetValue(line, out string? value))
        {
            throw new ArgumentException($"Invalid destination: {line}");
        }

        return value;
    }
}