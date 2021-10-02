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
        static void Main ( string[] args )
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Mitchel Campozano, ITSE 1430 Adventure Game, Fall 2021");
            Console.WriteLine("------------------------------------------------------");
            Console.ResetColor();

            bool done = false;

            // Test comment

            do
            {
                char choice = GetInput();

                switch (choice)
                {
                    case 'A': AddCharacter(); break;
                    case 'B': break;
                    case 'C': break;
                    case 'Q': done = CheckQuit(); break;
                    default: ErrorMessage("Unknown choice"); break;
                };
            } while (!done);
        }

        static char GetInput ()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("A) dd a Character ");
                Console.WriteLine("B. ");
                Console.WriteLine("C. ");
                Console.WriteLine("Q) uit ");
                Console.ResetColor();

                string choice = Console.ReadLine().Trim();

                switch (choice.ToUpper())
                {
                    case "A": return 'A';
                    case "B": return 'B';
                    case "C": return 'C';
                    case "Q": return 'Q';
                }

                ErrorMessage("Invalid choice.");
            };
        }

        static void AddCharacter ()
        {
            do
            {
                var newCharacter = new Character();
            } while (true);
        }

        static bool CheckQuit ()
        {
            if (ReadBoolean("Are you sure you want to quit? (Y/N)"))
                return true;

            return false;
        }

        static bool ReadBoolean ( string message )
        {
            Console.Write(message);

            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y)
                    return true;
                else if (input.Key == ConsoleKey.N)
                    return false;
            } while (true);
        }

        static void ErrorMessage ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
