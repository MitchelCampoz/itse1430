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

        static Movie movie;// = new Movie();

        static void DeleteMovie () 
        {
            if (movie == null)
                return;
            // var newMovie = movie.Copy();


            if (!ReadBoolean("Are you sure (Y/N)? "))
                return;

            movie = null;
            
        }

        static void AddMovie ()
        {
            var newMovie = new Movie(10, "temp");
            do
            {
                // Movie Details
                // newMovie.set_Title(...)
                newMovie.Title = ReadString("Enter the Movie Title: ", false);           // Required
                newMovie.Description = ReadString("Enter the optional description: ", false);     // Optional

                newMovie.RunLength = ReadInt32("Enter run length (in minutes): ", 0);          // Option, in minutes, >= 0
                newMovie.ReleaseYear = ReadInt32("Enter the release year (min 1900): ", Movie.MinimumReleaseYear);        // 1900+

                //reviewRating;    // Optional, 0.0 to 5.0
                newMovie.Rating = ReadString("Enter the MPAA rating: ", false);          // MPAA
                newMovie.IsClassic = ReadBoolean("Is this a classic (Y/N)? ");         // Optional

                // Validate
                var error = newMovie.Validate();
                if (String.IsNullOrEmpty(error))
                {
                    movie = newMovie;
                    return;
                }
                
                DisplayError(error);

            } while (true);
        }

        static void ViewMovie ()
        {
            // TODO: What if they haven't added one yet?
            if (movie == null)
            {
                Console.WriteLine("No Movie Available");
                return;
            };

            // TODO: Formatting
            // movie.get_Title()
            Console.WriteLine($"{movie.Title} ({movie.ReleaseYear})");
            Console.WriteLine($"Runtime: {movie.RunLength} mins");
            Console.WriteLine($"Rating: {movie.Rating}");
            Console.WriteLine($"Classic? {movie.IsClassic}");
            Console.WriteLine(movie.Description);

            if (movie.AgeInYears >= 25)
                Console.WriteLine($"{movie.AgeInYears}th anniversary.");
            //movie.AgeInYears = 10;
        }

        /// <summary>
        /// Validates integer input from a string
        /// </summary>
        /// <param name="message">The message to display</param>
        /// <param name="minimumValue">The minimum value allowed</param>
        /// <returns>
        /// The integral value that was entered
        /// </returns>
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
                string input = Console.ReadLine().Trim();

                if(!String.IsNullOrEmpty(input) || !required)
                    return input;

                DisplayError("Value is required");
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
            //Console.WriteLine("---------------");
            Console.WriteLine("".PadLeft(15, '-'));

            Console.WriteLine("A) dd");
            Console.WriteLine("V) iew");
            Console.WriteLine("D) elete");
            Console.WriteLine("Q) uit");

            while (true)
            {
                // Get input
                string input = Console.ReadLine().Trim();
                /*if (input == "Q")
                    return 'Q';
                else if (input == "A")
                    return 'A';
                else if (input == "V")
                    return 'V';
                else if (input == "D")
                    return 'D';*/

                // Case Insensitive
                switch (input.ToUpper())
                {
                    // No fallthrough, unless case statement empty
                    // Must end with break

                    // case "q":
                    case "Q": return 'Q';
                    
                    // case "a":
                    case "A": return 'A';
                    
                    // case "v":
                    case "V": return 'V';
                    
                    // case "d":
                    case "D": return 'D';
                    //default;
                };

                DisplayError("Invalid input");
            };
            // return default(char);   // default
        }

        static void DemoObjects ()
        {
            object someValue = 10;
            someValue = "Hello";

            Print(10);
            Print("Hello");
            Print(45.6);
            // someValue.Equals(10);
        }

        static void Print (object value )
        {
            // Console.WriteLine(value);
            
            // Type checking
            // is-operator ::= E is T (returns bool)
            // as-operator ::= E as T (returns T or null), does not work with primitives
            // patter-matching ::= E is T id => (returns E as T if valid or false otherwise)

            // Type casting
            // c-style ::= (T)E blows up at runtime if wrong, only use with primitives

            if (value is int)
            {
                Console.WriteLine((int)value);
                return;
            };

            string str = value as string;
            if (str != null)
            {
                Console.WriteLine(str);
                return;
            };

            // The best choice
            if (value is double doubleValue)
            {
                Console.WriteLine(doubleValue);
                return;
            };

            int x = 10;
            int y = x;
            x = 20;
            Console.WriteLine(y);   // 10

            // Value types follow value semantics
            var equal = x == y;

            Movie m1 = new Movie();
            Movie m2 = m1;
            m1.Title = "Jaws";
            Console.WriteLine(m2.Title);

            // Ref types follow reference semantics
            equal = m1 == m2;   // Object.Equals
        }
    }
}
