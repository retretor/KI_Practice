
namespace KI_Practice.Labs.PolishView.Modules;
public class PolishViewModule
{
    public static string Convert(string? input)
    {
        if (input == null) return input;
        
        string output = "";
        Stack<string> stack = new Stack<string>();
        string lexem = "";
        for(int i = 0; i < input.Length;)
        {
            string prevLexem = lexem;
            lexem = GetLexem(input, ref i);
            if (lexem == " ")
            {
                continue;
            }
            if (lexem == "(")
            {
                stack.Push(lexem);
                continue;
            }
            if (lexem == ")")
            {
                while (stack.Count > 0 && stack.Peek() != "(")
                {
                    output += stack.Pop() + " ";
                }
                if (stack.Count > 0 && stack.Peek() != "(")
                {
                    return "Invalid Expression";
                }
                else
                {
                    stack.Pop();
                }
                continue;
            }

            if (Lexem.IsOperator(lexem))
            {
                if(lexem == "-" && prevLexem != "!" && (prevLexem == "" || Lexem.IsOperator(prevLexem) || prevLexem == "("))
                {
                    lexem = "u-";
                }

                if (Operations.IsRightAssociativity(lexem))
                {
                    while (stack.Count > 0 && Operations.GetPriority(lexem) < Operations.GetPriority(stack.Peek()))
                    {
                        output += stack.Pop() + " ";
                    }
                }
                else
                {
                    while (stack.Count > 0 && Operations.GetPriority(lexem) <= Operations.GetPriority(stack.Peek()))
                    {
                        output += stack.Pop() + " ";
                    }
                }

                stack.Push(lexem);
                continue;
            }
            if (Lexem.IsNumber(lexem))
            {
                output += lexem;
            }
            output += ' ';
        }
        while (stack.Count > 0)
        {
            output += stack.Pop();
            output += ' ';
        }
        output = output.Remove(output.Length - 1);
        return output;
    }

    private static string GetLexem(string input, ref int i)
    {
        string lexem = "";
        if (Lexem.IsOperator(input[i].ToString()))
        {
            lexem += input[i];
            i++;
            return lexem;
        }
        if (input[i] == '(' || input[i] == ')')
        {
            lexem += input[i];
            i++;
            return lexem;
        }
        if (Lexem.IsDigit(input[i]))
        {
            while (i < input.Length && Lexem.IsDigit(input[i]))
            {
                lexem += input[i];
                i++;
            }
            return lexem;
        }
        if (Lexem.IsLetter(input[i]))
        {
            while (i < input.Length && Lexem.IsLetter(input[i]) && !Lexem.IsOperator(lexem))
            {
                lexem += input[i];
                i++;
            }
            return lexem;
        }
        return " ";
    }

    public static string Calculate(string[] inputArray)
    {
        Stack<double> stack = new Stack<double>();

        foreach (string item in inputArray)
        {
            if (double.TryParse(item, out double number))
            {
                stack.Push(number);
            }
            else
            {
                if(Operations.IsBinaryOperator(item))
                {
                    string[] longOperands = {"!", "|", "&", "<<", ">>"};
                    if(longOperands.Contains(item))
                    {
                        long operand2 = (long)stack.Pop();
                        long operand1 = (long)stack.Pop();
                        stack.Push(Operations.CalculateBinaryOperator(item, operand1, operand2));
                    }
                    else
                    {
                        double operand2 = stack.Pop();
                        double operand1 = stack.Pop();
                        stack.Push(Operations.CalculateBinaryOperator(item, operand1, operand2));
                    }
                }
                else
                {
                    double a = stack.Pop();
                    stack.Push(Operations.CalculateUnaryOperator(item, a));
                }
            }
        }
        return stack.Pop().ToString();
    }
}