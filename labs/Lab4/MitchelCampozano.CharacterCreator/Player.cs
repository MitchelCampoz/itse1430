using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchelCampozano.AdventureGame
{
    public class Player
    {
        public Player ()
        {
            var character = new Character()?.Recruit();

            var world = new World();
        }

        public int placeX { get; set; }
        public int placeY { get; set; }
        
        public const int MaximumX = 3;
        public const int MaximumY = 3;

        private void CheckMove ( string holder )
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

        public void RoomTracker ( int newX, int newY )
        {
            World playerWorld = new World();
            placeX += newX;
            placeY += newY;

            int roomNumber = placeX + (MaximumX * (placeY - 1));

            if (placeX  >= 0 && placeX  < MaximumX && placeY >= 0 && placeY < MaximumY)
            {
                switch (roomNumber)
                {
                    case 1: playerWorld.Get(roomNumber); break;
                    case 2: playerWorld.Get(roomNumber); break;
                    case 3: playerWorld.Get(roomNumber); break;
                    case 4: playerWorld.Get(roomNumber); break;
                    case 5: playerWorld.Get(roomNumber); break;
                    case 6: playerWorld.Get(roomNumber); break;
                    case 7: playerWorld.Get(roomNumber); break;
                    case 8: playerWorld.Get(roomNumber); break;
                    case 9: playerWorld.Get(roomNumber); break;
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

        private void RoomDisplay ()
        {
            Console.WriteLine($"You are currently at {placeX + 1}, {placeY + 1}.");
        }

        private void ErrorMessage ( string message )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
