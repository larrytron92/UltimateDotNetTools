using System.Linq.Expressions;
using System.Reflection.Emit;
using System;
using UltimateDotNetTools.TestConsole.Tests;

namespace UltimateDotNetTools.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("------------------------------");
                Console.WriteLine("Welcome to the testing console");
                Console.WriteLine("------------------------------");
                Console.WriteLine();

                PrintMenu();

                var endProgram = SelectionOption();

                if (endProgram)
                {
                    break;
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("[A] String Tests");
            Console.WriteLine("[Z] End Program");
            Console.WriteLine("------------------------------");
        }

        static bool SelectionOption()
        {
            while (true)
            {
                var option = Console.ReadKey();

                switch (option.KeyChar)
                {
                    case 'A':
                    case 'a':
                        StringTests.RunStringTests();
                        return false;

                    case 'Z':
                    case 'z':
                        return true;

                    default:
                        Console.WriteLine("Not a valid option!");
                        continue;
                }
            }
        }
    }
}
