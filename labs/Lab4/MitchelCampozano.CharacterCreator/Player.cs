using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchelCampozano.AdventureGame
{
    public class Player
    {
        static int placeX;
        static int placeY;
        static int maximumX = 3;
        static int maximumY = 3;

        static void CheckMove ( string holder )
        {
            switch (holder)
            {
                case "MOVENORTH":
                RoomTracker(0, -1);
                break;
                case "MOVESOUTH":
                RoomTracker(0, 1);
                break;
                case "MOVEEAST":
                RoomTracker(1, 0);
                break;
                case "MOVEWEST":
                RoomTracker(-1, 0);
                break;
                default:
                ErrorMessage("Invalid Move");
                break;
            };
        }

        static void RoomTracker ( int newX, int newY )
        {
            // Fix it

            placeX += newX;
            placeY += newY;

            int roomNumber = placeX + (maximumX * (placeY - 1));

            if (placeX  >= 0 && placeX  < maximumX && placeY >= 0 && placeY < maximumY)
            {
                switch (roomNumber)
                {
                    //case 0: FirstRowTracker(); break;
                    //case 1: SecondRowTracker(); break;
                    //case 2: ThirdRowTracker(); break;
                    case 1: World.Get(roomNumber); break;
                    case 2: World.Get(roomNumber); break;
                    case 3: World.Get(roomNumber); break;
                    case 4: World.Get(roomNumber); break;
                    case 5: World.Get(roomNumber); break;
                    case 6: World.Get(roomNumber); break;
                    case 7: World.Get(roomNumber); break;
                    case 8: World.Get(roomNumber); break;
                    case 9: World.Get(roomNumber); break;
                };
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

        static void RoomDisplay ()
        {
            Console.WriteLine($"You are currently at {placeX + 1}, {placeY + 1}.");
        }

        static void ErrorMessage ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
