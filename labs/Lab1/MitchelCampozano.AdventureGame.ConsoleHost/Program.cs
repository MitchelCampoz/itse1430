/*
 * Adventure Game Lab
 * Mitchel Campozano
 * ITSE 1430 Fall 2021
*/

using System;

namespace MitchelCampozano.AdventureGame.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;

            GameStart();

            // TODO : Finish Game Loop
            while (!exitGame())
            {
                choice = CheckMove("What would you like to do, adventurer?", true);

                if (choice == "quit")
                    exitGame();
            } 
        }

       
        static void GameStart ()
        {
            Console.WriteLine("Mitchel Campozano, ITSE 1430 Adventure Game, Fall 2021");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("A clap of thunder wakes you from your unconscious, rain sweeping across the dead, charred land around you.");
            Console.WriteLine("The raindrops tap against your armor as you look around at the unfamiliar forest.");
            Console.WriteLine("Dead trees loom over you as you wander through the strange woods that eventually give way to a clearing in front of a temple.");
            Console.WriteLine("Large bronze doors tower over you, embossed with a tale of struggle between man and deities.");
            Console.WriteLine("Before you can move, they groan open, cracking enough to give you room to enter.");
            Console.WriteLine("");
        }

        static string CheckMove ( string message, bool checkVal )
        {
            Console.WriteLine(message);

            string input = Console.ReadLine();

            // TODO: Input validation for various commands
            return input;
        } 
        static bool exitGame()
        {
            string quitCom;

            Console.WriteLine("Are you sure you want to quit? (Y / N)");
            quitCom = Console.ReadLine();

            if (quitCom == "n")
                return false;
            else if (quitCom == "y")
                return true;
            else
                Console.WriteLine("Invalid entry.");
            return default;
        }

    }
}
