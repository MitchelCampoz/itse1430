using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchelCampozano.AdventureGame
{
    public class Area
    {
        public string RoomName
        {
            get { return _roomName ?? ""; }
            set { _roomName = (value != null) ? value.Trim() : null; }
        }

        public string Description
        {
            get { return _description ?? ""; }
            set { _description = (value != null) ? value.Trim() : null; }
        }

        public int RoomId { get; set; }

        private string _roomName;
        private string _description;

        public Area Renovate ()
        {
            var room = new Area();

            room.RoomName = RoomName;
            room.Description = Description;

            return room;
        }

        public static void Fountain ()
        {
            var room = new Area();
            room.RoomName = "Fountain";
            room.Description = FountainTell();
            room.RoomId = 1;
        }

        public static string FountainTell ()
        {
            return "You find yourself in an offering room, with gates at the east busted down.\n " +
                    "The southern wall is mostly gone, a massive hole leading into a hallway breaking the scenes painted long ago.\n" +
                    "Footprints of dried blood stain the dusty floor, all crowding past the archway into the chapel.\n" +
                    "There is much damage to the walls, scratches marring the now faded murals.\n" +
                    "At the northern side of the room is a fountain, the idol once atop obliterated to rubble.\n" +
                    "Pieces of metal are scattered throughout the room, embedded in the walls and floor.\n" +
                    "All along the floor are coins from the fountain, though they must have been scattered from whatever explosion took place.\n" +
                    "It doesn't seem any were looted; none follow the main paths in or out of the temple.\n" +
                    "They lay on the floor, abandoned, victims to what has happened here.";
        }

        public static void ChapelStart ()
        {
            var room = new Area();
            room.RoomName = "Chapel Entrance";
            room.Description = ChapelStartTell();
            room.RoomId = 2;
        }

        public static string ChapelStartTell ()
        {
            return "You walk over the cracked bones and stumble into the grand chapel, rows of pews stretching far toward the altar.\n" +
                    "Many of the pews are hacked to splinters, and the carnage of what has happened here begins to become apparent.\n" +
                    "Corpses now decayed and withered are scattered throughout.\n" +
                    "You look around at the horrid display, noticing that most of the bodies are wearing armor.\n" +
                    "Most notably, their uniform is different from yours.\n" +
                    "Those that aren't armored seem to stream into the main aisle toward the altar, going to the South of the chapel.\n" +
                    "There must be a way out in that direction, but there must be answers elsewhere.";
        }

        public static void ChestRoom ()
        {
            var room = new Area();
            room.RoomName = "Chest Room";
            room.Description = ChestRoomTell();
            room.RoomId = 3;
        }

        public static string ChestRoomTell ()
        {
            return "Making your way down the passage around the chapel, you see more signs of struggle between the temple's followers and the invaders.\n" +
                    "You get to the end where a large wooden door is barely holding onto its hinges.\n" +
                    "Inside, invaders and temple followers with weapons in hand lay in a protective mound wrapped around a metal chest in the middle of the room.\n" +
                    "Upon inspection, you can see that the chest has a single lock at the top.\n" +
                    "The key to the lock, however, is nowhere in sight.\n" +
                    "Whatever is inside must be important to the temple, the defenders all fighting to the bitter end.\n" +
                    "It must have been important to the attackers as well, nothing valuable thus far looted from here.";
        }

        public static void Hallway ()
        {
            var room = new Area();
            room.RoomName = "Hallway";
            room.Description = HallwayTell();
            room.RoomId = 4;
        }

        public static string HallwayTell ()
        {
            return "You walk through the ruined entranceway, entering a once opulent hallway.\n" +
                    "Relics and paintings are strewn all over, and strangest of all, a mess of bones and different armors.\n" +
                    "There are extreme signs of struggle here, both dense with the invaders and what seems to be defenders.\n" +
                    "It seems the main defenders of the temple crowded specifically here to defend the room ahead.\n" +
                    "Given the doorway leading in, and the treasures decorating the hallway, it can be assumed the Priest's quarters lie ahead.\n" +
                    "At the end of the hallway is a small cannon aimed straight down to a hole in the wall behind you. That's one mystery solved.";
        }

        public static void ChapelMid ()
        {
            var room = new Area();
            room.RoomName = "Chapel Middle";
            room.Description = ChapelMidTell();
            room.RoomId = 5;
        }

        public static void DiningHall()
        {
            var room = new Area();
            room.RoomName = "Dining Hall";
            room.Description = DiningHallTell();
            room.RoomId = 6;
        }

        public static void PriestRoom ()
        {
            var room = new Area();
            room.RoomName = "Priest Room";
            room.Description = PriestRoomTell();
            room.RoomId = 7;
        }

        public static void ChapelAltar ()
        {
            var room = new Area();
            room.RoomName = "Chapel Altar";
            room.Description = ChapelAltarTell();
            room.RoomId = 8;
        }

        public static void Kitchen ()
        {
            var room = new Area();
            room.RoomName = "Kitchen";
            room.Description = KitchenTell();
            room.RoomId = 9;
        }

        public string Validator ()
        {
            if (String.IsNullOrEmpty(RoomName))
                return "Room needs a name";

            if (String.IsNullOrEmpty(Description))
                return "Room needs a description";

            if (RoomId < 0)
                return "Room needs a proper ID";

            return null;
        }
    }
}
