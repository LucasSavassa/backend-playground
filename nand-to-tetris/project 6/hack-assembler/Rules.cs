namespace Assembler;

static class Rules
{
    public static IRule CCommand(string line)
    {
        Rule rule = new Rule("CCommand", 0);
        return rule;
    }
    public static IRule CCommand(string line)
    {
        throw new NotImplementedException();
    }
}
