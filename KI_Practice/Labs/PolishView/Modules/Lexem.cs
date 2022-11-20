namespace KI_Practice.Labs.PolishView.Modules;

public class Lexem
{
    public static bool IsLetter(char c)
    {
        string letters = "abcdefghijklmnopqrstuvwxyz<>&|";
        return letters.Contains(c);
    }

    public static bool IsNumber(string c)
    {
        string numbers = "0123456789";
        while (c.Length > 0)
        {
            if (!numbers.Contains(c[0]))
            {
                return false;
            }
            c = c.Substring(1);
        }
        return true;
    }
    public static bool IsDigit(char c)
    {
        string numbers = "0123456789";
        return numbers.Contains(c);
    }
    public static bool IsOperator(string c)
    {
        string[] operators = { "|", "&", "<<", ">>", "+", "-", "*", "/", "%", "^", "sin", "cos", "tan", "sqrt", "sqr", "log", "ln", "abs", "!", "u-" };
        return operators.Contains(c);
    }
}