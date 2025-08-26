namespace Assembler.Syntax;

class Comment : IRule
{
    public bool IsMatch(string line)
    {
        return line.StartsWith("//");
    }

    public string Parse(string line)
    {
        return string.Empty;
    }
}