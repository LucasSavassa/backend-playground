using System.Text;
using Assembler.Syntax;

namespace Assembler;

class Assembler()
{
    private readonly List<IRule> rules =
    [
        new Comment(),
        new ACommand(),
        new CCommand(),
    ];

    public string? Assemble(string path)
    {
        if (!IsValid(path))
        {
            return null;
        }

        StringBuilder stringBuilder = new();

        foreach (var line in File.ReadLines(path))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string binary = Parse(line);

            if (string.IsNullOrWhiteSpace(binary))
            {
                continue;
            }

            stringBuilder.Append($"{binary}\n");
        }

        stringBuilder.Remove(stringBuilder.Length - 1, 1);

        return stringBuilder.ToString();
    }

    private static bool IsValid(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            Console.WriteLine("file path cannot be empty.");
            return false;
        }

        if (!File.Exists(path))
        {
            Console.WriteLine($"file does not exist: {path}");
            return false;
        }

        FileInfo file = new(path);

        if (file.Extension != ".asm")
        {
            Console.WriteLine($"file is not an assembly file: {path}");
            return false;
        }

        return true;
    }

    private string Parse(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
        {
            return string.Empty;
        }

        string trimmed = line.Trim();

        IRule? rule = GetRule(trimmed);

        if (rule is null)
        {
            Console.WriteLine($"Invalid line: {line}");
            return string.Empty;
        }

        return rule.Parse(line);
    }

    private IRule? GetRule(string line)
    {
        foreach (IRule rule in rules)
        {
            if (rule.IsMatch(line))
            {
                return rule;
            }
        }

        return null;
    }
}
