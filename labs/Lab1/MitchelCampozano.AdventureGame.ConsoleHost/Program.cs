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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("What would you like to do, adventurer?");
                Console.ResetColor();

                string action = Console.ReadLine();

                if (action.Contains("move"))
                    CheckMove(action);
                else if (action.Contains("look"))
                    CheckLook(placeX, placeY);
                else if (action.Contains("help"))
                    ControlHelp();
                else if (action.Contains("quit"))
                    done = ExitGame();
                else
                    ErrorMessage("I don't understand.");
            } while (!done);
        }

        static int placeX;
        static int placeY;
        static int maximumX = 3;
        static int maximumY = 3;

        static void GameIntro()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
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
            Console.ResetColor();

            Fountain();
        }

        static void CheckMove ( string action )
        {
            switch (action)
            {
                case "movenorth":
                RoomTracker(0, -1);
                break;
                case "movesouth":
                RoomTracker(0, 1);
                break;
                case "moveeast":
                RoomTracker(1, 0);
                break;
                case "movewest":
                RoomTracker(-1, 0);
                break;
                default:
                ErrorMessage("Invalid Move");
                break;
            };
        }

        static void RoomTracker ( int newX, int newY )
        {
            placeX += newX;
            placeY += newY;

            if (placeX  >= 0 && placeX  < maximumX && placeY >= 0 && placeY < maximumY) 
            {

                if (placeX >= 0 && placeY == 0)
                {
                    switch (placeX)
                    {
                        case 0:
                        {
                            Fountain();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                        case 1:
                        {
                            ChapelStart();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                        case 2:
                        {
                            ChestRoom();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                    };
                } else if (placeX >= 0 && placeY == 1)
                {
                    switch (placeX)
                    {
                        case 0:
                        {
                            Hallway();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                        case 1:
                        {
                            ChapelMid();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                        case 2:
                        {
                            DiningHall();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                    };
                } else if (placeX >= 0 && placeY == 2)
                {
                    switch (placeX)
                    {
                        case 0:
                        {
                            PriestRoom();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                        case 1:
                        {
                            ChapelAltar();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                        case 2:
                        {
                            Forge();
                            Console.WriteLine($"Your location is: {placeX + 1}, {placeY + 1}.");
                            break;
                        }
                    };
                }
            } else
            {
                ErrorMessage("You can't go that way.");

                if (placeX < 0)
                    placeX++;
                else if (placeX > 2)
                    placeX--;

                if (placeY < 0)
                    placeY++;
                else if (placeY > 2)
                    placeY--;
            }
        }
        
        static void CheckLook(int placeX, int placeY)
        {
            if (placeX >= 0 && placeY == 0)
            {
                switch (placeX)
                {
                    case 0:
                    {
                        Console.WriteLine("At the northern side of the room is a fountain, the idol once atop obliterated to rubble.");
                        Console.WriteLine("Pieces of metal are scattered throughout the room, embedded in the walls and floor.");
                        Console.WriteLine("All along the floor are coins from the fountain, though they must have been scattered from whatever explosion took place.");
                        Console.WriteLine("It doesn't seem any were looted. None follow the main paths in or out of the temple.");
                        Console.WriteLine("They lay on the floor, abandoned, victims to what has happened here.");
                        Console.WriteLine("You may go East or South");
                        break;
                    }
                    case 1:
                    {
                        Console.WriteLine("You look around at the horrid display, noticing that most of the bodies are wearing armor.");
                        Console.WriteLine("Most notably, their uniform is different from yours.");
                        Console.WriteLine("Those that aren't armored seem to stream into the main aisle toward the altar, going to the South of the chapel.");
                        Console.WriteLine("There must be a way out in that direction, but there must be answers elsewhere.");
                        Console.WriteLine("You may go South, East, or West.");
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Upon inspection, you can see that the chest has a single lock at the top.");
                        Console.WriteLine("The key to the lock, however, is nowhere in sight.");
                        Console.WriteLine("Whatever is inside must be important to the temple, the defenders all fighting to the bitter end.");
                        Console.WriteLine("It must have been important to the attackers as well, nothing valuable thus far looted from here.");
                        Console.WriteLine("You may go South or West");
                        break;
                    }
                };
            } else if (placeX >= 0 && placeY == 1)
            {
                switch (placeX)
                {
                    case 0:
                    {
                        Console.WriteLine("Just a mere glance at the remains tells you enough; the main defenders of the temple crowded specifically here to defend the room ahead.");
                        Console.WriteLine("Given the doorway leading in, and the treasures decorating the hallway, it can be assumed the Priest's quarters lie ahead.");
                        Console.WriteLine("At the end of the hallway is a small cannon aimed straight down to a hole in the wall behind you. That's one mystery solved.");
                        Console.WriteLine("You may go North, South, or East");
                        break;
                    }
                    case 1:
                    {
                        Console.WriteLine("The mural above you has remained untouched, saved from the onslaught below it.");
                        Console.WriteLine("It tells a tale of a slumbering god, once strong and mighty, laid to rest in a slab of stone.");
                        Console.WriteLine("Following along, you notice another depiction of the same deity, though this time standing tall and powerful, wielding a hammer");
                        Console.WriteLine("You may go North, South, East, or West");
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("The squeaks of rats can be heard about, eating whatever morsel hasn't gone to rot.");
                        Console.WriteLine("Up and down the bars of the stained glass windows, you see bones clinging to them, desperate souls looking for safe haven.");
                        Console.WriteLine("The bones around you seem to grow denser around the room with the chest, but also to the Southern end of the hall.");
                        Console.WriteLine("If there was an exit down at that end of the dining hall, why wouldn't those clinging to the windows go down there?");
                        Console.WriteLine("You may go North, South, or West.");
                        break;
                    }
                };
            } else if (placeX >= 0 && placeY == 2)
            {
                switch (placeX)
                {
                    case 0:
                    {
                        Console.WriteLine("On the desk in front of the priest is a piece of parchment with faded ink scribbled on it.");
                        Console.WriteLine("What you can make out reads: ");

                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\"Should this be the end of us, our sacred order, I can not bear to see it fall.\"");
                        Console.WriteLine("\"If our order does not fall, however, and if the Smith himself sends a savior, \"");
                        Console.WriteLine("\"let it be known we died loyal servants to him, guarding his most sacred treasure.\"");
                        Console.WriteLine("\"We will die for the sake of the Smith, and in turn, the sake of the Liberator!\"");
                        Console.ResetColor();
                        break;
                    }
                    case 1:
                    {
                        Console.WriteLine("The carved idol seems to wield an ornate hammer, the head embossed with runes of might and power.");
                        Console.WriteLine("Its purpose seems to be to intimidate those below it, ensuring they pray and give proper offering.");
                        Console.WriteLine("Your eyes trail down to the altar it looms over, seeing carved inscriptions scrawled on the edges of it.");
                        Console.WriteLine("The words you can make out, appear to say: ");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\"And the Smith shall rest after his endeavor with the Liberator, as will all of the Old Ones.\"");
                        Console.WriteLine("\"Knowing his hammer to be the source of his everlasting power, he stowed it away with those\""); 
                        Console.WriteLine("\"most devoted as a pact of peace with the humans that fought alongside the Liberator and the Old Ones.\"");
                        Console.WriteLine("\"And with this act, he laid himself to rest until called once more, sealing his power for now.\"");
                        Console.ResetColor();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Upon closer inspection, you notice that the oven was not intended for food at all, at least, when it was first built.");
                        Console.WriteLine("The racks inside of it were obviously forced into it as you look inside, when the inner wall grabs your attention.");
                        Console.WriteLine("Inside is a carved potrayal of men and women with hammers forging weapons for others, concluding what you suspected; ");
                        Console.WriteLine("This isn't an oven, this is a forge!");
                        break;
                    }
                };
            }
        }
    
        static bool ExitGame ()
        {
            if (CheckBool("Are you sure you want to quit (Y/N)?   "))
                return true;
            return false;
        }

        static bool CheckBool ( string quitSelect )
        {
            Console.Write(quitSelect);
            do
            {
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.Y)
                    return true;
                else if (input.Key == ConsoleKey.N)
                {
                    Console.WriteLine("");
                    return false;
                }
            } while (true);
        }

        static void ControlHelp ()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("movenorth | movesouth | moveeast | movewest ::= To move in the indicated direction");
            Console.WriteLine("look ::= To look at notable areas of the room");
            Console.WriteLine("help ::= Help with control commands");
            Console.WriteLine("quit ::= To quit the game");
            Console.ResetColor();
        }

        static void ErrorMessage ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void Fountain ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You find yourself in an offering room, with gates at the east busted down."); 
            Console.WriteLine("The southern wall is mostly gone, a massive hole leading into a hallway breaking the scenes painted long ago.");
            Console.WriteLine("Footprints of dried blood stain the dusty floor, all crowding past the archway into the chapel.");
            Console.WriteLine("There is much damage to the walls, scratches marring the now faded murals.");
            Console.ResetColor();
        }

        static void ChapelStart ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You walk over the cracked bones and stumble into the grand chapel, rows of pews stretching far toward the altar.");
            Console.WriteLine("Many of the pews are hacked to splinters, and the carnage of what has happened here begins to become apparent.");
            Console.WriteLine("Corpses now decayed and withered are scattered throughout.");
            Console.ResetColor();
        }

        static void ChestRoom ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Making your way down the passage around the chapel, you see more signs of struggle between the temple's followers and the invaders.");
            Console.WriteLine("You get to the end where a large wooden door is barely holding onto its hinges.");
            Console.WriteLine("Inside, invaders and temple followers with weapons in hand lay in a protective mound wrapped around a metal chest in the middle of the room.");
            Console.ResetColor();
        }

        static void Hallway ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You walk through the ruined entranceway, entering a once opulent hallway.");
            Console.WriteLine("Relics and paintings are strewn all over, and strangest of all, a mess of bones and different armors.");
            Console.WriteLine("There are extreme signs of struggle here, both dense with the invaders and what seems to be defenders.");
            Console.ResetColor();
        }

        static void ChapelMid ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Stumbling through the piles of bones, rotted clothes, and rusted weapons, you find a break in the pews.");
            Console.WriteLine("You are standing the in the middle of the chapel, halfway toward the entrance and the altar.");
            Console.WriteLine("The ceiling towers over you, the stained glass around allowing a dim light to seep in.");
            Console.ResetColor();
        }

        static void DiningHall ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You enter the dining hall, looking around at the obliterated grand table in the center of the room.");
            Console.WriteLine("Stained glass windows rise above the room, though the tight iron bars seemed to cage everyone in during the massacre.");
            Console.WriteLine("The bones seem to spill into the room from where the iron chest resides.");
            Console.ResetColor();
        }

        static void PriestRoom ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Entering the Priest's Quarters, the juxtaposition between here and the rest of the temple is striking.");
            Console.WriteLine("There is no carnage, no distress, rather, there is but one lone skeleton here, sitting at a desk.");
            Console.WriteLine("As you approach, you see there is something in each hand: in his left is a vial of poison, and in the right, there is a key.");
            Console.WriteLine("Most notably, there is something resting before his vacant eyes on top of his desk.");
            Console.ResetColor();
        }

        static void ChapelAltar ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You reach the end of the chapel, where a massive altar resides. Piles of bones lay all over it, possibly seeking refuge or saying a final prayer.");
            Console.WriteLine("The idol carved into the wall behind it stands tall, a depiction similar to the god in the mural on top of the cieling.");
            Console.WriteLine("The altar has strange carvings in it, though much of it is illegible, worn away by the test of time and the collision of weapons to it.");
            Console.ResetColor();
        }

        static void Forge ()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("This room is darker than the others, being completely sealed off from the light of both the chapel and the dining hall.");
            Console.WriteLine("It looks to be the kitchen, with large amounts of rotten food on shelves lining the walls and cookware tossed about.");
            Console.WriteLine("The rats scurry about your feet, too scared to nibble at you. They must be startled to see someone alive here after all these years.");
            Console.WriteLine("Something doesn't seem right about the oven, however; it is oddly decorated, and has racks makeshifted into it.");
            Console.ResetColor();
        }
    }
}
