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
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        /// <summary>
        /// Adds a new item to the list
        /// </summary>
        /// <param name="junk"></param>
        /// <param name="error"></param>
        /// <returns>
        /// Returns a new item to the list
        /// </returns>
        public Item Add ( Item junk )
        {
            var error = junk.ItemValidator();
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

        /// <summary>
        /// Finds an item based on a name parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns>
        /// Returns an item
        /// </returns>
        private Item FindJunkName( string name )
        {
            foreach (var item in _items)
            {
                if (String.Compare(name, item.ItemName, true) == 0)
                    return item;
            };

            return null;
        }

        /// <summary>
        /// Finds an item based on an ID parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns an item
        /// </returns>
        private Item FindJunkId ( int id )
        {
            foreach (var item in _items)
            {
                if (item.ItemId == id)
                    return item;
            };

            return null;
        }

        /// <summary>
        /// Gets an item from the list based on an ID parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Returns an item 
        /// </returns>
        public Item Get ( int id )
        {
            var item = FindJunkId(id);

            return item?.Creation();
        }

        /// <summary>
        /// Gets all of the items from the list
        /// </summary>
        /// <returns>
        /// Returns all of the items
        /// </returns>
        public IEnumerable<Item> GetAll ()
        {
            foreach (var item in _items)
                yield return item.Creation();
        }
    }
}
