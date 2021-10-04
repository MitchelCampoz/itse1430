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
                    case 'V': ViewCharacter(); break;
                    case 'E': EditCharacter(); break;
                    case 'Q': done = CheckQuit(); break;
                    default: ErrorMessage("Unknown choice"); break;
                };
            } while (!done);
        }

        static Character character;

        static char GetInput ()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("A) dd a Character ");
                Console.WriteLine("V) iew your Character ");
                Console.WriteLine("E) dit your Character ");
                Console.WriteLine("Q) uit ");
                Console.ResetColor();

                string choice = Console.ReadLine().Trim();

                switch (choice.ToUpper())
                {
                    case "A": return 'A';
                    case "V": return 'V';
                    case "E": return 'E';
                    case "Q": return 'Q';
                }

                ErrorMessage("Invalid choice.");
            };
        }

        static void AddCharacter ()
        {
            bool loopEnder = false;
            var newCharacter = new Character();
            
            do
            {
                newCharacter.Name = NamePicker("Please enter a name for your character: ");
                newCharacter.Profession = JobPicker("Please select a valid occupation for your character: ");
                newCharacter.Race = RacePicker("Please select a valid race: ");
                newCharacter.Biography = BiographyEntry("Tell us a little about your character (if you want): ", false);
                Console.WriteLine("You will now enter the values for your skills: ");
                newCharacter.Strength = ReadInt32("Please enter a value for your Strength: ", Character.MinimumValue, Character.MaximumValue);
                newCharacter.Intelligence = ReadInt32("Please enter a value for your Intelligence: ", Character.MinimumValue, Character.MaximumValue);
                newCharacter.Agility = ReadInt32("Please enter a value for your Agility: ", Character.MinimumValue, Character.MaximumValue);
                newCharacter.Constitution = ReadInt32("Please enter a value for your Constitution: ", Character.MinimumValue, Character.MaximumValue);
                newCharacter.Charisma = ReadInt32("Please enter a value for your Charisma: ", Character.MinimumValue, Character.MaximumValue);

                var error = newCharacter.Validator();

                if (String.IsNullOrEmpty(error))
                {
                    character = newCharacter;
                    return;
                }

                loopEnder = true;
            } while (!loopEnder);
        }

        static string NamePicker( string message )
        {
            do
            {
                Console.Write(message);

                string input = Console.ReadLine().Trim();

                Console.WriteLine("");

                if (!String.IsNullOrEmpty(input))
                    return input;
                else
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

                Console.WriteLine("");

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

                Console.WriteLine("");

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

        static string BiographyEntry ( string message, bool checker )
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

        static void ViewCharacter ()
        {
            if (character == null)
            {
                Console.WriteLine("There is no character to view.");
                return;
            }

            Console.WriteLine("-----Adventurer-----");
            Console.WriteLine($"Name: {character.Name}");
            Console.WriteLine($"Profession: {character.Profession}");
            Console.WriteLine($"Race: {character.Race}");
            Console.WriteLine($"Biography: {character.Biography}");
            Console.WriteLine("-----STATS-----");
            Console.WriteLine($"Strength: {character.Strength}");
            Console.WriteLine($"Intelligence: {character.Intelligence}");
            Console.WriteLine($"Agility: {character.Agility}");
            Console.WriteLine($"Constitution: {character.Constitution}");
            Console.WriteLine($"Charisma: {character.Charisma}");
        }

        static void EditCharacter()
        {
            if (character == null)
            {
                Console.WriteLine("There is no character to edit yet.");
                Console.WriteLine("Please add a character.");

                AddCharacter();
            }

            do
            {
                Console.WriteLine("Here is your current character's information: ");
                ViewCharacter();
                Console.WriteLine("What would you like to change?");
                string input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "NAME": character.Name = NamePicker("Pick a new name: "); break;
                    case "PROFESSION": character.Profession = JobPicker("Pick a new profession: "); break;
                    case "RACE": character.Race = RacePicker("Pick a new race: "); break;
                    case "BIOGRAPHY": character.Biography = BiographyEntry("Enter a biography for your character: ", false); break;
                    case "STRENGTH": character.Strength = ReadInt32("Enter a new Strength value: ", Character.MinimumValue, Character.MaximumValue); break;
                    case "INTELLIGENCE": character.Intelligence = ReadInt32("Enter a new Intelligence value: ", Character.MinimumValue, Character.MaximumValue); break;
                    case "AGILITY": character.Agility = ReadInt32("Enter a new Agility value: ", Character.MinimumValue, Character.MaximumValue); break;
                    case "CONSTITUTION": character.Constitution = ReadInt32("Enter a new Constitution value: ", Character.MinimumValue, Character.MaximumValue); break;
                    case "CHARISMA": character.Charisma = ReadInt32("Enter a new Charisma value: ", Character.MinimumValue, Character.MaximumValue); break;
                }       
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

        static int ReadInt32 ( string message, int minimumValue, int maximumValue )
        {   
            do
            {
                Console.Write(message);

                var input = Console.ReadLine();

                if (Int32.TryParse(input, out var result) && result >= minimumValue && result <= maximumValue)
                    return result;

                ErrorMessage($"Your input must be between {minimumValue} and {maximumValue}. Please try again.");
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
