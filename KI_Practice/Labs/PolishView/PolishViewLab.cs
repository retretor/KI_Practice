using KI_Practice.Labs.PolishView.Modules;
namespace KI_Practice.Labs.PolishView;

public class PolishViewLab
{
    public static void Run()
    {
        // Main program
        bool isActive = true;
        string input = "";

        while (isActive)
        {
            int action = MenuAction();

            switch (action)
            {
                case 0:
                    isActive = false;
                    break;
                case 1:
                    input = StringToPolishView();
                    Console.WriteLine("In Polish View: " + input);
                    Calculate(input);
                    break;
                case 2:
                    Calculate(input);
                    break;
                case 3:
                    Calculate(StringToPolishView());
                    break;
                default:
                    break;
            }
        }
    }

    private static void Calculate(string input)
    {
        string[] inputArray = input.Split(' ');
        for (int i = 0; i < inputArray.Length; i++)
        {
            inputArray[i] = inputArray[i].Trim();
        }
        string result = PolishViewModule.Calculate(inputArray);
        Console.WriteLine($"Result: {result}");
    }

    private static string StringToPolishView()
    {
        Console.WriteLine("Enter string:");
        string input = Console.ReadLine()!;
        input = input.Replace(" ", "");
        return PolishViewModule.Convert(input);
    }

    private static int MenuAction()
    {
        Console.WriteLine("Enter an action:\n" +
                          "0. Leave\n" +
                          "1. Calculate\n");
        int a = Convert.ToInt32(Console.ReadLine());
        return a;
    }
}