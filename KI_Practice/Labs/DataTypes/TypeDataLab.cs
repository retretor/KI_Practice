namespace KI_Practice.Labs.DataTypes;

public class TypeDataLab
{
    private static Stack<long>? _stackLong = null;
    private static Stack<double>? _stackDouble = null;
    private static Stack<string>? _stackString = null;
    
    public static void Run()
    {
        // Main program
        bool isActive = true;

        while (isActive)
        {
            int action = MenuAction();

            switch (action)
            {
                case 0:
                    isActive = false;
                    break;
                case 1:
                    StackOperations();
                    break;
                default:
                    break;
            }
        }
    }

    private static void StackOperations()
    {
        bool isActive = true;

        while (isActive)
        {
            int action = StackAction();
            
            switch (action)
            {
                case 0:
                    isActive = false;
                    break;
                case 1:
                    CreateStack();
                    break;
                case 2:
                    Push();
                    break;
                case 3:
                    Pop();
                    break;
                case 4:
                    DeleteStack();
                    break;
                default:
                    break;
            }
        }
    }

    private static void Pop()
    {
        if (_stackLong != null)
        {
            Console.WriteLine("Pop long: " + _stackLong.Pop());
        }
        else if (_stackDouble != null)
        {
            Console.WriteLine("Pop double: " + _stackDouble.Pop());
        }
        else if (_stackString != null)
        {
            Console.WriteLine("Pop string: " + _stackString.Pop());
        }
        else
        {
            throw new Exception("Stack is not created");
        }
    }

    private static void Push()
    {
        if(_stackLong != null)
        {
            Console.WriteLine("Enter long value");
            long value = long.Parse(Console.ReadLine());
            _stackLong.Push(value);
        }
        else if(_stackDouble != null)
        {
            Console.WriteLine("Enter double value");
            double value = double.Parse(Console.ReadLine());
            _stackDouble.Push(value);
        }
        else if(_stackString != null)
        {
            Console.WriteLine("Enter string value");
            string value = Console.ReadLine();
            _stackString.Push(value);
        }
        else
        {
            throw new Exception("Stack is not created");
        }
    }

    private static void DeleteStack()
    {
        if(_stackLong != null) _stackLong = null;
        
        if(_stackDouble != null) _stackDouble = null;
        
        if(_stackString != null) _stackString = null;
    }

    private static int StackAction()
    {
        Console.WriteLine("Enter an action:\n" +
                          "0. Leave\n" +
                          "1. Create stack\n" +
                          "2. Push\n" +
                          "3. Pop\n" +
                          "4. Delete stack");
        
        int a = Convert.ToInt32(Console.ReadLine());
        return a;
    }

    private static void CreateStack()
    {
        int a = 0;
        while (true)
        {
            Console.WriteLine("Enter a type of stack:\n" +
                                      "1. Long\n" +
                                      "2. Double\n" +
                                      "3. String");
            a = Convert.ToInt32(Console.ReadLine());
            if (a != 1 && a != 2 && a != 3)
            {
                Console.WriteLine("Wrong input");
                continue;
            }
            break;
        }
        
        switch (a)
        {
            case 1:
                _stackLong = new Stack<long>();
                break;
            case 2:
                _stackDouble = new Stack<double>();
                break;
            case 3:
                _stackString = new Stack<string>();
                break;
            default:
                break;
        }
    }

    private static int MenuAction()
    {
        Console.WriteLine("Enter an action:\n" +
                          "0. Leave\n" +
                          "1. Stack operations\n");
        
        int a = Convert.ToInt32(Console.ReadLine());
        return a;
    }
}