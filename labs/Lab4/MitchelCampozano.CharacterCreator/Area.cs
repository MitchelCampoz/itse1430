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

        public override string ToString ()
        {
            return $"{RoomName}\n {Description}";
        }

        public static string GameStartTell ()
        {
            return "Mitchel Campozano, ITSE 1430 Adventure Game, Fall 2021\n" +
                    "------------------------------------------------------\n\n" +
                    "A clap of thunder wakes you from your unconscious, rain sweeping across the dead, charred land around you.\n" +
                    "The raindrops tap against your armor as you look around at the unfamiliar forest.\n" +
                    "Dead trees loom over you as you wander through the strange woods that eventually give way to a clearing in front of a temple.\n" +
                    "Large bronze doors tower over you, embossed with a tale of struggle between man and deities.\n" +
                    "Before you can move, they groan open, cracking enough to give you room to enter.\n" +
                    "As you enter, your eyes begin to adjust to the all encompassing darkness when the bronze doors behind you slam shut.";
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

        public static string HallwayTell ()
        {
            return "You walk through the ruined entranceway, entering a once opulent hallway.\n" +
                    "Relics and paintings are strewn all over, and strangest of all, a mess of bones and different armors.\n" +
                    "There are extreme signs of struggle here, both dense with the invaders and what seems to be defenders.\n" +
                    "It seems the main defenders of the temple crowded specifically here to defend the room ahead.\n" +
                    "Given the doorway leading in, and the treasures decorating the hallway, it can be assumed the Priest's quarters lie ahead.\n" +
                    "At the end of the hallway is a small cannon aimed straight down to a hole in the wall behind you. That's one mystery solved.";
        }

        public static string ChapelMidTell ()
        {
            return "Stumbling through the piles of bones, rotted clothes, and rusted weapons, you find a break in the pews.\n" +
                    "You are standing the in the middle of the chapel, halfway toward the entrance and the altar.\n" +
                    "The ceiling towers over you, the stained glass around allowing a dim light to seep in.\n" +
                    "The mural above you has remained untouched, saved from the onslaught below it.\n" +
                    "It tells a tale of a slumbering god, once strong and mighty, laid to rest in a slab of stone.\n" +
                    "Following along, you notice another depiction of the same deity, though this time standing tall and powerful, wielding a hammer.";
        }

        public static string DiningHallTell ()
        {
            return "You enter the dining hall, looking around at the obliterated grand table in the center of the room.\n" +
                    "Stained glass windows rise above the room, though the tight iron bars seemed to cage everyone in during the massacre.\n" +
                    "The bones seem to spill into the room from where the iron chest resides.\n" +
                    "The squeaks of rats can be heard about, eating the rotting remnants of flesh and entrees.\n" +
                    "Up and down the bars of the stained glass windows, you see bones clinging to them, desperate souls looking for safe haven.\n" +
                    "The bones around you seem to grow denser around the room with the chest, but also to the Southern end of the hall.";
        }

        public static string PriestRoomTell ()
        {
            return "Entering the Priest's Quarters, the juxtaposition between here and the rest of the temple is striking.\n" +
                    "There is no carnage, no distress, rather, there is but one lone skeleton here, sitting at a desk.\n" +
                    "As you approach, you see there is something in each hand: in his left is a vial of poison, and in the right, there is a key.\n" +
                    "On the desk in front of the priest is a piece of parchment with faded ink scribbled on it.\n" +
                    "What you can make out reads: \n" + PriestLetter();
        }

        public static string PriestLetter ()
        {
            return "\"Should this be the end of us, our sacred order, I can not bear to see it fall.\"\n" +
                    "\"If our order does not fall, however, and if the Smith himself sends a savior, \"\n" +
                    "\"let it be known we died loyal servants to him, guarding his most sacred treasure.\"\n" +
                    "\"We will die for the sake of the Smith, and in turn, the sake of the Liberator!\"";
        }

        public static string ChapelAltarTell ()
        {
            return "You reach the end of the chapel, where a massive altar resides. Piles of bones lay all over it, possibly seeking refuge or saying a final prayer.\n" +
                    "The idol carved into the wall behind it stands tall, a depiction similar to the god in the mural on top of the cieling.\n" +
                    "The altar has strange carvings in it, though much of it is illegible, worn away by the test of time and the collision of weapons to it.\n" +
                    "The carved idol seems to wield an ornate hammer, the head embossed with runes of might and power.\n" +
                    "Its purpose seems to be to intimidate those below it, ensuring they pray and give proper offering.\n" +
                    "Your eyes trail down to the altar it looms over, seeing carved inscriptions scrawled on the edges of it.\n" +
                    "The words you can make out, appear to say: \n" + AltarInscription();
        }

        public static string AltarInscription ()
        {
            return "\"And the Smith shall rest after his endeavor with the Liberator, as will all of the Old Ones.\"\n" +
                    "\"Knowing his hammer to be the source of his everlasting power, he stowed it away with those\"\n" +
                    "\"most devoted as a pact of peace with the humans that fought alongside the Liberator and the Old Ones.\"\n" +
                    "\"And with this act, he laid himself to rest until called once more, sealing his power for now.\"";
        }

        public static string KitchenTell ()
        {
            return "This room is darker than the others, being completely sealed off from the light of both the chapel and the dining hall.\n" +
                    "It looks to be the kitchen, with large amounts of rotten food on shelves lining the walls and cookware tossed about.\n" +
                    "The rats scurry about your feet, too scared to nibble at you. They must be startled to see someone alive here after all these years.\n" +
                    "Upon closer inspection, you notice that the oven was not intended for food at all, at least, when it was first built.\n" +
                    "The racks inside of it were obviously forced into it as you look inside, when the inner wall grabs your attention.\n" +
                    "Inside is a carved potrayal of men and women with hammers forging weapons for others, concluding what you suspected; \n" +
                    "This isn't an oven, this is a forge!";
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
