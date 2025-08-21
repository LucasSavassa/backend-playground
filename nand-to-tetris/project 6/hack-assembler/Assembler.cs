namespace Assembler;

class Assembler(string path)
{
    public string Assemble()
    {
        // Here you would add the logic to handle the assembly of the file.
        Console.WriteLine($"Assembling file: {path}");

        return "path to compiled file";
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
}
