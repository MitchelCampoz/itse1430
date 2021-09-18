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
                case "stand": break;
                default: ErrorMessage("Invalid Move"); 
                break;

            };

            placeX = newX; 
            placeY = newY;

            if (placeX  >= 0 && placeX  < 3 && placeY >= 0 && placeY < 3)
            {
                // int roomNumber = placeX + (3 * (placeY - 1));

                //switch (roomNumber)
                //{
                //    case 1: Room1(); Console.WriteLine(placeX + " " + placeY); break;
                //    case 2: Room2(); Console.WriteLine(placeX + " " + placeY); break;
                //    case 3: Room3(); Console.WriteLine(placeX + " " + placeY); break;
                //    case 4: Room4(); Console.WriteLine(placeX + " " + placeY); break;
                //    case 5: Room5(); Console.WriteLine(placeX + " " + placeY); break;
                //    case 6: Room6(); Console.WriteLine(placeX + " " + placeY); break;
                //    case 7: Room7(); Console.WriteLine(placeX + " " + placeY); break;
                //    case 8: Room8(); Console.WriteLine(placeX + " " + placeY); break;
                //    case 9: Room9(); Console.WriteLine(placeX + " " + placeY); break;
                // };

                if (placeX >= 0 && placeY == 0)
                {
                    if (placeX == 0)
                    {
                        Room1();
                        Console.WriteLine(placeX + " " + placeY);
                    } else if (placeX == 1)
                    {
                        Room2();
                        Console.WriteLine(placeX + " " + placeY);
                    } else if (placeX == 2)
                    {
                        Room3();
                        Console.WriteLine(placeX + " " + placeY);
                    }
                } else if (placeX >= 0 && placeY == 1)
                {
                    if (placeX == 0)
                    {
                        Room4();
                        Console.WriteLine(placeX + " " + placeY);
                    } else if (placeX == 1)
                    {
                        Room5(); 
                        Console.WriteLine(placeX + " " + placeY);
                    }else if (placeX == 2)
                    {
                        Room6(); 
                        Console.WriteLine(placeX + " " + placeY);
                    }
                }else if (placeX >= 0 && placeY == 2)
                {
                    if (placeX == 0)
                    {
                        Room7();
                        Console.WriteLine(placeX + " " + placeY);
                    } else if (placeX == 1)
                    {
                        Room8();
                        Console.WriteLine(placeX + " " + placeY);
                    } else if (placeX == 2)
                    {
                        Room9();
                        Console.WriteLine(placeX + " " + placeY);
                    }
                }

            } else
                ErrorMessage("You bonk into the wall");
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
            Console.WriteLine("You found room1");
        }

        static void Room2 ()
        {
            Console.WriteLine("You found room2");
        }

        static void Room3 ()
        {
            Console.WriteLine("You found room3");
        }

        static void Room4 ()
        {
            Console.WriteLine("You found room4");
        }

        static void Room5 ()
        {
            Console.WriteLine("You found room5");
        }

        static void Room6 ()
        {
            Console.WriteLine("You found room6");
        }

        static void Room7 ()
        {
            Console.WriteLine("You found room7");
        }

        static void Room8 ()
        {
            Console.WriteLine("You found room8");
        }

        static void Room9 ()
        {
            Console.WriteLine("You found room9");
        }

    }
}
