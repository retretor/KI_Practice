using KI_Practice.Labs;
using KI_Practice.Managers;

namespace KI_Practice
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Main program
            bool isActive = true;
            while (isActive)
            {
                int action = WhichTest();
                
                switch (action)
                {
                    case 0:
                        isActive = false;
                        break;
                    case 1:
                        AlgLab.Run();
                        break;
                    case 2:
                        ArraySorterLab.Run();
                        break;
                    default:
                        break;
                }
            }
        }

        private static int WhichTest()
        {
            Console.WriteLine("Which test do you want to run?");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Algs");
            Console.WriteLine("2 - Array sorts");
            int a = Convert.ToInt32(Console.ReadLine());
            return a;
        }
    }
}