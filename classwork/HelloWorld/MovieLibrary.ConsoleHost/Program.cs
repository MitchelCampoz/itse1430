using System;

namespace MovieLibrary.ConsoleHost
{
    class Program
    {
        // Entry point function
        static void Main(string[] args)
        {
            bool done = false;

            do
            {
                char choice = GetInput();
                //if (choice == 'Q')
                //    done = HandleQuit();
                //else if (choice == 'A')
                //    AddMovie();
                //else if (choice == 'V')
                //    ViewMovie();
                //else if (choice == 'D')
                //    DeleteMovie();
                //else
                //    Console.WriteLine("Unknown option");
                switch (choice)
                {
                    case 'Q': done = HandleQuit(); break;
                    case 'A': AddMovie(); break;
                    case 'V': ViewMovie(); break;
                    case 'D': DeleteMovie(); break;
                    default: DisplayError("Unknown Option"); break;
                };
            } while (!done);
            // TODO: Handle additional stuff
        }

        static void DeleteMovie () 
        {
            if (!ReadBoolean("Are you sure (Y/N)? "))
                return;

            // TODO: Delete movie
            Console.WriteLine("Not implemented");
        }

        static string title;
        static string description;
        static int runLength;
        static int releaseYear;
        static double reviewRating;
        static string rating;
        static bool isClassic;

        static void AddMovie ()
        {
            // Movie Details
            title = ReadString("Enter the Movie Title: ", true);           // Required
            description = ReadString("Enter the optional description: ", false);     // Optional

            runLength = ReadInt32("Enter run length (in minutes): ", 0);          // Option, in minutes, >= 0
            releaseYear = ReadInt32("Enter the release year (min 1900): ", 1900);        // 1900+

            //reviewRating;    // Optional, 0.0 to 5.0
            rating = ReadString("Enter the MPAA rating: ", false);          // MPAA
            isClassic = ReadBoolean("Is this a classic (Y/N)? ");         // Optional
        }

        static void ViewMovie ()
        {
            // TODO: What if they haven't added one yet?
            // TODO: Formatting
            Console.WriteLine(title);
            Console.WriteLine(releaseYear);
            Console.WriteLine(runLength);
            Console.WriteLine(rating);
            Console.WriteLine(isClassic);
            Console.WriteLine(description);
        }

        static int ReadInt32 ( string message, int minimumValue )
        {   
            Console.Write(message);
            
            do
            {
                // string input = Console.ReadLine();
                var input = Console.ReadLine();

                // TODO: Input Validation
                // int result = Int32.Parse(input);    // Crashes program, not good for input
                // int result;
                // if (Int32.TryParse(input, out result))
                //    if(result >= minimumValue)
                //        return result;

                if (Int32.TryParse(input, out var result) && result >= minimumValue)
                    return result;

                DisplayError("The value must be an integral value >= " + minimumValue);
            }while (true);

            //return -1;
        }

        static string ReadString ( string message, bool required )
        {
            Console.Write(message);

            do
            {   
                
                string input = Console.ReadLine();

                // TODO: Input Validation - required, normalize

                return input;
            } while (true);
        }

        static void DisplayError( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static bool HandleQuit ()
        {
            // Display a confirmation
            if (ReadBoolean("Are you Sure you want to quit(Y/N)? "))
                return true;

            return false;

            // Shortcut of below code
            // return ReadBoolean("Are you sure you want to quit(Y/N)?");
        }

        private static bool ReadBoolean ( string message )
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

            // return false;        NOT NEEDED ANYMORE
        }

        static char GetInput ()
        {
            Console.WriteLine("Movie Library");
            Console.WriteLine("---------------");

            Console.WriteLine("A) dd");
            Console.WriteLine("V) iew");
            Console.WriteLine("D) elete");
            Console.WriteLine("Q) uit");

            while (true)
            {
                // Get input
                string input = Console.ReadLine();
                /*if (input == "Q")
                    return 'Q';
                else if (input == "A")
                    return 'A';
                else if (input == "V")
                    return 'V';
                else if (input == "D")
                    return 'D';*/
                switch (input)
                {
                    case "q":
                    case "Q": return 'Q';
                    
                    case "a":
                    case "A": return 'A';
                    
                    case "v":
                    case "V": return 'V';
                    
                    case "d":
                    case "D": return 'D';
                    //default;
                };

                DisplayError("Invalid input");
            };
            //return default(char);   // default
        }
    }
}
