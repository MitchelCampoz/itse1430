using System.Collections.Generic;

namespace MovieLibrary
{
    public interface IMovieDatabase
    {
        // All members are always public; can't specify access
        // Only type memvers that are not implementation details are allowed
        // Methods, properties, events
        // The implmentation is not provided

        Movie Add ( Movie movie, out string error );
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        string Update ( int id, Movie movie );
    }
}