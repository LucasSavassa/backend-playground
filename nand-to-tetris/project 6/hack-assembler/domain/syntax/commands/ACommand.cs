namespace Assembler.Syntax;

class ACommand : IRule
{
    public bool IsMatch(string line)
    {
        if (!line.StartsWith('@'))
        {
            return false;
        }

        if (!int.TryParse(line[1..], out int number))
        {
            return false;
        }

        if (number < 0)
        {
            return false;
        }

        if (number > 32767)
        {
            return false;
        }

        return true;
    }

    public string Parse(string line)
    {
        if (!IsMatch(line))
        {
            throw new ArgumentException($"Invalid A-command: {line}");
        }

        int address = int.Parse(line[1..]);

        return Convert.ToString(address, 2);
    }
}