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
    class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Item Add ( Item junk, out string error )
        {
            error = junk.ItemValidator();
            if (!String.IsNullOrEmpty(error))
                return null;

            var existing = FindJunkName(junk.ItemName);
            if (existing != null)
            {
                error = "Each room must have a unique name.";
                return null;
            }

            var newJunk = junk.Creation();

            junk.ItemId = newJunk.ItemId;

            _items.Add(newJunk);

            return junk;
        }

        private Item FindJunkName( string name )
        {
            foreach (var item in _items)
            {
                if (String.Compare(name, item.ItemName, true) == 0)
                    return item;
            };

            return null;
        }

        private Item FindJunkId ( int id )
        {
            foreach (var item in _items)
            {
                if (item.ItemId == id)
                    return item;
            };

            return null;
        }

        public Item Get ( int id )
        {
            var item = FindJunkId(id);

            return item?.Creation();
        }

        public IEnumerable<Item> GetAll ()
        {
            foreach (var item in _items)
                yield return item.Creation();
        }
    }
}
