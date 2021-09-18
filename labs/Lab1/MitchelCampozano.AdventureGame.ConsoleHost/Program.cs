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

            // Call the game intro
            GameIntro();

            do
            {
                string action = GameAction();

                if (action.Contains("quit"))
                    done = ExitGame();


            } while (!done);
        }

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
            Console.WriteLine("As you enter, your eyes begin to adjust to the all encompassing darkness when the bronze doors behind you slam shut.");
            Console.WriteLine("");

            Room1();
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
                    CheckLook(placeX, placeY);
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
        static void CheckMove ( string action ) 
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

            // Test comment
            placeX = newX; 
            placeY = newY;

            if (placeX  >= 0 && placeX  < 3 && placeY >= 0 && placeY < 3)
            {
                if (placeX >= 0 && placeY == 0)
                {
                    if (placeX == 0)
                    {
                        Room1();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY}.");
                    } else if (placeX == 1)
                    {
                        Room2();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY}.");
                    } else if (placeX == 2)
                    {
                        Room3();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY}.");
                    }
                } else if (placeX >= 0 && placeY == 1)
                {
                    if (placeX == 0)
                    {
                        Room4();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                    } else if (placeX == 1)
                    {
                        Room5();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                    } else if (placeX == 2)
                    {
                        Room6();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                    }
                }else if (placeX >= 0 && placeY == 2)
                {
                    if (placeX == 0)
                    {
                        Room7();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                    } else if (placeX == 1)
                    {
                        Room8();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                    } else if (placeX == 2)
                    {
                        Room9();
                        Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                    }
                }

            } else
                ErrorMessage("You bonk into the wall");
        }

        // Inspect function
        static void CheckLook(int placeX, int placeY)
        {
            if (placeX >= 0 && placeY == 0)
            {
                if (placeX == 0)
                {
                    // Room1();
                    Console.WriteLine("At the northern side of the room is a fountain, the idol once atop obliterated to rubble.");
                    Console.WriteLine("All along the floor are coins from the fountain.");
                    Console.WriteLine("You may go East or South");
                } else if (placeX == 1)
                {
                    // Room2();
                    Console.WriteLine("You look around at the horrid display, noticing that most of the bodies are wearing armor.");
                    Console.WriteLine("Most notably, their uniform is different from yours.");
                    Console.WriteLine("Those that aren't armored seem to stream into the main aisle toward the altar, going to the South of the chapel.");
                    Console.WriteLine("There must be a way out in that direction, but there must answers elsewhere.");
                    Console.WriteLine("You may go South, East, or West.");
                    
                } else if (placeX == 2)
                {
                    // Room3();
                    Console.WriteLine("Upon inspection, you can see that the chest has a single lock at the top");
                    Console.WriteLine("The key to the lock, however, is nowhere in sight.");
                    Console.WriteLine("Whatever was inside must have been important to the temple, the defenders all fighting to the bitter end.");
                    Console.WriteLine("It must have been important to the attackers as well, seeing as how they didn't even hold onto the coins from the fountain earlier.");
                    Console.WriteLine("You may go South or West");
                }
            } else if (placeX >= 0 && placeY == 1)
            {
                if (placeX == 0)
                {
                    // Room4();
                    Console.WriteLine("Just a mere glance at the remains tells you enough; the main defenders of the temple crowded specifically here to defend the Preist's Quarters");
                    Console.WriteLine("At the end of the hallway is a small cannon aimed straight down to a hole in the wall.");
                    Console.WriteLine("You may go North, South, or East");
                } else if (placeX == 1)
                {
                    // Room5();
                    Console.WriteLine("The mural above you has remained untouched, saved from the onslaught below it.");
                    Console.WriteLine("It tells a tale of a slumbering god, once strong and mighty, laid to rest in a slab of marble");
                    Console.WriteLine("Following along, you notice another depiction of the same deity, though this time standing tall and powerful, wielding a hammer");
                    Console.WriteLine("You may go North, South, East, or West");
                } else if (placeX == 2)
                {
                   // Room6();
                }
            } else if (placeX >= 0 && placeY == 2)
            {
                if (placeX == 0)
                {
                   // Room7();
                } else if (placeX == 1)
                {
                    //Room8();
                } else if (placeX == 2)
                {
                   // Room9();
                }
            }

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
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("movenorth | movesouth | moveeast | movewest ::= To move in the indicated direction");
            Console.WriteLine("look :: = To look at notable areas of the room");
            Console.ResetColor();
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
            // Fountain and offering place to leave a toll to enter the church
            // Can only go east
            Console.WriteLine("You find yourself in a strange room, with gates at the east busted down."); 
            Console.WriteLine("The southern wall is mostly gone, a massive hole leading into a hallway breaking the scenes painted long ago.");
            Console.WriteLine("Footprints of dried blood stain the dusty floor, all crowding past the archway into the chapel.");
            Console.WriteLine("There is much damage to the walls, scratches marring the now faded murals.");
           
        }

        static void Room2 ()
        {
            // Entrance into the main chapel with pews
            // Can go west and south
            Console.WriteLine("You walk over the broken iron gate and stumble into the grand chapel, rows of pews stretching far toward the altar.");
            Console.WriteLine("Many of the pews are hacked to splinters, and the carnage of what has happened here begins to become apparent.");
            Console.WriteLine("Corpses now decayed and withered are scattered throughout.");

        }

        static void Room3 ()
        {
            // If the boolean is set to true, you will open the chest in the middle of the room
            Console.WriteLine("Making your way down the passage around the chapel, you see more signs of struggle between the temple's followers and the invaders.");
            Console.WriteLine("You get to the end where a large wooden door is barely holding onto its hinges.");
            Console.WriteLine("Inside, invaders and temple followers with arms in hand lay in a protective mound wrapped around a metal chest in the middle of the room.");
        }

        static void Room4 ()
        {
            Console.WriteLine("You walk through the open doorway, entering a once opulent hallway.");
            Console.WriteLine("Relics and paintings are strewn all over, and strangest of all, a mess of bones and different armors.");
            Console.WriteLine("Going forward seems to lead into the Priest's Quarters.");
        }

        static void Room5 ()
        {
            // Continue down the aisle and see a break in the rows of pews
            // Can go north, south, east, west
            Console.WriteLine("Stumbling through the piles of bones, rotted clothes, and rusted weapons, you find a break in the pews.");
            Console.WriteLine("You are standing the in the middle of the chapel, halfway toward the entrance and the altar.");
            Console.WriteLine("The cieling towers over you, the stained glass around allowing a dim light to seep in.");
        }

        static void Room6 ()
        {
            Console.WriteLine("You enter the dining hall, looking around at the obliterated grand table in the center of the room.");
            Console.WriteLine("Stained glass windows rise above the room, though the tight iron bars seemed to cage everyone in during the massacre.");
            Console.WriteLine("The bones seem to spill into the room from where the iron chest resides, .");
        }

        static void Room7 ()
        {
            // Make a boolean set to true to overturn the false one to complete the quest
            Console.WriteLine("You found room7");
        }

        static void Room8 ()
        {
            // If the bool from room 7 is set to true, it will set the one in room 3 to true and that will set this one to true
            Console.WriteLine("You found room8");
        }

        static void Room9 ()
        {
            // Sets the bool to true when room 8 is set to true
            Console.WriteLine("You found room9");
        }

    }
}
