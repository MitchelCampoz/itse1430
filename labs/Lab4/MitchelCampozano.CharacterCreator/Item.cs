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
    public class Item
    {
        /// <summary>
        /// Gets and sets the name of the item
        /// </summary>
        public string ItemName
        {
            get { return _itemName ?? "" ; }

            set { _itemName = (value != null) ? value.Trim() : ""; }
        }

        /// <summary>
        /// Gets and sets the value of the item in coins
        /// </summary>
        public int CoinValue { get; set; }

        /// <summary>
        /// Gets and sets the weight of the item
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets and sets the ID of the item
        /// </summary>
        public int ItemId { get; set; }

        private string _itemName;

        /// <summary>
        /// Creates a new item
        /// </summary>
        /// <returns>
        /// Returns a new item
        /// </returns>
        public Item Creation ()
        {
            var item = new Item();

            item.ItemName = ItemName;
            item.CoinValue = CoinValue;
            item.Weight = Weight;

            return item;
        }

        public override string ToString ()
        {
            return $"{ItemName}\n{CoinValue}\n{Weight}";
        }

        /// <summary>
        /// Validates the values of the fields of a new item
        /// </summary>
        /// <returns>
        /// Returns an error message if a value is invalid
        /// </returns>
        public string ItemValidator ()
        {
            if (String.IsNullOrEmpty(ItemName))
                return "Item must have a name";
            if (CoinValue < 0)
                return "Item must be worthless or worth something";
            if (Weight <= 0)
                return "Item must weight something";

            return null;
        }
    }
}
