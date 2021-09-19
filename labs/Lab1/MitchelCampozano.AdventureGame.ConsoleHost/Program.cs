﻿/*
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

        // Quest trackers
        static bool quest;
        static bool mcguffin;
        static bool osmanFree;
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
                Console.WriteLine("");

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
                } else if (placeX >= 0 && placeY == 2)
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
                    if (quest == false)
                    {
                        Console.WriteLine("Upon inspection, you can see that the chest has a single lock at the top.");
                        Console.WriteLine("The key to the lock, however, is nowhere in sight.");
                        Console.WriteLine("Whatever was inside must have been important to the temple, the defenders all fighting to the bitter end.");
                        Console.WriteLine("It must have been important to the attackers as well, seeing as how they didn't even hold onto the coins from the fountain earlier.");
                        Console.WriteLine("You may go South or West");
                    }else if (quest == true)
                    {
                        Console.WriteLine("You take the key you found and put it in the lock, turning it until you hear a hard *CLICK*.");
                        Console.WriteLine("The lock falls on top of the bones, and the chest groans open to reveal a hammer with a stone head.");
                        Console.WriteLine("The hammer is heavy and beautifully carven. It doesn't seem to be ordinary.");

                        mcguffin = true;
                    }
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
                    Console.WriteLine("The squeaks of rats can be heard about, eating the rotting remnants of flesh and entrees.");
                    Console.WriteLine("Up and down the bars of the stained glass windows, you see bones clinging to them, desperate souls looking for safe haven.");
                    Console.WriteLine("The bones around you seem to grow denser around the room with the chest, and then toward the chapel.");
                    Console.WriteLine("You may go North, South, or West.");
                }
            } else if (placeX >= 0 && placeY == 2)
            {
                if (placeX == 0)
                {
                    // Room7();
                    Console.WriteLine("On the desk in front of the priest is a piece of parchment with faded ink scribbled on it.");
                    Console.WriteLine("What you can make out reads: ");
                    
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\"Should this be the end of us, our sacred order, I can not bear to see it fall.\"");
                    Console.WriteLine("\"If our order does not fall, however, and if the Smith himself sends a savior, \"");
                    Console.WriteLine("\"let it be known we died loyal servants to the Smith, and in turn, the Liberator.\"");
                    Console.WriteLine("");
                    Console.ResetColor();

                    if (quest == false)
                    {
                        Console.WriteLine("You gently take the twine holding the key and wrap it around your neck.");
                        quest = true;
                    }

                } else if (placeX == 1)
                {
                    //Room8();
                    if (mcguffin == false)
                    {
                        Console.WriteLine("The carved idol seems to wield an ornate hammer, the head embossed with runes of might and power.");
                        Console.WriteLine("Your eyes trail down to the altar it looms over, seeing carved inscriptions scrawled on the edges of it.");
                        Console.WriteLine("The words, now worn with age, appear to say: ");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\"And the Smith shall rest after his endeavor with the Liberator, as will all of the Old Ones.\"");
                        Console.WriteLine("\"Knowing his hammer to be the source of his everlasting power, he stowed it away with those most devoted.\"");
                        Console.WriteLine("\"And with this act, he laid himself to rest until called once more, sealing his power for now.\"");
                        Console.WriteLine("");
                        Console.ResetColor();
                    }else if (mcguffin == true)
                    {
                        Console.WriteLine("The hammer you took from the chest rips from your possession, flying forward to the altar and exploding it.");
                        Console.WriteLine("Dust and rubble take over the room, when suddenly, in place of the altar, you see a tall figure standing there.");
                        Console.WriteLine("Holding the hammer high, the energy of the room changes, charged with the might of this being.");
                        Console.WriteLine("He turns to see you standing there, the cold glare of his not showing gratitude nor animosity.");
                        Console.WriteLine("Before you can move, he heads straight to the kitchen.");

                        osmanFree = true;
                    }

                } else if (placeX == 2)
                {
                    // Room9();
                    if (osmanFree == false)
                    {
                        Console.WriteLine("Upon closer inspection, you notice that the oven was not intended for food at all, at least, when it was first built.");
                        Console.WriteLine("The racks inside of it were obviously forced into it as you look inside, when suddenly something glints at you.");
                        Console.WriteLine("You grab the shiny item, seeing it to be a hardened piece of metal, concluding what you suspected; ");
                        Console.WriteLine("This isn't an oven, this is a forge!");
                    }else if (osmanFree == true)
                    {
                        Console.WriteLine("You enter to see the tall man standing before the forge, looking ashamedly down at it. He opens his mouth to speak: ");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("So it seems my followers are lost to time now. The invaders of the Usurper have done their worst.");
                        Console.WriteLine("However, if it weren't for my followers to protect my hammer, they would have taken it and freed me, slaying me as I am still weak.");
                        Console.WriteLine("And you, adventurer, stumbling upon this desecrated site, you have freed me to avenge them, and for that I am grateful.");
                        Console.WriteLine("You bear the markings of the Liberator, thus I will send you to his lands where you may find answers to the questions you may have.");
                        Console.WriteLine("Now, I must start my forge once more, and will not leave my followers' sacrifice in vain!");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("You feel a strange energy wrap around you as the room goes white, fading away until you see it no more.");
                    }
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You find yourself in a strange room, with gates at the east busted down."); 
            Console.WriteLine("The southern wall is mostly gone, a massive hole leading into a hallway breaking the scenes painted long ago.");
            Console.WriteLine("Footprints of dried blood stain the dusty floor, all crowding past the archway into the chapel.");
            Console.WriteLine("There is much damage to the walls, scratches marring the now faded murals.");
            Console.ResetColor();
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
            Console.WriteLine("The bones seem to spill into the room from where the iron chest resides.");
        }

        static void Room7 ()
        {
            // Make a boolean set to true to overturn the false one to complete the quest
            if (quest == false)
            {
                Console.WriteLine("Entering the Priest's Quarters, the juxtaposition between here and the rest of the temple is striking.");
                Console.WriteLine("There is no carnage, no distress, rather, there is but one lone skeleton here, sitting at a desk.");
                Console.WriteLine("As you approach, you see there is something in each hand: in his left is a vial of poison, and in the right, there is a key.");
            }else if (quest == true)
            {
                Console.WriteLine("Entering the priest's quarters, you see his remains peacefully at his desk, the empty eyes of his skull forever reading his last words.");
            }
        }

        static void Room8 ()
        {
            // If the bool from room 7 is set to true, it will set the one in room 3 to true and that will set this one to true
            Console.WriteLine("You reach the end of the chapel, where a massive altar resides. Piles of bones lay all over it, possibly seeking refuge or saying a final prayer.");
            Console.WriteLine("The idol carved into the wall behind it stands tall, a depiction similar to the god in the mural on top of the cieling.");
        }

        static void Room9 ()
        {
            // Sets the bool to true when room 8 is set to true
            Console.WriteLine("This room is darker than the others, being completely sealed off from the light of both the chapel and the dining hall.");
            Console.WriteLine("It looks to be the kitchen, with large amounts of rotten food on shelves lining the walls and cookware tossed about.");
            Console.WriteLine("The rats scurry about your feet, too scared to nibble at you. They must be startled to see someone alive here after all these years.");
            Console.WriteLine("Something doesn't seem right about the oven, however; it is oddly decorated, and has racks makeshifted into it.");
        }

    }
}
