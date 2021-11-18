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
    class Item
    {
        public string ItemName
        {
            get { return _itemName ?? "" ; }

            set { _itemName = (value != null) ? value.Trim() : ""; }
        }

        public int CoinValue { get; set; }

        public int Weight { get; set; }

        public int ItemId { get; set; }

        private string _itemName;

        public Item Creation ()
        {
            var item = new Item();

            item.ItemName = ItemName;
            item.CoinValue = CoinValue;
            item.Weight = Weight;

            return item;
        }

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
