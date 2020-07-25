using System.Reflection;
using System;
using UltimateDotNetTools;

namespace UltimateDotNetTools.TestConsole.Tests
{
    public static class StringTests
    {
        private static bool _continueRunning = true;

        public static void RunStringTests()
        {
            while (_continueRunning)
            {
                PrintMainMenu();
                ChooseTest();
            }
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("STRING TESTS");
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"[A] {nameof(TestSafeTrim).SeperateCapitalLetters()}");
            Console.WriteLine("[Z] Return to main menu");
            Console.WriteLine("----------------------------------");
        }

        private static void ChooseTest()
        {
            while (true)
            {
                var input = Console.ReadKey();

                switch (input.KeyChar)
                {
                    case 'A':
                    case 'a':
                        TestSafeTrim();
                        return;

                    case 'Z':
                    case 'z':
                        _continueRunning = false;
                        return;

                    default:
                        Console.WriteLine("This is not a valid option!");
                        break;
                }
            }
        }

        private static void TestSafeTrim()
        {
            Console.Clear();

            Console.WriteLine($"Testing {nameof(TestSafeTrim)}...");

            var test = default(string);
            
            // This is now normal Trim() behaves with nulls
            try
            {
                Console.WriteLine("Testing normal Trim()...");

                var normalTrim = test.Trim();

                if (normalTrim is null || normalTrim.Equals(string.Empty))
                {
                    Console.WriteLine("The normal trim is able to handle nulls");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error was thrown because of {ex.InnerException}");
            }

            // This is how SafeTrim() behaves
            try
            {
                Console.WriteLine("Testing new SafeTrim()...");

                var safeTrim = test.SafeTrim();

                if (safeTrim.Equals(string.Empty))
                {
                    Console.WriteLine("Safe trim retuns an empty string if the original string is null");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error was thrown because of {ex.InnerException}");
            }
        }
    }
}