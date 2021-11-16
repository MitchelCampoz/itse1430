﻿using System.Collections.Generic;

namespace MovieLibrary
{
    public interface IMovieDatabase
    {
        // All members are always public; can't specify access
        // Only type memvers that are not implementation details are allowed
        // Methods, properties, events
        // The implmentation is not provided

        Movie Add ( Movie movie );
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        void Update ( int id, Movie movie );
    }
}