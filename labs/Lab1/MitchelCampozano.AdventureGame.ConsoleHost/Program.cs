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

            GameIntro();

            do
            {
                string action = GameAction();

                if (action.Contains("quit"))
                    done = ExitGame();


            } while (!done);
        }

        // Maximum value for rooms based on XY axes
        static int maximumX = 3;
        static int maximumY = 3;

        // Player coordinates
        static int placeX;
        static int placeY;

        // Game intro text block
        static void GameIntro()
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

        // Input loop
        static string GameAction ()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("");
            Console.WriteLine("What would you like to do, adventurer?");
            Console.ResetColor();

            while (true)
            {
                string action = Console.ReadLine();

                if (action.Contains("move"))
                    CheckMove(action);
                else if (action.Contains("look"))
                    CheckLook(action);
                else if (action.Contains("quit"))
                    return "quit";
                else if (action.Contains("help"))
                    ControlHelp();
                else
                    ErrorMessage("I don't understand.");

            };
        }

        // Checks the move of the player if it's correct
        // Returns a value for the PlayerTracker function to do its thing
        static void CheckMove ( string action) 
        {
            // Keeps track of player movement
            int newX = placeX, newY = placeY;

            switch (action)
            {

                case "movenorth": newY -= 1;// WIP
                break;
                case "movesouth": newY += 1;// WIP
                break;
                case "moveeast": newX += 1;// WIP
                break;
                case "movewest": newX -= 1;// WIP
                break;
                default: ErrorMessage("Invalid Move"); 
                break;

            };

            if (placeX  >= 0 && placeX  < maximumX && placeY >= 0 && placeY < maximumY)
            {
                int roomNumber = placeX + (maximumX * (placeY - 1));

                switch (roomNumber)
                {
                    case 1: Room1(); break;
                    case 2: Room2(); break;
                    case 3: Room3(); break;
                };
            } else
                Console.WriteLine("You bonk into the wall");
        }

        // Inspect function
        static void CheckLook( string action )
        {
            Console.WriteLine("You entered " + action);
        }


        // Exit Game function calls the ReadBool function for quick and easy input
        static bool ExitGame ()
        {
            if (ReadBool("Are you sure you want to quit (Y/N)?   "))
                return true;
            return false;
        }

        // Validates user response to the ExitGame function
        static bool ReadBool ( string message )
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

        static void ControlHelp ()
        {
            Console.WriteLine("movenorth | movesouth | moveeast | movewest ::= To move in the indicated direction");
            Console.WriteLine("look :: = To look at notable areas of the room");
            // TODO : Add Take feature
        }

        static void ErrorMessage ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Room1 ()
        {
            Console.WriteLine("You found me");
        }

        static void Room2 ()
        {
            Console.WriteLine("You found me");
        }

        static void Room3 ()
        {
            Console.WriteLine("You found me");
        }
        //static void RoomSouthWest ()
        //{

        //    // Has one way to go (North)

        //    // The bodies here are not as armoured as the dead ones before you, but they still carry weapons
        //    // They surround a chained metal chest
        //    // You can't access the chest as it is chained with a lock
        //    Console.WriteLine("You enter the room, seeing a slew of light troops laying on the floor.");
        //    Console.WriteLine("At the center of the room, a large chest sits upright, chains and soldiers alike wrapped around it.");
        //    Console.WriteLine("In the middle of the chest, there is a lock.");

        //    // Going North takes you to RoomWest()
        //}

        //static void RoomWest ()
        //{
        //    // Has two ways to go (East and South)
        //    // The bodies here are stacked all near the doorway to the next room
        //    Console.WriteLine("Your eyes adjust to the sickly dark as you enter what appears to be a dining hall.");
        //    Console.WriteLine("Corpses are strewn about, all furniture either tossed with them or shattered in pieces.");
        //    Console.WriteLine("Tapestries hang tattered, one draped down on the floor like a red carpet into the only other doorway aside from the one you entered.");
        //    Console.WriteLine("Surrounding this doorway are many soldiers piled high.");

        //    // Going East goes to RoomCentral()

        //    // Going South goes to RoomSouthWest()
        //}

        //static void RoomNorthWest ()
        //{

        //}

        //static void RoomSouth ()
        //{
        //    // First room to go in
        //    // Has one way to go (North)
        //    // Stacked with bodies soldiers wearing different armour than you

        //    // Going North takes you to RoomCentral()
        //}

        //static void RoomCentral ()
        //{
        //    // Has three ways to go (West and East and South)
        //    // More bodies, but now you can hear faint growling

        //    // Going West goes to RoomWest()

        //    // Going East goes to RoomEast()
        //}

        //static void RoomNorth ()
        //{

        //}

        //static void RoomSouthEast ()
        //{
        //    // Has one way to go (North)
        //    // Room is surprisingly empty, with but one body cowered in the corner
        //    // Its armour is more ornate than the ones you've found thus far, it must be their superior
        //    // In its left hand is a vial that seems to have contained poison
        //    // In its right hand, held close and stiff to its chest, is a key

        //    // Take Key

        //    // Going North takes you to RoomEast()
        //}

        //static void RoomEast ()
        //{
        //    // Has three ways to go (North and South and West)
        //    // This room has heavily armored bodies strewn about the room
        //    // There is a large blood streak leading North
        //    // The growling is growing heavier

        //    // Going West takes you to RoomCentral()
        //    // Going South takes you to RoomSouthEast()
        //    // Going North takes you to RoomNorthEast()
        //}

        //static void RoomNorthEast ()
        //{

        //}
    }
}
