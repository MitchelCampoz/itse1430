using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchelCampozano.AdventureGame
{
    public class World
    {
        public World ()
        {
            //var roomCollection = new[] {

            //    (new Area() {
            //        RoomName = "Fountain",
            //        RoomId = 1,
            //        Description = "You find yourself in an offering room, with gates at the east busted down.\n"
                                
            //    }
            //    ),

            //    (new Area() {
            //        RoomName = "Chapel Entrance",
            //        RoomId = 2,
            //        Description = "You find yourself in an offering room, with gates at the east busted down.\n"

            //    }
            //    ),

            //    (new Area() {
            //        RoomName = "Chest Room",
            //        RoomId = 3,
            //        Description = "You find yourself in an offering room, with gates at the east busted down.\n"

            //    }
            //    ),

            //    (new Area() {
            //        RoomName = "Hallway",
            //        RoomId = 4,
            //        Description = "You find yourself in an offering room, with gates at the east busted down.\n"

            //    }
            //    ),
                
            //    (new Area() {
            //        RoomName = "Chapel Middle",
            //        RoomId = 5,
            //        Description = "You find yourself in an offering room, with gates at the east busted down.\n"

            //    }
            //    ),

            //    (new Area() {
            //        RoomName = "Dining Hall",
            //        RoomId = 6,
            //        Description = "You find yourself in an offering room, with gates at the east busted down.\n"

            //    }
            //    ),
            //};
            
            //_rooms.AddRange(roomCollection);
        }

        private List<Area> _rooms = new List<Area>();
        private int _nextID = 1;

        public Area Add (Area room, out string error )
        {
            error = room.Validator();
            if (!String.IsNullOrEmpty(error))
                return null;

            //var existing = FindRoomId(room.RoomNumX, room.RoomNumY);
            var existing = FindRoomName(room.RoomName);
            if (existing != null)
            {
                error = "Each room must have a unique name.";
                return null;
            }

            var newRoom = room.Renovate();

            newRoom = room.Renovate();

            _rooms.Add(newRoom);

            room.RoomId = newRoom.RoomId;

            return room;
        }

        public Area FindRoomName ( string name )
        {
            foreach (var room in _rooms)
            {
                if (String.Compare(name, room.RoomName, true) == 0)
                    return room;
            };

            return null;
        }

        public Area FindRoomId ( int id )
        {
            foreach (var room in _rooms)
            {
                if (room.RoomId == id)
                    return room;
            }

            return null;
        }
    }
}
