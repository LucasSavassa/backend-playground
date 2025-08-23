namespace Assembler;

interface IRule
{
    string Name { get; }
    string ToBinary();
}