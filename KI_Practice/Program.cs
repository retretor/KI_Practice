using KI_Practice.Labs;
using KI_Practice.Labs.Alg;
using KI_Practice.Labs.ArraySorts;
using KI_Practice.Labs.DataTypes;
using KI_Practice.Labs.PolishView;
using KI_Practice.Managers;

namespace KI_Practice
{
    static class Program
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
                    case 3:
                        TypeDataLab.Run();
                        break;
                    case 4:
                        PolishViewLab.Run();
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
            Console.WriteLine("1 - Algorithms");
            Console.WriteLine("2 - Array sorts");
            Console.WriteLine("3 - Data types");
            Console.WriteLine("4 - Polish view calculator");

            int a = Convert.ToInt32(Console.ReadLine());
            return a;
        }
    }
}