/*
 * file header
 * My Name
 * ITSE 1430 Fal 2021
*/
using System;   // Statement
using System.Text;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int abc = 456;
            Console.WriteLine("Hello World!");

            // Nested Scope
            {
                int abcd;
            }

            // Declare some Primitives
            // All Lowercase, all Keywords
            sbyte code = 10;
            short port = 45;
            int hours = 45;
            long debtPaybackInYears = 10_000;

            byte errorCode = 0x13;
            ushort errorPort = 0x145;
            uint unpaidHours = 0b1001_1110_1010_0010;

            double hoursWorked = 80.9;
            decimal payRate = 12.50M;

            char letter = 'A';
            string name = "Bob";

            // Not Primitives
            // Pascal Case
            // Not Keywords
            DateTime today = DateTime.Now;
            TimeSpan intveral = TimeSpan.FromMinutes(10);
            Guid identifier = Guid.Empty;
        }

        // Demoiing the logical operators
        static void DemoLogicalOperators ()
        {
            // Logical AND - true if both operands are true
            // Logical OR - true if either operand is true
            // Logical NOT - simply inverts false and true
            //      X       Y       &&      ||     
            // -------------------------------------
            //      F       F       F       F       
            //      F       T       F       T
            //      T       F       F       T
            //      T       T       T       T
            // NOT
            // F    !F      =       T
            // T    !T      =       F

            
        }

        // Demoing the logical operators

        static void DemoRelationalOperators ()
        {
            int x = 10, y = 20;

            bool isLessThan = x < y;
            bool isLessThanOrEqualTo = x <= y;
            
            bool isGreaterThan = x > y;
            bool isGreaterThanOrEqualTo = x >= y;

            bool isEqual = x == y;
            bool isNotEqual = x != y;
        }

        static void DemoCombinationOperators ()
        {
            // Works for more than jsut arithmetic
            int x = 10;

            x += 10;    // x = x + 10
            x -= 20;    // x = x - 20
            x *= 3;     // x = x * 3
            x /= 5;     // x = x / 5
            x %= 2;     // x = x % 2
        }

        static void DemoPrefixPostfixOperators ()
        {
            int x = 10, y;

            // Prefix increment
            // 1. Take current value of x and increment it by 1
            // 2. Store new value back in x
            // 3. Expresion value is current value of x
            y = ++x;    // x = 11, y = 11

            // Prefix increment
            // 1. Take current value of x and decrement it by 1
            // 2. Store new value back in x
            // 3. Expresion value is current value of x
            y = --x;    // x = 10, y = 10

            // Postfix increment
            // 1. Store current value of x in temporary
            // 2. Increment value of x by one and store back in x
            // 3. Expresion value is tmp (original value of x)
            y = x++;    // x = 11, y = 10

            // Postfix increment
            // 1. Store current value of x in temporary
            // 2. Increment value of x by one and store back in x
            // 3. Expresion value is tmp (original value of x)
            y = x--;    // x = 10, y = 11
        }

        static void DemoAssignmentOperator ()
        {
            int x;
            int y;
            int z;

            x = 10;
            y = 10;
            z = 10;

            // Left associative operators (E1 op E2) => E1, E2, op
            // Right associative operators (E1 op E2) => E2, E1, op
            x = y = z = 20; // x = (y = (z = 20))
        }

        static void DemoConditionalOperator ()
        {
            int grade = 70;

            string passStatus;

            if (grade < 60)
                passStatus = "Not Passing";
            else
                passStatus = "Passing";

            // Terninary- 3 operands
            // E (bool) ? E(true) : E(False)

            string passStatus2 = (grade < 60) ? "Not Passing" : "Passing";
        }

        static void DemoStrings ()
        {
            string firstName = "Bob";

            // Relationals work, case sensitive
            bool isBob = firstName == "Bob";

            // String literals
            string literal1 = "Hello World";

            // Escape sequences - \?, only work in string literals
            // \n => new line
            // \t => horizontal tab
            // \\ => slash
            // \" => double quote
            // \' => character literal, single quote
            literal1 = "Hello\nWorld";
            string filePath = "C:\\windows\\system32\\tasks";
            string verbatimString = @"C:\windows\system32\tasks";
            string quoteString = "Hello \"Bob\"";

            // String Length '.Length' => how many characters
            int length = literal1.Length;

            // Empty String
            string emptyString = "";    // .Length = 0
            string emptyString2 = String.Empty; // .Length = 0
            bool areEmptyStringsEqual = String.Empty == ""; // True

            // null != empty string
            // Default value for strings is null
            string nullString = null;
            bool areEqualNull = "" == null; // False

            // string is the universal type in C#
            // all expressions are convertible to string using .ToString
            string asString = length.ToString();    // Length as a string
            asString = 10.ToString();   // "10"
            asString = areEqualNull.ToString(); // False

            // Comparison
            string value1 = "Hello", value2 = "hello";
            bool areEqual = value1 == value2;

            bool compareCaseSensitive = String.Compare(value1, value2) == 0;

            bool compareCaseInsensitive = String.Compare(value1, value2, true) == 0;    // Preferred

            compareCaseSensitive = value1.CompareTo(value2) == 0;   // Works but not safe

            string lowerValue1 = value1.ToLower();
            string upperValue1 = value1.ToUpper();
            compareCaseInsensitive = value1.ToUpper() == value2.ToUpper();  // Inefficient

            // Concatenation: first last year
            int year = 2021;
            firstName = "Bob";
            string lastName = "Smith";
            string name = firstName + " " + lastName + " " + year;   // Bob Smith
            name = String.Concat(firstName, " ", lastName, " ", year);    // For Larger # of strings

            var builder = new StringBuilder();
            builder.Append(firstName);
            builder.Append(" ");
            builder.Append(lastName);
            builder.Append(" ");
            builder.Append(year);
            name = builder.ToString();

            name = String.Join(" ", firstName, lastName, year);

            // Misc
            bool startsWithB = name.StartsWith("B");
            startsWithB = name.StartsWith("B", StringComparison.CurrentCultureIgnoreCase);

            bool endsWith9 = name.StartsWith("9");
            endsWith9 = name.EndsWith("9", StringComparison.CurrentCultureIgnoreCase);

            // Removes leading and trailing whitespace 
            string normalizedName = name.Trim();
            //name.TrimStart().TrimEnd();

            // Some useful functions
            //name.Substring(startIndex); // Gets a subset of string
            //name.IndexOf(character);    // Finds a character

            name.PadLeft(50);   // Add enough spaces on left to make string length 50
            name.PadRight(50);  // Add enough spaces on left to make string length 50

            // Empty string checking
            bool isEmpty;
            isEmpty = name == "";   // Not always going to work correctly for you
            isEmpty = name.Length == 0; // Will crash if null

            // Handle Null
            isEmpty = (name != null) ? name == "" : true;
            isEmpty = name == null || name == "";
            isEmpty = (name != null) ? name.Length == 0 : true;
            isEmpty = String.IsNullOrEmpty(name);   // Preferred

            // Formatting - Hello first last, the year is year
            name = "Hello " + firstName + " " + lastName + ", the year is " + year + ". ";
            name = String.Format("Hello {0} {1}, the year is {2}.", firstName, lastName, year);
            Console.WriteLine("Hello {0} {1}, the year is {2}.", firstName, lastName, year);

            decimal price = 8.75M;
            string priceString = price.ToString();  // 8.7500000
            priceString = price.ToString("C");      // Money
            priceString = price.ToString("N6:N2");     // 8.7500
            priceString = String.Format("{0:C}", price);

            // String Interpolation - Way to go
            name = $"Hello {firstName} {lastName}, the year is {year:0000}.";
        }
    }
}
