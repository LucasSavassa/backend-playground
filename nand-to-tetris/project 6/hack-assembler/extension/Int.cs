namespace Assembler.Extension;

static class Int
{
    public static string ToBinary(this int value)
    {
        return Convert.ToString(value, 2).PadLeft(16, '0');
    }
}