// Mitchel Campozano
// ITSE 1430
// AdventureGame Lab 4
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

        public bool NorthAccess { get; set; }

        public bool SouthAccess { get; set; }

        public bool EastAccess { get; set; }

        public bool WestAccess { get; set; }

        private string _roomName;
        private string _description;

        public Area Renovate ()
        {
            var room = new Area();

            room.RoomName = RoomName;
            room.Description = Description;
            room.NorthAccess = NorthAccess;
            room.SouthAccess = SouthAccess;
            room.EastAccess = EastAccess;
            room.WestAccess = WestAccess;

            return room;
        }

        public bool HasItem ()
        {

        }

        public override string ToString ()
        {
            return $"{RoomName}\n {Description}";
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
