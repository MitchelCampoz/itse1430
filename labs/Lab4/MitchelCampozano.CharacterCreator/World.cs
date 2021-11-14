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
            var roomCollection = new[] {
                (new Area(){
                    RoomName = "Game Start",
                    RoomId = 0,
                    Description = Area.GameStartTell(),
                    North = false,
                    South = false,
                    East = false,
                    West = false
                }),

                (new Area() {
                    RoomName = "Fountain",
                    RoomId = 1,
                    Description = Area.FountainTell(),
                    North = false,
                    South = true,
                    East = true,
                    West = false
                }),

                (new Area() {
                    RoomName = "Chapel Entrance",
                    RoomId = 2,
                    Description = Area.ChapelStartTell(),
                    North = false,
                    South = true,
                    East = true,
                    West = true
                }),

                (new Area() {
                    RoomName = "Chest Room",
                    RoomId = 3,
                    Description = Area.ChestRoomTell(),
                    North = false,
                    South = true,
                    East = false,
                    West = true
                }),

                (new Area() {
                    RoomName = "Hallway",
                    RoomId = 4,
                    Description = Area.HallwayTell(),
                    North = true,
                    South = true,
                    East = true,
                    West = false
                }),

                (new Area() {
                    RoomName = "Chapel Middle",
                    RoomId = 5,
                    Description = Area.ChapelMidTell(),
                    North = true,
                    South = true,
                    East = true,
                    West = true
                }),

                (new Area() {
                    RoomName = "Dining Hall",
                    RoomId = 6,
                    Description = Area.DiningHallTell(),
                    North = true,
                    South = true,
                    East = false,
                    West = true
                }),

                (new Area() {
                    RoomName = "Priest Room",
                    RoomId = 7,
                    Description = Area.PriestRoomTell(),
                    North = true,
                    South = false,
                    East = true,
                    West = false
                }),

                (new Area() {
                    RoomName = "Chapel Altar",
                    RoomId = 8,
                    Description = Area.ChapelAltarTell(),
                    North = true,
                    South = false,
                    East = true,
                    West = true
                }),

                (new Area(){
                    RoomName = "Kitchen",
                    RoomId = 9,
                    Description = Area.KitchenTell(),
                    North = true,
                    South = false,
                    East = false,
                    West = true
                })
            };

            _rooms.AddRange(roomCollection);
        }

        private List<Area> _rooms = new List<Area>();
        // private int _nextID = 1;

        public Area Add (Area room, out string error )
        {
            error = room.Validator();
            if (!String.IsNullOrEmpty(error))
                return null;

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

        private Area FindRoomName ( string name )
        {
            foreach (var room in _rooms)
            {
                if (String.Compare(name, room.RoomName, true) == 0)
                    return room;
            };

            return null;
        }

        private Area FindRoomId ( int id )
        {
            foreach (var room in _rooms)
            {
                if (room.RoomId == id)
                    return room;
            }

            return null;
        }

        public Area Get ( int id )
        {
            var room = FindRoomId(id);

            return room?.Renovate();
        }

        public IEnumerable<Area> GetAll ()
        {
            foreach (var room in _rooms)
                yield return room.Renovate();
        }
    }
}
