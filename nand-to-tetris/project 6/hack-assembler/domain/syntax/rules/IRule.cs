namespace Assembler.Syntax;

interface IRule
{
    bool IsMatch(string line);
    string Parse(string line);
}