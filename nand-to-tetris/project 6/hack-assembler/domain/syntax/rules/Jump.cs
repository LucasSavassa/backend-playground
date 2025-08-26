namespace Assembler.Syntax;

class Jump : IRule
{
    private readonly Dictionary<string, string> rules;

    public Jump()
    {
        rules = new Dictionary<string, string>()
        {
            { "JMP" , "111" },
            { "JLE" , "110" },
            { "JNE" , "101" },
            { "JLT" , "100" },
            { "JGE" , "011" },
            { "JEQ" , "010" },
            { "JGT" , "001" },
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
            throw new ArgumentException($"Invalid jump: {line}");
        }

        return value;
    }
}