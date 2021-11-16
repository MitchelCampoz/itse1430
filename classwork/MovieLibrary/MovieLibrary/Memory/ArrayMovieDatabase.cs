using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary.WinHost
{
    internal class ArrayMovieDatabase
    {
        public ArrayMovieDatabase ()
        {
            // TODO: Seed
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "PG";
            //movie.RunLength = 210;
            //movie.ReleaseYear = 1975;
            //movie.Description = "Shark Movie";
            //movie.Id = 1;

           
            _items[0] = new Movie() {
                Title = "Jaws",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1975,
                Description = "Shark Movie",
                Id = 1,
            };

            //movie = new Movie();
            //movie.Title = "Dune";
            //movie.Rating = "PG";
            //movie.RunLength = 300;
            //movie.ReleaseYear = 1982;
            //movie.Description = "Sand Movie";
            //movie.Id = 2;
            
            _items[1] = new Movie() {
                Title = "Dune",
                Rating = "PG",
                RunLength = 300,
                ReleaseYear = 1982,
                Description = "Sand Movie",
                Id = 2,
            };

            // Object initializer - creating and initializing new object
            //  new T() {
            //      Property1 = Value 1,
            //      Property2 = Value 2,
            //      ...,
            //      ...,
            //  };


            //movie = new Movie() {
            //    Title = "Jaws 2",
            //    Rating = "PG",
            //    RunLength = 190,
            //    ReleaseYear = 1979,
            //    Description = "Shark Movie again",
            //    Id = 3,
            //};
            
            _items[2] = new Movie() {
                Title = "Jaws 2",
                Rating = "PG",
                RunLength = 190,
                ReleaseYear = 1979,
                Description = "Shark Movie again",
                Id = 3,
            };
        }
        
        // TODO: Add
        //public void Add ( Movie movie )
        //{

        //}

        //// TODO: Update
        //public void Update ( Movie movie )
        //{

        //}
        
        //// TOOD: Delete
        //public void Delete ( Movie movie )
        //{

        //}

        // TODO: Get
        public Movie Get ()
        {
            return null;
        }

        // TODO: Get All
        public Movie[] GetAll ()
        {
            // NEVER DO THIS
            // return _items;

            // Array.Copy(); - Will copy aqrray but not ref movies

            // Need to filter out null movies
            var count = 0;
            foreach(var item in _items)
            {
                if (item != null)
                    ++count;
            };

            // Must clone both array and movies to return new copies
            var items = new Movie[count];

            // Don;t need the for loop
            //for (int index = 0; index < _items.Length; ++index)
            //{
            //    items[index] = Copy(items[index]);
            //};

            // Each itereation the next element is coped to the item variable
            // Two limitations
            // No Index (use a simple index variable)
            // Item is read-only
            // Array cannot change for the life of the loop (keep a separate list)
            var index = 0;
            foreach (var item in _items)
            {   
                // item = new Movie();
                if (item != null)    
                    items[index++] = item.Clone();
            };

            return items;
        }

        // Arrays are always open in C#
        // Array size is specified at the point of creation
        private Movie[] _items = new Movie[100];
    }
}
