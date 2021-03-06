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

            do
            {
                char choice = GetInput();

                switch (choice)
                {
                    case 'A': AddCharacter(); break;
                    case 'V': ViewCharacter(); break;
                    case 'E': EditCharacter(); break;
                    case 'D': DeleteCharacter(); break;
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
                Console.WriteLine("");
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("A) dd a Character ");
                Console.WriteLine("V) iew your Character ");
                Console.WriteLine("E) dit your Character ");
                Console.WriteLine("D) elete your Character ");
                Console.WriteLine("Q) uit ");

                Console.ForegroundColor = ConsoleColor.Green;
                string choice = Console.ReadLine().Trim();
                Console.ResetColor();
                Console.WriteLine("");

                switch (choice.ToUpper())
                {
                    case "A": return 'A';
                    case "V": return 'V';
                    case "E": return 'E';
                    case "D": return 'D';
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
                newCharacter.Name = NamePicker("Please enter a name for your character: ");
                newCharacter.Profession = JobPicker("Please select an occupation for your character: ");
                newCharacter.Race = RacePicker("Please select a race: ");
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
            } while (true);
        }

        static string NamePicker( string message )
        {
            do
            {
                Console.Write(message);

                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine().Trim();
                Console.ResetColor();

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
                Console.Write("Your occupation: ");

                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine().Trim();
                Console.ResetColor();

                Console.WriteLine("");

                if (!String.IsNullOrEmpty(input))
                {
                    switch (input.ToUpper())
                    {
                        case "WARRIOR": return "Warrior";
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
                Console.Write("Your race: ");

                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine().Trim();
                Console.ResetColor();

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

                Console.WriteLine("");

                if (!String.IsNullOrEmpty(input) || !checker)
                    return input;

                ErrorMessage("Value is required");
            } while (true);
        }

        static void ViewCharacter ()
        {
            if (character == null)
            {
                ErrorMessage("There is no character to view.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-----Adventurer-----");
            Console.WriteLine($"Name:       {character.Name}");
            Console.WriteLine($"Profession: {character.Profession}");
            Console.WriteLine($"Race:       {character.Race}");
            Console.WriteLine($"Biography:  {character.Biography}");
            Console.WriteLine("-----STATS-----");
            Console.WriteLine($"Strength:       {character.Strength}");
            Console.WriteLine($"Intelligence:   {character.Intelligence}");
            Console.WriteLine($"Agility:        {character.Agility}");
            Console.WriteLine($"Constitution:   {character.Constitution}");
            Console.WriteLine($"Charisma:       {character.Charisma}");
            Console.WriteLine("");
            Console.ResetColor();
        }

        static void EditCharacter()
        {
            if (character == null)
            {
                ErrorMessage("There is no character to edit yet.");
                ErrorMessage("Please add a character.");
                AddCharacter();
                Console.WriteLine("");
            }

            do
            {
                Console.WriteLine("Here is your current character's information: ");
                ViewCharacter();
                Console.Write("Type the name of the field you would like to change. You may enter \"Done\" to quit  ");

                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                Console.ResetColor();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (input.ToUpper())
                    {
                        case "NAME": character.Name = NamePicker("Pick a new name: "); break;
                        case "PROFESSION": character.Profession = JobPicker("Pick a new profession: "); break;
                        case "RACE": character.Race = RacePicker("Pick a new race: "); break;
                        case "BIOGRAPHY": character.Biography = BiographyEntry("Enter a biography for your character: ", false); break;
                        case "STRENGTH": character.Strength = ReadInt32("Enter a new value for Strength: ", Character.MinimumValue, Character.MaximumValue); break;
                        case "INTELLIGENCE": character.Intelligence = ReadInt32("Enter a new value for Intelligence: ", Character.MinimumValue, Character.MaximumValue); break;
                        case "AGILITY": character.Agility = ReadInt32("Enter a new value for Agility: ", Character.MinimumValue, Character.MaximumValue); break;
                        case "CONSTITUTION": character.Constitution = ReadInt32("Enter a new value for Constitution: ", Character.MinimumValue, Character.MaximumValue); break;
                        case "CHARISMA": character.Charisma = ReadInt32("Enter a new value for Charisma: ", Character.MinimumValue, Character.MaximumValue); break;
                        case "DONE": return;
                        default: ErrorMessage("Please enter the proper name of the field."); break;
                    }
                } else
                    ErrorMessage("Please enter a valid option.");
            } while (true);
        }

        static void DeleteCharacter ()
        {
            if (character == null)
                ErrorMessage("You have no character to delete!");
            
            if(character != null)
            {
                if (ReadBoolean("Are you sure you want to delete your character? (Y/N)")) 
                {
                    Console.WriteLine("");
                    ErrorMessage("Your character's existence has ceased!");
                    Console.WriteLine("");
                    character = null;
                }
            }
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

                Console.ForegroundColor = ConsoleColor.Green;
                var input = Console.ReadLine();
                Console.ResetColor();

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
