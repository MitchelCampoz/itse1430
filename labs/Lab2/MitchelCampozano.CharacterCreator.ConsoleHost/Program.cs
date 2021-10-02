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
            var newCharacter = new Character();
            
            do
            {
                newCharacter.Name = NamePicker("Please enter a name for your character: ", false);
                newCharacter.Profession = JobPicker("Please select a valid occupation for your character: ");
                newCharacter.Race = RacePicker("Please select a valid race: ");
            } while (true);
        }

        static string NamePicker( string message, bool checker )
        {
            Console.Write(message);

            do
            {
                string input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input) || !checker)
                    return input;

                ErrorMessage("Value is required");
            } while (true);
        }

        static string JobPicker ( string message )
        {
            do
            {
                Console.WriteLine(message);
                Console.WriteLine("Warrior");
                Console.WriteLine("Cleric");
                Console.WriteLine("Ranger");
                Console.WriteLine("Rogue");
                Console.WriteLine("Wizard");

                string input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (input.ToUpper())
                    {
                        case "WARRIOR": return "WARRIOR";
                        case "CLERIC": return "Cleric";
                        case "RANGER": return "Ranger";
                        case "ROGUE": return "Rogue";
                        case "WIZARD": return "Wizard";
                        default: ErrorMessage("Invalid Input. Please select again."); break;
                    }
                } else
                    ErrorMessage("Value is required");
            } while (true);
        }

        static string RacePicker ( string message )
        {
            do
            {
                Console.WriteLine(message);
                Console.WriteLine("Dwarf");
                Console.WriteLine("Orc");
                Console.WriteLine("Elf");
                Console.WriteLine("Hobbit");
                Console.WriteLine("Human");
                
                string input = Console.ReadLine().Trim();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (input.ToUpper())
                    {
                        case "DWARF": return "Dwarf";
                        case "ORC": return "Orc";
                        case "ELF": return "Elf";
                        case "HOBBIT": return "Hobbit";
                        case "HUMAN": return "Human";
                        default: ErrorMessage("Invalid Input. Please select again."); break;
                    }
                }
                else
                    ErrorMessage("Value is required");
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
