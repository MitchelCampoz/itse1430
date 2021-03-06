using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace MovieLibrary.Memory
{
    public class MemoryMovieDatabase : IMovieDatabase
    {
        public void IsOnlyAvailableInMemoryMovieDatabase ()
        {

        }
        //public MemoryMovieDatabase ()
        //{


            //    // Collection initializer syntax
            //    var movies = new[] {

            //        (new Movie() {
            //            Title = "Jaws",
            //            Rating = "PG",
            //            RunLength = 210,
            //            ReleaseYear = 1975,
            //            Description = "Shark Movie",
            //            Id = 1,
            //        }),

            //        (new Movie() {
            //            Title = "Dune",
            //            Rating = "PG",
            //            RunLength = 300,
            //            ReleaseYear = 1982,
            //            Description = "Sand Movie",
            //            Id = 2,
            //        }),

            //        (new Movie() {
            //            Title = "Jaws 2",
            //            Rating = "PG",
            //            RunLength = 190,
            //            ReleaseYear = 1979,
            //            Description = "Shark Movie again",
            //            Id = 3,
            //        })

            //    };

            //    _items.AddRange(movies);
            // TODO: Seed
            //var movie = new Movie();
            //movie.Title = "Jaws";
            //movie.Rating = "PG";
            //movie.RunLength = 210;
            //movie.ReleaseYear = 1975;
            //movie.Description = "Shark Movie";
            //movie.Id = 1;


            //_items.Add(new Movie() {
            //    Title = "Jaws",
            //    Rating = "PG",
            //    RunLength = 210,
            //    ReleaseYear = 1975,
            //    Description = "Shark Movie",
            //    Id = 1,
            //});

            //movie = new Movie();
            //movie.Title = "Dune";
            //movie.Rating = "PG";
            //movie.RunLength = 300;
            //movie.ReleaseYear = 1982;
            //movie.Description = "Sand Movie";
            //movie.Id = 2;

            //_items.Add(new Movie() {
            //    Title = "Dune",
            //    Rating = "PG",
            //    RunLength = 300,
            //    ReleaseYear = 1982,
            //    Description = "Sand Movie",
            //    Id = 2,
            //});

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

            //_items.Add(new Movie() {
            //    Title = "Jaws 2",
            //    Rating = "PG",
            //    RunLength = 190,
            //    ReleaseYear = 1979,
            //    Description = "Shark Movie again",
            //    Id = 3,
            //});
        //}

        // TODO: Error Handling
        public Movie Add ( Movie movie )
        {
            // Validation
            // Movie is not null
            // Movie is valid
            // Movie cannot already exist
            //if (movie == null)
                // Blow up
            var item = movie ?? throw new ArgumentNullException(nameof(movie));

            ObjectValidator.Validate(movie);

            //var errors = validator.TryValidate(movie);

            //error = errors.FirstOrDefault().ErrorMessage;

            //if (!String.IsNullOrEmpty(error))
            //    return null;
            // Movie must be valid
            //error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return null;

            // Movie title must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                throw new InvalidOperationException("Movie must be unique");

            // Clone
            var newMovie = movie.Clone();

            // Set Unique ID
            newMovie.Id = _nextId++;

            _items.Add(newMovie);

            movie.Id = newMovie.Id;
            return movie;
        }

        [Obsolete("Use GetCore Instead")]   // Add true to make it from a warning to an error
        private Movie FindByTitle ( string title )
        {
            return _items.FirstOrDefault(x => String.Compare(title, x.Title, true) == 0);
            //foreach (var movie in _items)
            //{
            //    if (String.Compare(title, movie.Title, true) == 0)
            //        return movie;
            //};

            //return null;
        }

        private Movie FindById ( int id )
        {
            //return _items.FirstOrDefault(x => x.Id == id);

            // LINQ syntax
            return (from movie in _items where movie.Id == id select movie).FirstOrDefault();

            // Where (Func <Movie, bool>) -> Ienumerable<T>
            //return _items.Where(x => x.Id == id).FirstOrDefault();
            //foreach (var movie in _items)
            //{
            //    if (movie.Id == id)
            //        return movie;
            //};

            //return null;
        }

        // TODO: Update
        public void Update ( int id, Movie movie )
        {
            // Validation
            // Id must be > 0
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID mustb e greater than 0.");

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            // Movie is not null
            // Movie is valid
            // Movie does not already exist



            // Movie must be valid
            //var validator = new ObjectValidator();
            //var errors = validator.TryValidate(movie);

            //error = errors.FirstorDefault().ErrorMessage;

            //if (!String.IsNullOrEmpty(error))
            //    return null;
            //var errors = new List<ValidationResult>();
            //var context = new ValidationContext(movie);
            //if (Validator.TryValidateObject(movie, context, errors))
            //{
            //    error = errors.FirstOrDefault().ErrorMessage;
            //    return null;
            //};

            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            ObjectValidator.Validate(movie);

            // Movie must exist
            var existing = FindById(id);
            if (existing == null)
                throw new Exception("Movie Not Found");

            // Movie title must be unique
            var dup = FindByTitle(movie.Title);
            if (dup != null && dup.Id != id)
                throw new InvalidOperationException("Movie must be unique");

            Copy(existing, movie);
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
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID mustb e greater than 0.");

            var movie = FindById(id);

            if (movie != null)
                _items.Remove(movie);
        }

        // TODO: Get
        public Movie Get ( int id )
        {
            // TODO: Validate id
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID mustb e greater than 0.");
            
            var movie = FindById(id);

            return movie?.Clone();
        }


        private class IdandTitle
        {
            public int Id { get; set; }

            public string Title { get; set; }
        }

        private IdandTitle Convert (Movie movie )
        {
            return new IdandTitle() {
                Id = movie.Id,
                Title = movie.Title
            };
        }

        //private Movie Clone ( Movie movie )
        //{
        //    return movie.Clone();
        //}

        // TODO: Get All
        public IEnumerable<Movie> GetAll ()
        {
            return _items.Select(x => x.Clone());
            // NEVER DO THIS
            // return _items;

            //int counter = 0;
            // Use Iterator Syntax

            // Select transforms S to T
            // IEnumerable<IdandTitle> titles = _items.Select<Movie, IdandTitle>(Convert);
            // IEnumerable<IdandTitle> titles = _items.Select(Convert);
            // return _items.Select(Clone);

            // Using LINQ extension method here
            // return _items.Select(x => x.Clone());
            // return from x in _items select x.Clone();

            // foreach (var item in _items)
            // ++counter;
            // System.Diagnostics.Debug.WriteLine($"Return {item.Title}");
            // yield return item.Clone();

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
            //var items = new Movie[_items.Count];

            //// Don;t need the for loop
            ////for (int index = 0; index < _items.Length; ++index)
            ////{
            ////    items[index] = Copy(items[index]);
            ////};

            //// Each itereation the next element is coped to the item variable
            //// Two limitations
            //// No Index (use a simple index variable)
            //// Item is read-only
            //// Array cannot change for the life of the loop (keep a separate list)
            //var index = 0;
            //foreach (var item in _items)
            //    items[index++] = item.Clone();

            //return items;
        }

        [Conditional("DEBUG")]
        private void Dump ()
        {

        }

        // Arrays are always open in C#
        // Array size is specified at the point of creation

        // Dynamically resizing array
        private List<Movie> _items = new List<Movie>();
        private int _nextId = 1;
    }
}
