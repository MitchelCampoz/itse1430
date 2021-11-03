using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchelCampozano.AdventureGame
{
    public class World
    {
        private List<Area> _rooms = new List<Area>();

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

            newRoom.RoomNumX = 
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

        public Area FindRoomId ( int roomX, int roomY )
        {
            foreach (var room in _rooms)
            {
                if (room.RoomNumX == roomX && room.RoomNumY == roomY)
                    return room;
            };

            return null;
        }
    }
}
