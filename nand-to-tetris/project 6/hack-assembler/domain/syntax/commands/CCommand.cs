namespace Assembler.Syntax;

class CCommand : IRule
{
    const char destinationSeparator = '=';
    const char jumpSeparator = ';';
    readonly Destination destination = new();
    readonly Computation computation = new();
    readonly Jump jump = new();


    public bool IsMatch(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }

        if (!line.Contains(destinationSeparator) && !line.Contains(jumpSeparator))
        {
            return false;
        }

        line = RemoveComments(line);
        line = ExtractDestinationPart(line, out string destinationPart);
        line = ExtractJumpPart(line, out string jumpPart);
        string computationPart = line;

        return destination.IsMatch(destinationPart) && computation.IsMatch(computationPart) && jump.IsMatch(jumpPart);
    }

    public string Parse(string line)
    {
        if (!IsMatch(line))
        {
            throw new ArgumentException("Invalid C-command");
        }

        line = RemoveComments(line);
        line = ExtractDestinationPart(line, out string destinationPart);
        line = ExtractJumpPart(line, out string jumpPart);
        string computationPart = line;

        return $"{destination.Parse(destinationPart)}{computation.Parse(computationPart)}{jump.Parse(jumpPart)}";
    }

    private static string RemoveComments(string line)
    {
        if (!line.Contains("//"))
        {
            return line;
        }

        string[] parts = line.Split("//", 2);
        return parts[0].Trim();
    }

    private static string ExtractDestinationPart(string line, out string destinationPart)
    {
        if (!line.Contains(destinationSeparator))
        {
            destinationPart = string.Empty;
            return line;
        }

        string[] parts = line.Split(destinationSeparator, 2);
        destinationPart = parts[0];
        return parts[1];
    }

    private static string ExtractJumpPart(string line, out string jumpPart)
    {
        if (!line.Contains(jumpSeparator))
        {
            jumpPart = string.Empty;
            return line;
        }

        string[] parts = line.Split(jumpSeparator, 2);
        jumpPart = parts[1];
        return parts[0];
    }
}