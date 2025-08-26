using System.Reflection;

namespace Assembler;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("no command provided. use 'help' for usage information.");
            return;
        }

        switch (args[0])
        {
            case "assemble":
                HandleArgsAssemble(args);
                break;
            case "help":
                PrintHelp();
                break;
            default:
                Console.WriteLine($"invalid command '{args[0]}'. use 'help' for usage information.");
                break;
        }
    }

    private static void PrintHelp()
    {
        Console.WriteLine($"usage: {Assembly.GetExecutingAssembly().GetName().Name} assemble <full-path>");
        Console.WriteLine("assemble .asm file found in <full-path>");
    }

    private static void HandleArgsAssemble(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("no file provided. use 'assemble --help' for usage information.");
            return;
        }

        switch (args[1])
        {
            case "--help":
                PrintHelp();
                break;
            default:
                HandleAssemble(args[1]);
                break;
        }
    }

    private static void HandleAssemble(string path)
    {
        Assembler assembler = new();
        string? assembly = assembler.Assemble(path);
        string outputPath = Path.ChangeExtension(path, ".hack");
        File.WriteAllText(outputPath, assembly ?? string.Empty);
        Console.WriteLine($"binary file: {outputPath}");
    }
}