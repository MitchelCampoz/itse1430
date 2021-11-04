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
