/*
 * Adventure Game Lab
 * Mitchel Campozano
 * ITSE 1430 Fall 2021
*/
using System;

namespace MitchelCampozano.CharacterCreator.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Mitchel Campozano, ITSE 1430 Adventure Game, Fall 2021");
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();
        }

        static char MainMenu ()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("A. ");
                Console.WriteLine("B. ");
                Console.WriteLine("C. ");
                Console.WriteLine("D. ");
                Console.ResetColor();

                string choice = Console.ReadLine().Trim();

                switch (choice.ToUpper())
                {
                    case "A": return 'A';
                    case "B": return 'B';
                    case "C": return 'C';
                    case "D": return 'D';
                    default: Console.WriteLine("Wrong choice"); break;
                }
            };
        }
    }
}
