/*
 * file header
 * My Name
 * ITSE 1430 Fal 2021
*/
using System;   // Statement

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
    }
}
