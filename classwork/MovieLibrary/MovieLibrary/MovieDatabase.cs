using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieLibrary
{
    public abstract class MovieDatabase : IMovieDatabase
    {
      
        public Movie Add ( Movie movie )
        {
            var item = movie ?? throw new ArgumentNullException(nameof(movie));

            ObjectValidator.Validate(movie);

            // Movie title must be unique
            var existing = FindByTitle(movie.Title);
            if (existing != null)
                throw new InvalidOperationException("Movie must be unique");

            return AddCore(movie);
        }

        protected abstract Movie AddCore ( Movie movie );
        // TOOD: Delete
        public void Delete ( int id )
        {
            // TODO: Validate id
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0.");

            DeleteCore(id);
        }

        protected abstract void DeleteCore ( int id );

        // TODO: Get
        public Movie Get ( int id )
        {
            // TODO: Validate id
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID mustb e greater than 0.");

            return GetCore(id);
        }

        protected abstract Movie GetCore ( int id );

        public IEnumerable<Movie> GetAll () => GetAllCore() ?? Enumerable.Empty<Movie>();

        protected abstract IEnumerable<Movie> GetAllCore ();
        
        // TODO: Update
        public void Update ( int id, Movie movie )
        {
            // Validation
            // Id must be > 0
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID mustb e greater than 0.");

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            

            ObjectValidator.Validate(movie);

            // Movie must exist
            var existing = FindById(id);
            if (existing == null)
                throw new Exception("Movie Not Found");

            // Movie title must be unique
            var dup = FindByTitle(movie.Title);
            if (dup != null && dup.Id != id)
                throw new InvalidOperationException("Movie must be unique");

            UpdateCore(id, movie);
        }

        protected abstract void UpdateCore ( int id, Movie movie );

        protected abstract Movie FindById ( int id );
        protected abstract Movie FindByTitle ( string title );
    }
}