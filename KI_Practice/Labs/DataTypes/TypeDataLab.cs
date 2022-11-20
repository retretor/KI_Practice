using KI_Practice.Labs.DataTypes.DataTypes;
namespace KI_Practice.Labs.DataTypes;

public class TypeDataLab
{
    private static MyStack<long> _stackLong;
    private static MyStack<double> _stackDouble;
    private static MyStack<string> _stackString;
    
    private static OnewayList<long> _listLong;
    private static OnewayList<double> _listDouble;
    private static OnewayList<string> _listString;

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
                case 2:
                    ListOperations();
                    break;
                default:
                    break;
            }
        }
    }

    private static void ListOperations()
    {
        bool isActive = true;

        while (isActive)
        {
            int action = ListOperationsMenu();
            
            switch (action)
            {
                case 0:
                    isActive = false;
                    break;
                case 1:
                    CreateList();
                    break;
                case 2:
                    AddToList();
                    break;
                case 3:
                    RemoveFromList();
                    break;
                case 4:
                    GetFromList();
                    break;
                case 5:
                    PrintList();
                    break;
                case 6:
                    DeleteList();
                    break;
                default:
                    break;
            }
        }
    }

    private static void PrintList()
    {
        if(_listLong != null)
        {
            Console.WriteLine("Long list:");
            _listLong.Print();
        }
        if (_listDouble != null)
        {
            Console.WriteLine("Double list:");
            _listDouble.Print();
        }
        if (_listString != null)
        {
            Console.WriteLine("String list:");
            _listString.Print();
        }
    }

    private static void DeleteList()
    {
        if(_listLong != null)
        {
            _listLong = null;
            Console.WriteLine("List of longs deleted");
        }
        if (_listDouble != null)
        {
            _listDouble = null;
            Console.WriteLine("List of doubles deleted");
        }
        if (_listString != null)
        {
            _listString = null;
            Console.WriteLine("List of strings deleted");
        }
    }

    private static void GetFromList()
    {
        if(_listLong != null)
        {
            Console.WriteLine("Enter index of element");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("List element: " + _listLong.Get(index));
        }
        else if(_listDouble != null)
        {
            Console.WriteLine("Enter index of element");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("List element: " + _listDouble.Get(index));
        }
        else if(_listString != null)
        {
            Console.WriteLine("Enter index of element");
            int index = int.Parse(Console.ReadLine());
            Console.WriteLine("List element: " + _listString.Get(index));
        }
        else
        {
            Console.WriteLine("List is not created");
        }
    }

    private static void RemoveFromList()
    {
        if(_listLong != null)
        {
            Console.WriteLine("Enter long value");
            long value = long.Parse(Console.ReadLine());
            _listLong.Remove(value);
        }
        else if(_listDouble != null)
        {
            Console.WriteLine("Enter double value");
            double value = double.Parse(Console.ReadLine());
            _listDouble.Remove(value);
        }
        else if(_listString != null)
        {
            Console.WriteLine("Enter string value");
            string value = Console.ReadLine();
            _listString.Remove(value);
        }
        else
        {
            throw new Exception("List is not created");
        }
    }

    private static void AddToList()
    {
        if(_listLong != null)
        {
            Console.WriteLine("Enter long value");
            long value = long.Parse(Console.ReadLine());
            _listLong.Add(value);
        }
        else if(_listDouble != null)
        {
            Console.WriteLine("Enter double value");
            double value = double.Parse(Console.ReadLine());
            _listDouble.Add(value);
        }
        else if(_listString != null)
        {
            Console.WriteLine("Enter string value");
            string value = Console.ReadLine();
            _listString.Add(value);
        }
        else
        {
            throw new Exception("List is not created");
        }
    }

    private static void CreateList()
    {
        int a = 0;
        while (true)
        {
            Console.WriteLine("Enter a type of list:\n" +
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
                _listLong = new OnewayList<long>();
                break;
            case 2:
                _listDouble = new OnewayList<double>();
                break;
            case 3:
                _listString = new OnewayList<string>();
                break;
            default:
                break;
        }
    }

    private static int ListOperationsMenu()
    {

        Console.WriteLine("Enter an action:\n" +
                          "0. Leave\n" +
                          "1. Create list\n" +
                          "2. Add to list\n" +
                          "3. Remove from list\n" +
                          "4. Get from list\n" +
                          "5. Print list\n" + 
                          "6. Delete list");
        
        int a = Convert.ToInt32(Console.ReadLine());
        return a;
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
                case 5:
                    PrintStack();
                    break;
                default:
                    break;
            }
        }
    }

    private static void PrintStack()
    {
        if (_stackLong != null)
        {
            while(_stackLong.Count > 0)
            {
                Console.WriteLine(_stackLong.Pop() + " ");
            }
        }
        else if (_stackDouble != null)
        {
            while(_stackDouble.Count > 0)
            {
                Console.WriteLine(_stackDouble.Pop() + " ");
            }
        }
        else if (_stackString != null)
        {
            while(_stackString.Count > 0)
            {
                Console.WriteLine(_stackString.Pop() + " ");
            }
        }
        else
        {
            throw new Exception("Stack is not created");
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
                _stackLong = new MyStack<long>();
                break;
            case 2:
                _stackDouble = new MyStack<double>();
                break;
            case 3:
                _stackString = new MyStack<string>();
                break;
            default:
                break;
        }
    }

    private static int MenuAction()
    {
        Console.WriteLine("Enter an action:\n" +
                          "0. Leave\n" +
                          "1. Stack operations\n" +
                          "2. List operations\n");
        
        int a = Convert.ToInt32(Console.ReadLine());
        return a;
    }
}