using System;
using System.Collections.Generic;

namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase
    {
        public MemoryMovieDatabase ()
        {
            // TODO: Seed
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "PG";
            //movie.RunLength = 210;
            //movie.ReleaseYear = 1975;
            //movie.Description = "Shark Movie";
            //movie.Id = 1;

           
            _items.Add(new Movie() {
                Title = "Jaws",
                Rating = "PG",
                RunLength = 210,
                ReleaseYear = 1975,
                Description = "Shark Movie",
                Id = 1,
            });

            //movie = new Movie();
            //movie.Title = "Dune";
            //movie.Rating = "PG";
            //movie.RunLength = 300;
            //movie.ReleaseYear = 1982;
            //movie.Description = "Sand Movie";
            //movie.Id = 2;
            
            _items.Add(new Movie() {
                Title = "Dune",
                Rating = "PG",
                RunLength = 300,
                ReleaseYear = 1982,
                Description = "Sand Movie",
                Id = 2,
            });

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
            
            _items.Add(new Movie() {
                Title = "Jaws 2",
                Rating = "PG",
                RunLength = 190,
                ReleaseYear = 1979,
                Description = "Shark Movie again",
                Id = 3,
            });
        }
        
        // TODO: Error Handling
        public Movie Add ( Movie movie, out string error )
        {
            // Movie must be valid
            error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return null;

            // Movie title must be unique
            var existing = FindByTitle(movie.Title);
            if(existing != null)
            {
                error = "Movie must be unique";
                return null;
            };

            // Clone
            var newMovie = movie.Clone();

            // Set Unique ID
            newMovie.Id = _nextId++;

            _items.Add(newMovie);

            movie.Id = newMovie.Id;
            return movie;
        }

        private Movie FindByTitle ( string title )
        {
            foreach (var movie in _items)
            {
                if (String.Compare(title, movie.Title, true) == 0)
                    return movie;
            };

            return null;
        }

        private Movie FindById ( int id )
        {
            foreach (var movie in _items)
            {
                if (movie.Id == id)
                    return movie;
            };

            return null;
        }

        // TODO: Update
        public string Update ( int id, Movie movie )
        {
            // Movie must be valid
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return error;

            // Movie must exist
            var existing = FindById(id);
            if (existing == null)
                return "Movie Not Found";

            // Movie title must be unique
            var dup = FindByTitle(movie.Title);
            if (dup != null && dup.Id != id)
                return "Movie must be unique";

            Copy(existing, movie);

            return null;
        }
        
        private void Copy ( Movie target, Movie source )
        {
            target.Title = source.Title;
            target.Description = source.Description;
            target.Rating = source.Rating;
            target.RunLength = source.RunLength;
            target.ReleaseYear = source.ReleaseYear;
            target.IsClassic = source.IsClassic;
        }
        
        // TOOD: Delete
        public void Delete ( int id )
        {
            // TODO: Validate id

            var movie = FindById(id);
            
            if (movie != null)
                _items.Remove(movie);
        }

        // TODO: Get
        public Movie Get ( int id )
        {
            // TODO: Validate id
            var movie = FindById(id);

            return movie?.Clone();
        }

        // TODO: Get All
        public Movie[] GetAll ()
        {
            // NEVER DO THIS
            // return _items;

            // Array.Copy(); - Will copy aqrray but not ref movies

            // Need to filter out null movies
            //var count = 0;
            //foreach(var item in _items)
            //{
            //    if (item != null)
            //        ++count;
            //};

            //var count = _items.Count;

            // Must clone both array and movies to return new copies
            var items = new Movie[_items.Count];

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
                items[index++] = item.Clone();

            return items;
        }

        // Arrays are always open in C#
        // Array size is specified at the point of creation

        // Dynamically resizing array
        private List<Movie> _items = new List<Movie>();
        private int _nextId = 1;
    }
}
