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
            bool done = false;

            Console.WriteLine("Mitchel Campozano, ITSE 1430 Adventure Game, Fall 2021");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("A clap of thunder wakes you from your unconscious, rain sweeping across the dead, charred land around you.");
            Console.WriteLine("The raindrops tap against your armor as you look around at the unfamiliar forest.");
            Console.WriteLine("Dead trees loom over you as you wander through the strange woods that eventually give way to a clearing in front of a temple.");
            Console.WriteLine("Large bronze doors tower over you, embossed with a tale of struggle between man and deities.");
            Console.WriteLine("Before you can move, they groan open, cracking enough to give you room to enter.");
            Console.WriteLine("");

            // TODO : Finish Game Loop
            do
            {
                string choice = GameAction();

                // Possible switch statement to see which room to be in


                if (choice == "quit")
                    done = ExitGame();
            } while (!done);
        }

        static void RoomSouthWest ()
        {
            // Has one way to go (North)

            // The bodies here are not as armoured as the dead ones before you, but they still carry weapons
            // They surround a chained metal chest
            // You can't access the chest as it is chained with a lock
            Console.WriteLine("You enter the room, seeing a slew of light troops laying on the floor.");
            Console.WriteLine("At the center of the room, a large chest sits upright, chains and soldiers alike wrapped around it.");
            Console.WriteLine("In the middle of the chest, there is a lock.");



            // Going North takes you to RoomWest()
        }

        static void RoomWest ()
        {
            // Has two ways to go (East and South)
            // The bodies here are stacked all near the doorway to the next room

            // Going East goes to RoomCentral()

            // Going South goes to RoomSouthWest()
        }

        static void RoomNorthWest ()
        {

        }

        static void RoomSouth ()
        {
            // First room to go in
            // Has one way to go (North)
            // Stacked with bodies soldiers wearing different armour than you
            
            // Going North takes you to RoomCentral()
        }

        static void RoomCentral ()
        {
            // Has three ways to go (West and East and South)
            // More bodies, but now you can hear faint growling
            
            // Going West goes to RoomWest()

            // Going East goes to RoomEast()
        }

        static void RoomNorth ()
        {

        }

        static void RoomSouthEast ()
        {
            // Has one way to go (North)
            // Room is surprisingly empty, with but one body cowered in the corner
            // Its armour is more ornate than the ones you've found thus far, it must be their superior
            // In its left hand is a vial that seems to have contained poison
            // In its right hand, held close and stiff to its chest, is a key

            // Take Key

            // Going North takes you to RoomEast()
        }

        static void RoomEast ()
        {
            // Has three ways to go (North and South and West)
            // This room has heavily armored bodies strewn about the room
            // There is a large blood streak leading North
            // The growling is growing heavier

            // Going West takes you to RoomCentral()
            // Going South takes you to RoomSouthEast()
            // Going North takes you to RoomNorthEast()
        }

        static void RoomNorthEast ()
        {

        }

        static void CheckMove ( string action, bool checkVal)
        {
            Console.WriteLine("You Move");
        } 

        static void CheckLook ()
        {
            Console.WriteLine("You Look");
        }

        static bool ReadBoolean ( string message)
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
        
        static string GameAction ()
        {
            Console.WriteLine("");
            Console.WriteLine("What would you like to do, adventurer?");

            while (true)
            {
                string action = Console.ReadLine();

                if (action.Contains("move"))
                    CheckMove(action, true);
                else if (action.Contains("look"))
                    CheckLook();
                else if (action.Contains("quit"))
                    return "quit";
                else
                    ErrorMessage("I don't understand.");
            };
        }
        static bool ExitGame ()
        {
            return (ReadBoolean("Are you sure you want to quit (Y/N)?   ")) ;
        }

    }
}
