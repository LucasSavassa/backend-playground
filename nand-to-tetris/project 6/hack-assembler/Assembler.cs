using System.Text;

namespace Assembler;

class Assembler(string path)
{
    public string Assemble()
    {
        if (!TryGetFile(path, out var file) || file is null)
        {
            Console.WriteLine($"assembler failed to get file: {path}");
            return string.Empty;
        }

        StringBuilder stringBuilder = new();

        foreach (var line in File.ReadLines(file.FullName))
        {
            string binary = Parse(line);
            stringBuilder.AppendLine(binary);
        }

        return stringBuilder.ToString();
    }

    private static bool TryGetFile(string path, out FileInfo? file)
    {
        file = null;

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

        file = new FileInfo(path);

        if (file.Extension != ".asm")
        {
            Console.WriteLine($"file is not an assembly file: {path}");
            return false;
        }

        return true;
    }

    private string Parse(string line)
    {
        string trimmed = Trim(line);
        IRule rule = GetRule(trimmed);
        return rule.ToBinary();
    }

    private string Trim(string line)
    {
        throw new NotImplementedException();
    }

    private IRule GetRule(string line)
    {
        throw new NotImplementedException();
    }
}
