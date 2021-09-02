using System;

namespace MovieLibrary.ConsoleHost
{
    class Program
    {
        // Entry point function
        static void Main(string[] args)
        {
            bool done = false;

            char choice = GetInput();
            if (choice == 'Q')
                done = HandleQuit();
            else if (choice == 'A')
                AddMovie();
            else
                Console.WriteLine("Unknown option");
            // TODO: Handle additional stuff
        }

        static void AddMovie ()
        {
            // Movie Details
            string title = ReadString("Enter the Movie Title: ", true);           // Required
            string description = ReadString("Enter the optional description: ", false);     // Optional

            int runLength = ReadInt32("Enter run length (in minutes): ", 0);          // Option, in minutes, >= 0
            int releaseYear = ReadInt32("Enter the release year (min 1900): ", 1900);        // 1900+

            double reviewRating;    // Optional, 0.0 to 5.0
            string rating = ReadString("Enter the MPAA rating: ", false);          // MPAA
            bool isClassic;         // Optional
        }

        static int ReadInt32 ( string message, int minimumValue )
        {
            Console.Write(message);

            string input = Console.ReadLine();

            // TODO: Input Validation
            //int result = Int32.Parse(input);    // Crashes program, not good for input
            int result;
            if (Int32.TryParse(input, out result))
                return result;

            return -1;
        }

        static string ReadString ( string message, bool required )
        {
            Console.Write(message);

            // TODO: Input Validation - required, normalize
            string input = Console.ReadLine();

            return input;
        }

        static bool HandleQuit ()
        {
            // Display a confirmation
            if (ReadBoolean("Are you Sure you want to quit(Y/N)? "))
                return true;

            return false;
        }

        private static bool ReadBoolean ( string message )
        {
            Console.Write(message);

            ConsoleKeyInfo input = Console.ReadKey();
            if (input.Key == ConsoleKey.Y)
                return true;

            // TODO: Input Validation
            return false;
        }

        static char GetInput ()
        {
            Console.WriteLine("Movie Library");
            Console.WriteLine("---------------");

            Console.WriteLine("A) dd");
            Console.WriteLine("Q) uit");

            // TODO: Input Validation
            // Get input
            string input = Console.ReadLine();
            if (input == "Q")
                return 'Q';
            else if (input == "A")
                return 'A';

            return default(char);   // default
        }
    }
}
