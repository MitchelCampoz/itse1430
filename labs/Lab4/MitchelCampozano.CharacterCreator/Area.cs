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
        /// <summary>
        /// Gets and sets the name of the room
        /// </summary>
        public string RoomName
        {
            get { return _roomName ?? ""; }
            set { _roomName = (value != null) ? value.Trim() : null; }
        }

        /// <summary>
        /// Gets and sets the description of the room
        /// </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = (value != null) ? value.Trim() : null; }
        }

        /// <summary>
        /// Gets and sets the ID of the room
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets and sets the indicator for whether a player can go North
        /// </summary>
        public bool NorthAccess { get; set; }

        /// <summary>
        /// Gets and sets the indicator for whether a player can go South
        /// </summary>
        public bool SouthAccess { get; set; }

        /// <summary>
        /// Gets and sets the indicator for whether a player can go East
        /// </summary>
        public bool EastAccess { get; set; }

        /// <summary>
        /// Gets and sets the indicator for whether a player can go West
        /// </summary>
        public bool WestAccess { get; set; }

        private string _roomName;
        private string _description;

        /// <summary>
        /// Creates a new room
        /// </summary>
        /// <returns>
        /// Returns a room
        /// </returns>
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

        /// <summary>
        /// Determines if an area has an item
        /// </summary>
        /// <returns>
        /// Returns whether an area has an item
        /// </returns>
        public bool HasItem ()
        {
            return true;
        }

        public override string ToString ()
        {
            return $"{RoomName}\n {Description}";
        }

        /// <summary>
        /// Validates values when creating a new room
        /// </summary>
        /// <returns>
        /// Returns an error message if an invalid value was used
        /// </returns>
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
