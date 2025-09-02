using System.Text.RegularExpressions;
using Assembler.Extension;

namespace Assembler.Syntax;

class Symbol : IRule
{
    private const string pattern = @"^@(?'symbol'[A-Za-z].*)$";
    private readonly Dictionary<string, string> predefinedSymbols;
    private readonly Dictionary<string, string> variables = [];
    private int nextAddress = 16; 

    public Symbol()
    {
        predefinedSymbols = new Dictionary<string, string>()
        {
            { "R0"     , "0000000000000000" },
            { "R1"     , "0000000000000001" },
            { "R2"     , "0000000000000010" },
            { "R3"     , "0000000000000011" },
            { "R4"     , "0000000000000100" },
            { "R5"     , "0000000000000101" },
            { "R6"     , "0000000000000110" },
            { "R7"     , "0000000000000111" },
            { "R8"     , "0000000000001000" },
            { "R9"     , "0000000000001001" },
            { "R10"    , "0000000000001010" },
            { "R11"    , "0000000000001011" },
            { "R12"    , "0000000000001100" },
            { "R13"    , "0000000000001101" },
            { "R14"    , "0000000000001110" },
            { "R15"    , "0000000000001111" },
            { "SCREEN" , "0100000000000000" },
            { "KBD"    , "0110000000000000" },
            { "SP"     , "0000000000000000" },
            { "LCL"    , "0000000000000001" },
            { "ARG"    , "0000000000000010" },
            { "THIS"   , "0000000000000011" },
            { "THAT"   , "0000000000000100" }
        };
    }

    public void AddVariable(string name, string addressBinary)
    {
        variables[name] = addressBinary;
    }

    public bool IsMatch(string line)
    {
        line = line.Trim();

        Match match = Regex.Match(line, pattern);

        return match.Success;
    }

    public string Parse(string line)
    {
        line = line.Trim();

        Match match = Regex.Match(line, pattern);

        if (!match.Success)
        {
            throw new ArgumentException($"line is not a symbol: {line}");
        }

        string symbol = match.Groups["symbol"].Value;

        if (predefinedSymbols.TryGetValue(symbol, out string? value))
        {
            return value;
        }

        if (variables.TryGetValue(symbol, out value))
        {
            return value;
        }

        string addressBinary = nextAddress.ToBinary();
        variables[symbol] = addressBinary;
        nextAddress++;
        return addressBinary;
    }
}