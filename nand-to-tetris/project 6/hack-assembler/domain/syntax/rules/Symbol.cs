namespace Assembler.Syntax;

class Symbol : IRule
{
    private readonly Dictionary<string, string> rules;
    private int nextAddress = 16; 

    public Symbol()
    {
        rules = new Dictionary<string, string>()
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

    public void AddRule(string symbol, string value)
    {
        rules[symbol] = value;
    }

    public bool IsMatch(string line)
    {
        throw new NotImplementedException();
    }

    public string Parse(string line)
    {
        throw new NotImplementedException();
    }
}