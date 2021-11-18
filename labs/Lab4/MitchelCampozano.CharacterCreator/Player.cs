// Mitchel Campozano
// ITSE 1430
// AdventureGame Lab 3
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
            var mainCharacter = new Character()?.Recruit();
            var mainInventory = new Inventory();
        }

        public int placeX { get; set; }
        public int placeY { get; set; }
        
        public const int MaximumX = 3;
        public const int MaximumY = 3;

        public int RoomTracker ( int newX, int newY )
        {
            World playerWorld = new World();
            placeX += newX;
            placeY += newY;

            int roomNumber = placeX + (MaximumX * (placeY - 1));

            if (placeX  >= 0 && placeX  < MaximumX && placeY >= 0 && placeY < MaximumY)
            {
                switch (roomNumber)
                {
                    //case 1: playerWorld.Get(roomNumber); break;
                    //case 2: playerWorld.Get(roomNumber); break;
                    //case 3: playerWorld.Get(roomNumber); break;
                    //case 4: playerWorld.Get(roomNumber); break;
                    //case 5: playerWorld.Get(roomNumber); break;
                    //case 6: playerWorld.Get(roomNumber); break;
                    //case 7: playerWorld.Get(roomNumber); break;
                    //case 8: playerWorld.Get(roomNumber); break;
                    //case 9: playerWorld.Get(roomNumber); break;
                    case 1: return 1;
                    case 2: return 2;
                    case 3: return 3;
                    case 4: return 4;
                    case 5: return 5;
                    case 6: return 6;
                    case 7: return 7;
                    case 8: return 8;
                    case 9: return 9;
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

            return -1;
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
