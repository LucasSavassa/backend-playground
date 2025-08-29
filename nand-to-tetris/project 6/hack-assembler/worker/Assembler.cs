using System.Text;
using Assembler.Extension;
using Assembler.Syntax;

namespace Assembler;

class Assembler()
{
    private readonly Comment commentRule = new Comment();
    private readonly Symbol symbolRule = new Symbol();
    private readonly ACommand aCommand = new ACommand();
    private readonly CCommand cCommand = new CCommand();
    private readonly Label labelRule = new Label();

    public string? Assemble(string path)
    {
        if (!IsValid(path))
        {
            return null;
        }

        List<string> commands = ExtractCommands(path);
        List<string> commandsBinary = Parse(commands);

        return string.Join("\n", commandsBinary);
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

    private List<string> ExtractCommands(string path)
    {
        List<string> commands = [];
        int commandCounter = 0;

        foreach (string line in File.ReadLines(path))
        {
            if (!IsCommand(line))
            {
                continue;
            }

            if (labelRule.IsMatch(line))
            {
                string label = labelRule.GetLabel(line);
                string value = commandCounter.ToBinary();
                symbolRule.AddVariable(label, value);
                continue;
            }

            commandCounter++;
            commands.Add(line);
        }

        return commands;
    }

    private bool IsCommand(string line)
    {
        line = line.Trim();

        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }

        if (commentRule.IsMatch(line))
        {
            return false;
        }

        return true;
    }

    private List<string> Parse(List<string> commands)
    {
        List<string> commandsBinary = [];

        foreach (string line in commands)
        {
            string binary = Parse(line);
            commandsBinary.Add(binary);
        }

        return commandsBinary;
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

        return rule.Parse(trimmed);
    }

    private IRule? GetRule(string line)
    {
        if (symbolRule.IsMatch(line))
        {
            return symbolRule;
        }

        if (aCommand.IsMatch(line))
        {
            return aCommand;
        }

        if (cCommand.IsMatch(line))
        {
            return cCommand;
        }

        return null;
    }
}
