namespace MovieLibrary.Memory
{
    public abstract class MovieDatabase
    {
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

        private abstract Movie FindById ( int id );
        private abstract Movie FindByTitle ( string title );
    }
}