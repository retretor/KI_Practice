namespace KI_Practice.Labs.PolishView.Modules;

public class Operations
{
    public static int GetPriority(string p0)
    {
        string[] priority0 = { "|", "&" };
        string[] priority1 = { "<<", ">>" };
        string[] priority2 = { "+", "-" };
        string[] priority3 = { "*", "/", "%" };
        string[] priority4 = { "u-", "sin", "cos", "tan", "sqrt", "sqr", "log", "ln", "abs" };
        string[] priority5 = { "^" };
        string[] priority6 = { "!" };
        
        if (priority0.Contains(p0)) return 0;
        if (priority1.Contains(p0)) return 1;
        if (priority2.Contains(p0)) return 2;
        if (priority3.Contains(p0)) return 3;
        if (priority4.Contains(p0)) return 4;
        if (priority5.Contains(p0)) return 5;
        if (priority6.Contains(p0)) return 6;
        return -1;
    }
    public static double CalculateUnaryOperator(string item, double a)
    {
        return item switch
        {
            "sin" => Math.Sin(a),
            "cos" => Math.Cos(a),
            "tan" => Math.Tan(a),
            "sqrt" => Math.Sqrt(a),
            "sqr" => Math.Pow(a, 2),
            "log" => Math.Log10(a),
            "ln" => Math.Log(a),
            "abs" => Math.Abs(a),
            "!" => Factorial((long)a),
            "u-" => -a,
            _ => throw new Exception("Unknown operator"),
        };
    }

    private static long Factorial(long a)
    {
        long b = 1;
        for (int i = 1; i <= a; i++)
        {
            b *= i;
        }
        return b;
    }

    public static double CalculateBinaryOperator(string item, double a, double b)
    {
        return item switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => a / b,
            "%" => a % b,
            "^" => Math.Pow(a, b),
            _ => 0
        };
    }
    public static long CalculateBinaryOperator(string item, long a, long b)
    {
        return item switch
        {
            "|" => a | b,
            "&" => a & b,
            "<<" => a << (int)b,
            ">>" => a >> (int)b,
            _ => 0
        };
    }
    public static bool IsBinaryOperator(string item)
    {
        string[] operators = { "+", "-", "*", "/", "%", "^", "|", "&", "<<", ">>" };
        return operators.Contains(item);
    }

    public static bool IsRightAssociativity(string item)
    {
        string[] operators = { "u-", "sin", "cos", "tan", "sqrt", "sqr", "log", "ln", "abs" };
        return operators.Contains(item);
    }
}